using UnityEngine;
using System.Collections;
public class JumperAI_Level_2 : Enemy
{
    [SerializeField] private float TeleportDistance = 2, TeleportTimer = 2f, RandomWeight = 0.2f, DoorWeight = 0.8f;
    [SerializeField] private GameObject TeleportParticles, EnterParticles;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(TeleportTimer);
        Vector2 m_teleportDirection = Random.insideUnitCircle.normalized * RandomWeight + (Vector2.zero - (Vector2)_t.position).normalized * DoorWeight;
        m_teleportDirection.normalized.Normalize();

        Vector2 m_teleportationLoc = (Vector2)_t.position + m_teleportDirection * TeleportDistance;
        GameObject m_par = Instantiate(TeleportParticles, m_teleportationLoc, Quaternion.identity);
        EnterParticles.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(1f);
        EnterParticles.GetComponent<ParticleSystem>().Stop();
        _t.position = m_teleportationLoc;
        Destroy(m_par);
        StartCoroutine(Teleport());
    }

}
