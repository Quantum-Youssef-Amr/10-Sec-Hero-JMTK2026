using System.Linq;
using UnityEngine;

public class DoorHealth : Health
{
    [SerializeField] private int NextLevelNumber;
    [SerializeField] private GameObject DoorOverlay;
    [SerializeField] private ParticleSystem DoorParticle;
    [SerializeField] private Animation DamageAnimation;
    [SerializeField] private AudioSource DoorHitAudio, DoorOpenedAudio;
    private bool _canAdvance;

    #region Input
    private NewInputSystem _inputs;
    void OnEnable() => _inputs.Enable();
    void OnDisable()
    {
        _inputs.Disable();
        EventBus.Instance.OnTimerTargetReached -= ChangeVisuals;
    }

    void Awake() => _inputs = new();
    #endregion


    protected override void Start()
    {
        base.Start();
        EventBus.Instance.OnTimerTargetReached += ChangeVisuals;
        _inputs.Player.Cheats.performed += _ => WinLevel();
    }

    private void ChangeVisuals()
    {
        if (!_canAdvance)
            DoorOpenedAudio.Play();

        _canAdvance = true;
        DoorParticle.gameObject.SetActive(true);
        DoorOverlay.gameObject.SetActive(true);

        DoorParticle.Play();
    }

    public override void TakeDamage(float Damage)
    {
        base.TakeDamage(Damage);
        EventBus.Instance.OnDoorHealthChanged?.Invoke(_currentHealth / MaxHealth);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            collision.TryGetComponent(out EnemyHealth m_health);
            if (m_health)
                m_health.DieImmediate();


            EventBus.Instance.OnCameraShake?.Invoke();
            DamageAnimation.Play();
            DoorHitAudio.Play();
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Player") && _canAdvance)
            WinLevel();
    }

    private void WinLevel()
    {
        EventBus.Instance.OnWinLevel?.Invoke(NextLevelNumber);
    }

    protected override void Die()
    {
        EventBus.Instance.OnGameOver?.Invoke();
    }
}
