using System.Collections;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField] private float TimerBetweenDeaths = 0.5f;
    [SerializeField] private Animation TextAnimation;
    [SerializeField] private TextMeshProUGUI ComboText;
    private int _numberOfCombos;

    void Start()
    {
        EventBus.Instance.OnEnemyDeath += CountCombos;
    }

    void OnDisable()
    {
        EventBus.Instance.OnEnemyDeath -= CountCombos;
    }

    private void CountCombos()
    {
        _numberOfCombos++;
        UpdateComboText();

        StopAllCoroutines();
        StartCoroutine(ForgetCombo());
    }

    private void UpdateComboText()
    {
        ComboText.enabled = true;
        ComboText.text = $"x{_numberOfCombos}";
        TextAnimation.Play();
    }

    private IEnumerator ForgetCombo()
    {
        yield return new WaitForSeconds(TimerBetweenDeaths);
        SettingManager.Instance.SetMaxCombo(_numberOfCombos);
        _numberOfCombos = 0;
        ComboText.enabled = false;
    }
}
