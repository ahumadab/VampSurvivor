using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Upgrade
{
    [CreateAssetMenu]
    public class UpgradeWeapon : UpgradeData
    {
        public WeaponStats weaponUpgradeStats;
        public WeaponData weaponData;
    }
}
