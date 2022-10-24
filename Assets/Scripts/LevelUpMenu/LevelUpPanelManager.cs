using Assets.Scripts.IngameMenu;
using UnityEngine;

namespace Assets.Scripts.LevelUpMenu
{
    public class LevelUpPanelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _levelUpPanel;
        [SerializeField] private PauseManager _pauseManager;

        public void OpenPanel()
        {
            _pauseManager.PauseGame();
            _levelUpPanel.SetActive(true);
        }

        public void ClosePanel()
        {
            _pauseManager.UnpauseGame();
            _levelUpPanel.SetActive(false);
        }

        private bool IsOpen()
        {
            return _levelUpPanel.activeInHierarchy;
        }

        private void CheckToOpenMenu()
        {
            if (IsOpen() && Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePanel();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenPanel();
            }
        }
    }
}
