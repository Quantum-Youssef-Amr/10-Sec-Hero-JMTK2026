using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] protected float MovementSpeed, TimeScale = 500f;

    protected Rigidbody2D _rb;
    protected Transform _t;
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _t = transform;
    }

    void Update()
    {
        MoveTowardDoor();
    }

    protected virtual void MoveTowardDoor()
    {
        _rb.AddForce(MovementSpeed * Time.deltaTime * TimeScale * (Vector2.zero - (Vector2)_t.position).normalized, ForceMode2D.Force);
    }
}
