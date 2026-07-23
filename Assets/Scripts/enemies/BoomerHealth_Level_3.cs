using UnityEngine;

public class BoomerHealth : EnemyHealth
{
    [SerializeField] private float ExplosionRadius = 4;
    [SerializeField] private GameObject ExplosionParticles;

    protected override void Die()
    {
        Transform m_t = transform;
        Instantiate(ExplosionParticles, m_t.position, Quaternion.identity);
        RaycastHit2D[] m_enemiesInArea = Physics2D.CircleCastAll(m_t.position, ExplosionRadius, Vector2.zero, 0, LayerMask.GetMask("Enemies"));

        for (int enemyIdx = 0; enemyIdx < m_enemiesInArea.Length; enemyIdx++)
        {
            if (m_enemiesInArea[enemyIdx].collider.gameObject.Equals(gameObject))
                continue;

            m_enemiesInArea[enemyIdx].collider.GetComponent<EnemyHealth>().TakeDamage(1);
        }
        // TODO add explosion sound
        base.Die();
    }
}
