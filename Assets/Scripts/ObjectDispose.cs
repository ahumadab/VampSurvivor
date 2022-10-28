using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectDispose : MonoBehaviour
    {
        Transform playerTransform;
        [SerializeField] float maxDistance = 100f;

        private void Start()
        {
            playerTransform = GameManager.instance.playerTransform;
        }

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance > maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
