using System.Collections.Generic;
using Assets.Scripts.Game;
using Assets.Scripts.IngameMenu;
using Assets.Scripts.Upgrade;
using UnityEngine;

namespace Assets.Scripts.LevelUpMenu
{
    public class LevelUpPanelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _levelUpPanel;
        [SerializeField] private PauseManager _pauseManager;
        [SerializeField] private List<UpgradeButton> _upgradeButtons;

        private void Start()
        {
            HideButtons();
        }

        public void OpenPanel(List<PowerUp> upgradeDataList)
        {
            Clean();
            _pauseManager.PauseGame();
            _levelUpPanel.SetActive(true);
            SetDataToButtons(upgradeDataList);
        }

        public void Upgrade(int pressedButtonIdD)
        {
            if (GameManager.instance.playerTransform.TryGetComponent<Level>(out var levelComponent))
            {
                levelComponent.Upgrade(pressedButtonIdD);
            }

            ClosePanel();
        }

        public void Clean()
        {
            foreach (var upgradeButton in _upgradeButtons)
            {
                upgradeButton.Clean();
            }
        }

        private void ClosePanel()
        {
            HideButtons();
            _pauseManager.UnpauseGame();
            _levelUpPanel.SetActive(false);
        }

        private void HideButtons()
        {
            foreach (var upgradeButton in _upgradeButtons)
            {
                upgradeButton.gameObject.SetActive(false);
            }
        }

        private void SetDataToButtons(IReadOnlyList<PowerUp> upgradeDataList)
        {
            for (int i = 0; i < upgradeDataList.Count; i++)
            {
                UpgradeButton upgradeButton = _upgradeButtons[i];
                PowerUp upgradeData = upgradeDataList[i];
                upgradeButton.gameObject.SetActive(true);
                upgradeButton.Set(upgradeData);
            }
        }



    }
}
