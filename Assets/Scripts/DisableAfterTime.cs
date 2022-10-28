using UnityEngine;

namespace Assets.Scripts
{
    public class DisableAfterTime : MonoBehaviour
    {
        float timeToDisable = 0.2f;
        float timer;

        private void OnEnable()
        {
            timer = timeToDisable;
        }

        private void LateUpdate()
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
