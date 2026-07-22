using System;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float DefaultCameraZoom, DashZoom, RecoveryTime;
    private Camera _main;
    void Start()
    {
        _main = Camera.main;
        EventBus.Instance.OnPlayerDash += ZoomCamera;
    }

    private void ZoomCamera()
    {
        _main.orthographicSize = DashZoom;
    }

    void Update()
    {
        _main.orthographicSize = Mathf.Lerp(_main.orthographicSize, DefaultCameraZoom, RecoveryTime * Time.deltaTime);
    }
}
