using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class PauseManager : MonoBehaviour
    {
        public void Start()
        {
            Time.timeScale = 1f;
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1f;
        }
    }
}
