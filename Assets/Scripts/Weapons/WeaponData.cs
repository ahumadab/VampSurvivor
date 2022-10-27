using System.Collections.Generic;
using Assets.Scripts.Upgrade;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [CreateAssetMenu]
    public class WeaponData : ScriptableObject
    {
        public string Name;
        public int level;
        public WeaponStats stats;
        public GameObject weaponBasePrefab;
        public List<UpgradeWeapon> upgrades;
    }
}
   

