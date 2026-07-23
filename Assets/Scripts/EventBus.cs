using UnityEngine;
using System;
public class EventBus : MonoBehaviour
{
    public static EventBus Instance { private set; get; }

    public Action OnPlayerDash;

    public Action<int> OnAddToTimer, OnTimerUpdate;
    public Action OnStartTimer, OnTimerIsZero, OnTimerWarning, OnTimerNoWarning, OnTimerTargetReached;
    public Action<float> OnDoorHealthChanged;
    public Action OnGameOver;
    public Action<int> OnWinLevel;
    public Action OnWinRun;
    public Action OnCameraShake;

    public Action OnStartLevelSpawner;
    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }
}
