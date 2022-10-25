using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [CreateAssetMenu]
    public class WeaponData : ScriptableObject
    {
        public string Name;
        public WeaponStats stats;
        public GameObject weaponBasePrefab;
    }
}
   

