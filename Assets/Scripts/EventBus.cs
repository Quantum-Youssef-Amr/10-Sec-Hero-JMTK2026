using UnityEngine;
using System;
public class EventBus : MonoBehaviour
{
    public static EventBus Instance { private set; get; }

    public Action OnPlayerDash;

    public Action<int> OnAddToTimer, OnTimerUpdate;
    public Action OnTimerIsZero, OnTimerWarning, OnTimerNoWarning, OnTimerTargetReached;

    public Action OnGameOver;
    public Action<int> OnWinLevel;

    public Action OnCameraShake;

    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }
}
