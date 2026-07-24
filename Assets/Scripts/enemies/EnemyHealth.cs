using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyHealth : Health
{
    [SerializeField] protected int Reward;
    [SerializeField] protected GameObject DeathParticles, RewardText;
    [SerializeField] protected Animation HurtAnimation;
    protected override void Die()
    {
        EventBus.Instance.OnAddToTimer?.Invoke(Reward);
        DieWithoutReward();
    }

    public override void TakeDamage(float Damage)
    {
        HurtAnimation.Play();
        base.TakeDamage(Damage);
    }

    public void DieImmediate()
    {
        DieWithoutReward();
    }

    private void DieWithoutReward()
    {
        EventBus.Instance.OnCameraShake?.Invoke();
        EventBus.Instance.OnEnemyDeath?.Invoke();
        SpawnDeathParticles();
        // TODO add sounds
        base.Die();
    }

    private void SpawnDeathParticles()
    {
        ParticleSystem.MainModule m_par = Instantiate(DeathParticles, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().main;
        GameObject m_rewardText = Instantiate(RewardText, transform.position, Quaternion.identity);

        m_rewardText.GetComponent<TextMeshPro>().text = $"+{Reward}";

        m_par.startColor = GetComponent<SpriteRenderer>().color;
    }
}
