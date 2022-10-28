using System.Collections.Generic;
using Assets.Scripts.Upgrade;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Transform _weaponObjectsContainer;
        [SerializeField] private UnlockWeapon _startingWeapon;
        [SerializeField] private Level _levelManager;
        private List<WeaponBase> _weapons;

        private void Awake()
        {
            _weapons = new List<WeaponBase>();
        }

        private void Start()
        {
            AddWeapon(_startingWeapon);
        }

        public void AddWeapon(UnlockWeapon unlockedWeapon)
        {
            GameObject weaponGameObject = Instantiate(unlockedWeapon.weaponData.weaponBasePrefab, _weaponObjectsContainer);
            if (weaponGameObject.TryGetComponent<WeaponBase>(out var weaponBase))
            {
                _weapons.Add(weaponBase);
                weaponBase.SetData(unlockedWeapon.weaponData);

            }

            weaponBase.WeaponData.Init();
            AddNextUpgradeToUpgradePool(unlockedWeapon.weaponData);
        }

        private void AddNextUpgradeToUpgradePool(WeaponData unlockedWeapon)
        {
            if (unlockedWeapon.TryGetNextUpgrade(out var nextUpgrade))
            {
                _levelManager.AddUpgradesIntoAvailableUpgrades(nextUpgrade);
            }
        }

        public void UpgradeWeapon(UpgradeWeapon upgradeData)
        {
            WeaponBase weaponToUpgrade = _weapons.Find((wb) => wb.WeaponData == upgradeData.weaponData);
            weaponToUpgrade.Upgrade(upgradeData);
            AddNextUpgradeToUpgradePool(weaponToUpgrade.WeaponData);
        }
    }
}
