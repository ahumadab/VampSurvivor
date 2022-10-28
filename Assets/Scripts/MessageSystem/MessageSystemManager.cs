using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.MessageSystem
{
    public class MessageSystemManager : MonoBehaviour
    {

        public static MessageSystemManager instance;

        private void Awake()
        {
            instance = this;
        }

        [SerializeField] private GameObject _damageMessageGameObject;
        private List<TMPro.TextMeshPro> _messagePool;
        private const int ObjectCount = 10;
        private int _count;

        private void Start()
        {
            _messagePool = new List<TextMeshPro>();
            for (int i = 0; i < ObjectCount; i++)
            {
                Populate();
            }
        }

        private void Populate()
        {
            GameObject gameObject = Instantiate(_damageMessageGameObject, transform);
            if (gameObject.TryGetComponent<TextMeshPro>(out var textMesh))
            {
                _messagePool.Add(textMesh);
            }
            gameObject.SetActive(false);
            
        }

        public void PostMessage(string text, Vector3 wolrdPosition)
        {
            TextMeshPro targetMessage = _messagePool[_count];
            targetMessage.gameObject.SetActive(true);
            targetMessage.transform.position = wolrdPosition;
            targetMessage.text = text;

            _count += 1;
            if (_count >= ObjectCount)
            {
                _count = 0;
            }
        }
    }
}
