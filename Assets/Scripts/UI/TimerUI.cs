using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerUI : MonoBehaviour
{
    [SerializeField] private Color WarningTimerColor, DefaultColor;
    [SerializeField] private Animation ClickAnimation;
    private TextMeshProUGUI TimerUIText;

    void Start()
    {
        TimerUIText = GetComponent<TextMeshProUGUI>();

        EventBus.Instance.OnTimerUpdate += UpdateTimerUI;
        EventBus.Instance.OnTimerWarning += () => ChangeTimerToWarning(WarningTimerColor);
        EventBus.Instance.OnTimerNoWarning += () => ChangeTimerToWarning(DefaultColor);
    }

    private void ChangeTimerToWarning(Color color)
    {
        TimerUIText.color = color;
    }

    private void UpdateTimerUI(int timerValue)
    {
        string m_timerVal = timerValue > 10 ? "0" + timerValue : "00" + timerValue;
        TimerUIText.text = m_timerVal;
        ClickAnimation.Play();
    }
}
