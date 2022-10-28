using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class TerrainTile : MonoBehaviour
    {
        [SerializeField] Vector2Int tilePosition;
        [SerializeField] List<GameObject> spawnObjects;
        [SerializeField][Range(0f, 1f)] float probability;
        RandomPosition positionGenerator;

        private void Awake()
        {
            positionGenerator = new RandomPosition();
        }
        void Start()
        {
            GetComponentInParent<WorldScrolling>().Add(gameObject, tilePosition);
        }

        public void Spawn()
        {

            if (Random.value < probability)
            {
                int randomIndex = Random.Range(0, spawnObjects.Count);
                GameObject randomGameObject = spawnObjects[randomIndex];
                Vector3 randomPosition = positionGenerator.GenerateRandomPositionInTile(transform.position);
                GameObject gameObject = Instantiate(randomGameObject, randomPosition, Quaternion.identity);
            }
        }
    }
}
