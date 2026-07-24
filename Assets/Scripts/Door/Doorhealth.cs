using UnityEngine;

public class DoorHealth : Health
{
    [SerializeField] private int NextLevelNumber;
    [SerializeField] private GameObject DoorOverlay;
    [SerializeField] private ParticleSystem DoorParticle;
    [SerializeField] private Animation DamageAnimation;
    private bool _canAdvance;

    protected override void Start()
    {
        base.Start();
        EventBus.Instance.OnTimerTargetReached += ChangeVisuals;
    }

    private void ChangeVisuals()
    {
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
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Player") && _canAdvance)
            EventBus.Instance.OnWinLevel?.Invoke(NextLevelNumber);
    }

    protected override void Die()
    {
        EventBus.Instance.OnGameOver?.Invoke();
    }
}
