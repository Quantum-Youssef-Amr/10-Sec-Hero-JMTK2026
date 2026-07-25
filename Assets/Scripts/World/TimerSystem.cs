using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private int StageTimerStartValue, WarningOnTime = 3, TargetTime;
    [SerializeField] private AudioSource ClickSound, GainTimeSound;
    private int _currentTime;

    private int TimerUpdater
    {
        set
        {
            _currentTime = value;
            EventBus.Instance.OnTimerUpdate?.Invoke(_currentTime);
        }

        get => _currentTime;
    }

    void Start()
    {
        TimerUpdater = StageTimerStartValue;

        EventBus.Instance.OnAddToTimer += AddTimeToTimer;
        EventBus.Instance.OnStartTimer += StartCountDown;
        EventBus.Instance.OnWinRun += StopTimer;
    }

    void OnDisable()
    {
        EventBus.Instance.OnAddToTimer -= AddTimeToTimer;
        EventBus.Instance.OnStartTimer -= StartCountDown;
        EventBus.Instance.OnWinRun -= StopTimer;

    }


    private void StopTimer(int arg1, int arg2)
    {
        StopAllCoroutines();
    }

    private void StartCountDown()
    {
        StartCoroutine(Countdown());
    }

    private void AddTimeToTimer(int additionalTime)
    {
        TimerUpdater += additionalTime;
        GainTimeSound.Play();
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        TimerUpdater--;
        ClickSound.Play();

        if (TimerUpdater <= 0)
        {
            EventBus.Instance.OnTimerIsZero?.Invoke();
            EventBus.Instance.OnGameOver?.Invoke();
            EventBus.Instance.OnCameraShake?.Invoke();
        }

        if (TimerUpdater >= TargetTime)
            EventBus.Instance.OnTimerTargetReached?.Invoke();

        if (TimerUpdater <= WarningOnTime)
            EventBus.Instance.OnTimerWarning?.Invoke();
        else
            EventBus.Instance.OnTimerNoWarning?.Invoke();

        if (TimerUpdater > 0)
            StartCoroutine(Countdown());
    }
}
