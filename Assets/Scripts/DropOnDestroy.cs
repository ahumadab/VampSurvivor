using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class DropOnDestroy : MonoBehaviour
    {
        [SerializeField] List<GameObject> dropItemPrefabs;
        [SerializeField][Range(0f, 1f)] float chanceOfDrop = 1f;

        bool isQuitting = false;
        private void OnApplicationQuit()
        {
            isQuitting = true;
        }

        private void OnDestroy()
        {
            if (isQuitting) { return; }
            if (Random.value < chanceOfDrop)
            {
                int randomIndex = Random.Range(0, dropItemPrefabs.Count);
                GameObject randomObjectToDrop = Instantiate(dropItemPrefabs[randomIndex]);
                randomObjectToDrop.transform.position = transform.position;
            }
        }
    }
}
