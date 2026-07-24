using UnityEngine;
using System.Collections;
public class PlusPoint : MonoBehaviour
{
    [SerializeField] private float DeltaPosition, DestroyAfter = 1f;

    void Start()
    {
        StartCoroutine(DestroyText());
    }

    private IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(DestroyAfter);
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(DeltaPosition * Time.deltaTime * Vector2.up);
    }
}
