using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class DropOnDestroy : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _dropItemPrefabs;
        [SerializeField][Range(0f, 1f)] private float _chanceOfDrop = 1f;

        bool _isQuitting = false;
        private void OnApplicationQuit()
        {
            _isQuitting = true;
        }

        public void CheckDrop()
        {
            if (_isQuitting) return; 
            if (!IsDropping()) return;

            int randomIndex = Random.Range(0, _dropItemPrefabs.Count);
            GameObject randomObjectToDrop = Instantiate(_dropItemPrefabs[randomIndex]);
            randomObjectToDrop.transform.position = transform.position;
        }

        private bool IsDropping()
        {
            return Random.value < _chanceOfDrop;
        }
    }
}
