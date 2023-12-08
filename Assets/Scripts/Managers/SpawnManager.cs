using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Transform _pointToRotate;
    public float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, spawnInterval);
    }



    private void SpawnEnemy()
    {

        int randomEnemyIndex = Random.Range(0, _enemies.Length);
        int randomSpawnIndex = Random.Range(0, _spawnPoints.Length);

        GameObject enemyToSpawn = _enemies[randomEnemyIndex];
        Transform spawnPoint = _spawnPoints[randomSpawnIndex];

        GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        SetMovePoint(spawnedEnemy);

    }

    private void SetMovePoint(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().targetToMoveOrAttack = _pointToRotate;
    }
}

