using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float MaxHealth;

    protected float _currentHealth;

    protected virtual void Start()
    {
        _currentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float Damage)
    {
        _currentHealth -= Damage;
        if (_currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
