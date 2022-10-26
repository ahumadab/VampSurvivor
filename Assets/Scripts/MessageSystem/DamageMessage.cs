using UnityEngine;

namespace Assets.Scripts.MessageSystem
{
    public class DamageMessage : MonoBehaviour
    {
        [SerializeField] private float _timeToDisappear = 1f;

        private void Update()
        {
            CheckToDisappear();
        }

        private void CheckToDisappear()
        {
            _timeToDisappear -= Time.deltaTime;
            if (_timeToDisappear < 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
