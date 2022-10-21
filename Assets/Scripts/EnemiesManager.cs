using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    RandomPosition positionGenerator;
    float timer;

    private void Awake()
    {
        positionGenerator = new RandomPosition();
    }
    private void Update()
    {
        SpawnEnemyWithDelay();
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = positionGenerator
            .GenerateRandomPositionOutsideFOVFromOrigin(spawnArea, player.transform.position);

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = randomPosition;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private void SpawnEnemyWithDelay()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }
}
