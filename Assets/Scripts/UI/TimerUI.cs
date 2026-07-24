using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerUI : MonoBehaviour
{
    [SerializeField] private Color WarningTimerColor, DefaultColor;
    [SerializeField] private Animation ClickAnimation;
    private TextMeshProUGUI TimerUIText;
    private float _timerOldValue;
    void Start()
    {
        TimerUIText = GetComponent<TextMeshProUGUI>();

        EventBus.Instance.OnTimerUpdate += UpdateTimerUI;
        EventBus.Instance.OnTimerWarning += ChangeTimerToWarning;
        EventBus.Instance.OnTimerNoWarning += SetTimerToNormal;
    }

    void OnDisable()
    {
        EventBus.Instance.OnTimerUpdate -= UpdateTimerUI;
        EventBus.Instance.OnTimerWarning -= ChangeTimerToWarning;
        EventBus.Instance.OnTimerNoWarning -= SetTimerToNormal;
    }

    private void ChangeTimerToWarning()
    {
        ChangeTimerToWarning(WarningTimerColor);
    }

    private void SetTimerToNormal()
    {
        ChangeTimerToWarning(DefaultColor);
    }
    private void ChangeTimerToWarning(Color color)
    {
        TimerUIText.color = color;
    }

    private void UpdateTimerUI(int timerValue)
    {
        string m_timerVal = timerValue > 10 ? "0" + timerValue : "00" + timerValue;
        TimerUIText.text = m_timerVal;

        if (timerValue <= 3 || timerValue - _timerOldValue > 0)
        {
            ClickAnimation.Play();
        }
        _timerOldValue = timerValue;
    }
}
