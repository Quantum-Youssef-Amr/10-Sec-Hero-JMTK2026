using UnityEngine;

public class DoorHealth : Health
{
    [SerializeField] private int NextLevelNumber;
    [SerializeField] private LayerMask EnemiesLayerMask;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == EnemiesLayerMask)
        {
            TakeDamage(1);
            EventBus.Instance.OnCameraShake?.Invoke();
            DamageAnimation.Play();
        }

        if (collision.gameObject.layer == LayerMask.GetMask("Player") && _canAdvance)
            EventBus.Instance.OnWinLevel?.Invoke(NextLevelNumber);
    }

    protected override void Die()
    {
        EventBus.Instance.OnGameOver?.Invoke();
    }
}
