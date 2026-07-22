using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 Offset;

    private Transform _t;
    void Start()
    {
        _t = transform;
    }

    void Update()
    {
        _t.position = Vector3.Lerp(_t.position, Target.position + Offset, Speed == 0 ? 1 : Time.deltaTime * Speed);
    }
}
