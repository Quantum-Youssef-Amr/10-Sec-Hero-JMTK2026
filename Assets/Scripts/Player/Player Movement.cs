using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float WalkingSpeed = 5, DashForce = 10, DashCoolDown = 0.4f, TimeScale = 1000;
    [SerializeField] private ParticleSystem DashParticles;

    private Rigidbody2D _rb;
    private Transform _t;
    private bool _canDash = true;

    #region Input
    private NewInputSystem _inputs;
    void OnEnable() => _inputs.Enable();
    void OnDisable() => _inputs.Disable();
    void Awake() => _inputs = new();
    #endregion

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _t = transform;

        _inputs.Player.Jump.performed += PlayerDash;
        _inputs.Player.lookingAround.performed += RotatePlayer;
    }

    void Update()
    {
        if (_inputs.Player.Move.IsInProgress())
        {
            MovePlayer(_inputs.Player.Move.ReadValue<Vector2>());
        }
    }

    private void RotatePlayer(InputAction.CallbackContext context)
    {
        Vector2 m_lookWorldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.value) - _t.position;
        _t.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, m_lookWorldPoint));

        ParticleSystem.MainModule m_particleRotation = DashParticles.main;
        m_particleRotation.startRotation = Vector2.SignedAngle(Vector2.up, _t.up);
    }

    private void PlayerDash(InputAction.CallbackContext context)
    {
        if (!_canDash) return;

        Vector2 m_DashDir = _t.up;
        _canDash = false;

        StartDashParticlesSystem();
        _rb.AddForce(DashForce * Time.deltaTime * TimeScale * m_DashDir, ForceMode2D.Impulse);

    }

    private void StartDashParticlesSystem()
    {
        DashParticles.Play();
        EventBus.Instance.OnPlayerDash?.Invoke();
        EventBus.Instance.OnCameraShake?.Invoke();
        StartCoroutine(ResetDash());
    }

    private void MovePlayer(Vector2 movingVec)
    {
        _rb.AddForce(WalkingSpeed * Time.deltaTime * TimeScale * movingVec, ForceMode2D.Force);
    }

    private IEnumerator ResetDash()
    {
        yield return new WaitForSeconds(DashCoolDown);
        _canDash = true;
    }
}
