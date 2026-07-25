using System;
using UnityEngine;

public class LoseUIScreen : MonoBehaviour
{
    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private AudioSource GameOverSound;

    void Start()
    {
        EventBus.Instance.OnGameOver += ShowScreen;
    }
    void OnDisable()
    {
        EventBus.Instance.OnGameOver -= ShowScreen;
    }

    private void ShowScreen()
    {
        LoseScreen.SetActive(true);
        GameOverSound.Play();
        Time.timeScale = 0;
    }

    public void OnRestartBtnPressed()
    {
        Time.timeScale = 1;
        GameSceneManager.Instance.TransitionToScene("level 1", 0.5f, true);
    }

    public void OnQuitBtnPressed()
    {
        Time.timeScale = 1;
        GameSceneManager.Instance.TransitionToScene("MainMenu", 0.5f, true);
    }
}
