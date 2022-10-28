using System.Collections.Generic;
using Assets.Scripts.Upgrade;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [CreateAssetMenu]
    public class WeaponData : ScriptableObject
    {
        public string Name;
        private int _level;
        public WeaponStats stats;
        public GameObject weaponBasePrefab;
        public List<UpgradeWeapon> upgrades;


        public void Init()
        {
            _level = 0;
        }

        public bool TryGetNextUpgrade(out UpgradeWeapon nextUpgradeWeapon)
        {
            if (IsUpgradeAvailable())
            {
                nextUpgradeWeapon = upgrades[_level];
                _level++;
                return true;
            }
            _level++;
            nextUpgradeWeapon = null;
            return false;
        }

        private bool IsUpgradeAvailable()
        {
            return _level < upgrades.Count;
        }
    }
}
   

