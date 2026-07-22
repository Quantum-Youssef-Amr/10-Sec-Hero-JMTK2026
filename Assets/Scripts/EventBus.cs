using UnityEngine;
using System;
public class EventBus : MonoBehaviour
{
    public static EventBus Instance { private set; get; }

    public Action OnPlayerDash;

    public Action<int> OnAddToTimer, OnTimerUpdate;
    public Action OnTimerIsZero, OnTimerWarning;


    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }
}
