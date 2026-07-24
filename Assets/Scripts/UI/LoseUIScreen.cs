using System;
using UnityEngine;

public class LoseUIScreen : MonoBehaviour
{
    [SerializeField] private GameObject LoseScreen;

    void Start()
    {
        EventBus.Instance.OnGameOver += ShowScreen;
    }

    private void ShowScreen()
    {
        LoseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnRestartBtnPressed()
    {
        GameSceneManager.Instance.TransitionToScene("level 1", 0.5f, true);
    }

    public void OnQuitBtnPressed()
    {
        GameSceneManager.Instance.TransitionToScene("MainMenu", 0.5f, true);
    }
}
