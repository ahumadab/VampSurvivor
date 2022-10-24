using UnityEngine;

namespace Assets.Scripts.IngameMenu
{
    public class IngameMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private PauseManager _pauseManager;

        private void Update()
        {
            CheckToOpenMenu();
        }
        private void OpenMenu()
        {
            _pauseManager.PauseGame();
            _panel.SetActive(true);
        }

        public void CloseMenu()
        {
            _pauseManager.UnpauseGame();
            _panel.SetActive(false);
        }

        private bool IsOpen()
        {
            return _panel.activeInHierarchy;
        }

        private void CheckToOpenMenu()
        {
            if (IsOpen() && Input.GetKeyDown(KeyCode.Escape))
            {
                CloseMenu();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenMenu();
            }
        }
    }
}
