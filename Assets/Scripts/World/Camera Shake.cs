using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float ShakeIntensity, NumberOfShakes;

    private Transform _camera;
    private Vector2 _R2Loc, _camera_pos;
    void Start()
    {
        _camera = Camera.main.transform;
        EventBus.Instance.OnCameraShake += () => StartCoroutine(ShakeCamera());
    }

    void OnDestroy()
    {
        EventBus.Instance.OnCameraShake -= () => StartCoroutine(ShakeCamera());
    }

    public IEnumerator ShakeCamera()
    {
        for (int i = 0; i < NumberOfShakes; i++)
        {
            _camera_pos = _camera.position;
            _R2Loc = Random.insideUnitCircle;
            _R2Loc.Normalize();

            _camera.position = new Vector3(_camera_pos.x + _R2Loc.x * ShakeIntensity, _camera_pos.y + _R2Loc.y * ShakeIntensity, -10f);
            yield return new WaitForEndOfFrame();
            _camera.position = transform.position + new Vector3(0, 0, -10f);
        }
        _camera.position = transform.position + new Vector3(0, 0, -10f);
    }
}
