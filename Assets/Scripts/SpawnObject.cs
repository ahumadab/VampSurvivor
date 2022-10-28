using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnObject : MonoBehaviour
    {
        [SerializeField] GameObject spawnableObject;
        [SerializeField] [Range(0f, 1f)] float probability;
        RandomPosition positionGenerator;
        private void Awake()
        {
            positionGenerator = new RandomPosition();
        }

        public void Spawn(Vector3 position)
        {
            if (Random.value < probability)
            {
                Vector3 randomPosition = positionGenerator.GenerateRandomPositionInTile(position);
                GameObject gameObject = Instantiate(spawnableObject, randomPosition, Quaternion.identity);
            }
        }
    }
}
