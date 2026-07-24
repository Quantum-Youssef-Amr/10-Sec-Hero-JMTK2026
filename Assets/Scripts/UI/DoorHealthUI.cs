using System;
using UnityEngine;
using UnityEngine.UI;

public class DoorHealthUI : MonoBehaviour
{
    [SerializeField] private Image FullImage;
    void Start()
    {
        EventBus.Instance.OnDoorHealthChanged += UpdateVisuals;
    }

    void OnDisable()
    {
        EventBus.Instance.OnDoorHealthChanged -= UpdateVisuals;
    }

    private void UpdateVisuals(float parentage)
    {
        FullImage.fillAmount = parentage;
    }
}
