using UnityEngine;

public class SpinnerAI : Enemy
{
    [SerializeField] private float SideWaySpeed;

    private int _sideWayMovementDirection;

    protected override void Start()
    {
        base.Start();
        _sideWayMovementDirection = Random.value > 0.5 ? 1 : -1;
    }

    protected override void MoveTowardDoor()
    {
        base.MoveTowardDoor();
        _rb.AddForce(SideWaySpeed * Time.deltaTime * TimeScale * Vector2.Perpendicular((Vector2.zero - (Vector2)_t.position).normalized), ForceMode2D.Force);
    }
}
