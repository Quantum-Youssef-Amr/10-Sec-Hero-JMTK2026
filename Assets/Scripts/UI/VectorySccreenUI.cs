using TMPro;
using UnityEngine;

public class VictoryScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject VictoryScreen;
    [SerializeField] private ParticleSystem left, right;
    [SerializeField] private TextMeshProUGUI ComboText, KillsText;
    [SerializeField] private Animation ComboTextAnimation, KillsTextAnimation;

    void Start()
    {
        EventBus.Instance.OnWinRun += ShowScreen;
    }

    private void ShowScreen(int enemiesKilled, int MaxCombos)
    {
        VictoryScreen.SetActive(true);
        left.Play(); right.Play();
        // todo add celebrating sound

        ComboText.text = $"x{MaxCombos}";
        KillsText.text = enemiesKilled.ToString();

        ComboTextAnimation.Play();
        KillsTextAnimation.Play();
    }

}
