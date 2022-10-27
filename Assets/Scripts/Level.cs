using System;
using System.Collections.Generic;
using Assets.Scripts.LevelUpMenu;
using Assets.Scripts.Upgrade;
using Assets.Scripts.Weapons;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] ExperienceBar _experienceBar;
        [SerializeField] LevelUpPanelManager _levelUpPanelManager;
        [SerializeField] private List<PowerUp> _upgradesPool;
        [SerializeField] private WeaponManager _weaponManager;
        private int _level = 1;
        private int _experience = 0;
        private List<PowerUp> _selectedUpgradesToPickUp;
        private List<PowerUp> _acquiredUpgrades;

        private int ToLevelUp() => _level * 1000;

        private void Start()
        {
            _experienceBar.UpdateExperienceSlider(_experience, ToLevelUp());
            _experienceBar.SetLevelText(_level);
        }

        public void AddExperience(int amount)
        {
            _experience += amount;
            CheckLevelUp();
            _experienceBar.UpdateExperienceSlider(_experience, ToLevelUp());
        }

        public void CheckLevelUp()
        {
            if (HasToLevelUp())
            {
                LevelUp();
            }
        }

        private bool HasToLevelUp()
        {
            return _experience >= ToLevelUp();
        }

        private void LevelUp()
        {
            SetRandomUpgradesToPickUp();
            _levelUpPanelManager.OpenPanel(_selectedUpgradesToPickUp);
            _experience -= ToLevelUp();
            _level += 1;
            _experienceBar.SetLevelText(_level);
        }

        private void SetRandomUpgradesToPickUp()
        {
            _selectedUpgradesToPickUp ??= new List<PowerUp>();
            _selectedUpgradesToPickUp.Clear();
            _selectedUpgradesToPickUp.AddRange(GetPowerUps(4));
        }

        public List<PowerUp> GetPowerUps(int count)
        {
            List<PowerUp> upgradeList = new List<PowerUp>();
            if (count > _upgradesPool.Count)
            {
                count = _upgradesPool.Count;
            }
            for (int i = 0; i < count; i++)
            {
                upgradeList.Add(_upgradesPool[Random.Range(0, _upgradesPool.Count)]);
            }
            return upgradeList;
        }

        public void Upgrade(int selectedUpgradeId)
        {
            PowerUp upgradeData = _selectedUpgradesToPickUp[selectedUpgradeId];
            _acquiredUpgrades ??= new List<PowerUp>();

            switch (upgradeData)
            {
                case UpgradeWeapon upgradeWeapon:
                    _weaponManager.UpgradeWeapon(upgradeWeapon);
                    break;
                case UnlockWeapon unlockWeapon:
                    _weaponManager.AddWeapon(unlockWeapon);
                    break;
                default:
                    Debug.Log("oui");
                    break;
            }

            _acquiredUpgrades.Add(upgradeData);
            _upgradesPool.Remove(upgradeData);
        }


        public void AddUpgradesIntoAvailableUpgrades(List<UpgradeWeapon> upgradesToAdd)
        {
            _upgradesPool.AddRange(upgradesToAdd);
        }
    }
}
