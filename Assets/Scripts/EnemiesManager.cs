using Assets.Scripts.Game;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemiesManager : MonoBehaviour
    {
        [SerializeField] GameObject enemy;
        [SerializeField] Vector2 spawnArea;
        [SerializeField] float spawnTimer;
        GameObject player;
        RandomPosition positionGenerator;
        float timer;

        private void Awake()
        {
            positionGenerator = new RandomPosition();
        }

        private void Start()
        {
            player = GameManager.instance.playerTransform.gameObject;
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
}
