using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InLevelMenus : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    #region Input
    private NewInputSystem _inputs;
    void OnEnable() => _inputs.Enable();
    void OnDisable() => _inputs.Disable();
    void Awake() => _inputs = new();
    #endregion

    void Start()
    {
        _inputs.UI.Pause.performed += TogglePauseGame;
        EventBus.Instance.OnWinLevel += LoadNextLevel;
    }

    private void LoadNextLevel(int nextLevel)
    {
        if (nextLevel == 4)
        {
            EventBus.Instance.OnWinRun?.Invoke();
            return;
        }

        GameSceneManager.Instance.TransitionWithReplaceScene($"level {nextLevel - 1}", $"level {nextLevel}", 0.5f, true);
    }

    private void TogglePauseGame(InputAction.CallbackContext context)
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        Time.timeScale = PauseMenu.activeSelf ? 0f : 1f;
    }

    public void RestartCurrentLevel()
    {
        GameSceneManager.Instance.TransitionWithReplaceScene("level 1", "level 1", 0.5f, true);
    }
}
