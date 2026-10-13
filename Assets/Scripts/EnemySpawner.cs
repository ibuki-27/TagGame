using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("ìGÇÃê›íË")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("èoåªà íu")]
    [SerializeField] private Transform[] spawnPoints;

    private bool spawned40 = false;
    private bool spawned20 = false;

    public void CheckSpawn(float remainingTime)
    {
        if (!spawned40 && remainingTime <= 40f)
        {
            SpawnEnemy();
            spawned40 = true;
        }

        if (!spawned20 && remainingTime <= 20f)
        {
            SpawnEnemy();
            spawned20 = true;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        NavMeshHit hit;

        if (NavMesh.SamplePosition(spawnPoint.position, out hit, 2f, NavMesh.AllAreas))
        {
            Instantiate(enemyPrefab, hit.position, spawnPoint.rotation);
        }
    }
}
