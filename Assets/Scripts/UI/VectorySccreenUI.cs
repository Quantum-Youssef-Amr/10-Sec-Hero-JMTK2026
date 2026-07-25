using TMPro;
using UnityEngine;

public class VictoryScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject VictoryScreen;
    [SerializeField] private ParticleSystem left, right;
    [SerializeField] private TextMeshProUGUI ComboText, KillsText;
    [SerializeField] private Animation ComboTextAnimation, KillsTextAnimation;
    [SerializeField] private AudioSource VictoryAudio;

    void Start()
    {
        EventBus.Instance.OnWinRun += ShowScreen;
    }

    void OnDisable()
    {
        EventBus.Instance.OnWinRun -= ShowScreen;
    }

    private void ShowScreen(int enemiesKilled, int MaxCombos)
    {
        Time.timeScale = 0;
        MusicManager.Instance.StopMusic();
        VictoryScreen.SetActive(true);
        left.Play(); right.Play();
        VictoryAudio.Play();

        ComboText.text = $"x{MaxCombos}";
        KillsText.text = enemiesKilled.ToString();

        ComboTextAnimation.Play();
        KillsTextAnimation.Play();
    }

}
