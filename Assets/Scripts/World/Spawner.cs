using System;
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float SpawnerTimeGap, NumberOfSpawnLocations;
    [SerializeField] private LevelEnemiesUnlockTiming[] levelEnemiesUnlockTimings;

    private Transform _t;
    void Start()
    {
        _t = transform;
        EventBus.Instance.OnTimerUpdate += CheckForEnemiesUnlocks;
        EventBus.Instance.OnStartLevelSpawner += () => StartCoroutine(SpawnEnemies());
    }

    void OnDestroy()
    {
        EventBus.Instance.OnTimerUpdate -= CheckForEnemiesUnlocks;
        EventBus.Instance.OnStartLevelSpawner -= () => StartCoroutine(SpawnEnemies());
    }

    private void CheckForEnemiesUnlocks(int TimerValue)
    {
        for (int enemyIdx = 0; enemyIdx < levelEnemiesUnlockTimings.Length; enemyIdx++)
        {
            if (levelEnemiesUnlockTimings[enemyIdx].TargetTime <= TimerValue)
                levelEnemiesUnlockTimings[enemyIdx].Unlocked = true;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(SpawnerTimeGap);
        for (int _ = 0; _ < NumberOfSpawnLocations;)
        {
            Vector2 m_spawnLocation = UnityEngine.Random.insideUnitCircle;
            m_spawnLocation.Normalize();
            m_spawnLocation *= UnityEngine.Random.Range(2.2f, 3f) * Camera.main.orthographicSize;

            LevelEnemiesUnlockTiming m_enemyToSpawn = levelEnemiesUnlockTimings[UnityEngine.Random.Range(0, levelEnemiesUnlockTimings.Length)];
            if (!m_enemyToSpawn.Unlocked)
                continue;

            Instantiate(m_enemyToSpawn.EnemyPrefab, m_spawnLocation, Quaternion.identity, _t);
            _++;
        }

        StartCoroutine(SpawnEnemies());
    }
}

[Serializable]
public class LevelEnemiesUnlockTiming
{
    public GameObject EnemyPrefab;
    public int TargetTime;
    public bool Unlocked;
}
