using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] private int StageTimerStartValue, WarningOnTime = 3, TargetTime;
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
        StartCoroutine(Countdown());


        EventBus.Instance.OnAddToTimer += AddTimeToTimer;
    }

    private void AddTimeToTimer(int additionalTime)
    {
        TimerUpdater += additionalTime;
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        TimerUpdater--;

        if (TimerUpdater <= 0)
            EventBus.Instance.OnTimerIsZero?.Invoke();

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
