using UnityEngine;
using System.Collections;
public class WobblerAI : Enemy
{
    [SerializeField] private float SideToSidePower, SideToSideMovementTimer = 0.5f;

    private int _side = 1;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(MoveSideToSide());
    }
    protected override void MoveTowardDoor()
    {
        base.MoveTowardDoor();
    }

    private IEnumerator MoveSideToSide()
    {
        yield return new WaitForSeconds(SideToSideMovementTimer);
        _side *= -1;
        _rb.AddForce(SideToSidePower * Time.deltaTime * TimeScale * _side * Vector2.Perpendicular((Vector2.zero - (Vector2)_t.position).normalized), ForceMode2D.Impulse);
        StartCoroutine(MoveSideToSide());
    }
}
