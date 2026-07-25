using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        MusicManager.Instance.StopMusic();
        VictoryScreen.SetActive(true);
        left.Play(); right.Play();
        VictoryAudio.Play();

        ComboText.text = $"x{MaxCombos}";
        KillsText.text = enemiesKilled.ToString();

        ComboTextAnimation.Play();
        KillsTextAnimation.Play();

        DestroyRestOfEnemies();
    }

    private void DestroyRestOfEnemies()
    {
        GameObject[] m_restOfEnemies = GameObject.FindGameObjectsWithTag("Enemies");
        print("# of enemies: " + m_restOfEnemies.Length);
        for (int idx = 0; idx < m_restOfEnemies.Length; idx++)
        {
            m_restOfEnemies[idx].GetComponent<EnemyHealth>().DieImmediate();
        }
    }
}
