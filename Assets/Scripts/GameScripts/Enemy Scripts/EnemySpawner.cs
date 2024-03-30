using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPoints;

    public int enemiesMaxCount = 5;
    public float delay = 5;

    private List<Transform> _spawnPoints;

    private float _timeLastSpawned;

    private void Start()
    {
        _spawnPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        var foundObjects = Object.FindObjectsOfType<EnemyHealth>();
        int count = foundObjects.Length;
        if(count > enemiesMaxCount) return;
        if(Time.time - _timeLastSpawned < delay) return;

        CreateEnemy();
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _timeLastSpawned = Time.time;
    }
}
