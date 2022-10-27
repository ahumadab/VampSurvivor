using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Upgrade
{
    public enum UnlockType
    {
        WeaponUnlock,
        ItemUnlock
    }
    
    public class UnlockData : PowerUp
    {
        public UnlockType upgradeType;
    }

    
}
