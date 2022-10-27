using System;

namespace Assets.Scripts.Weapons
{
    [Serializable]
    public class WeaponStats
    {
        public int damage;
        public float timeToAttack;
        public int piercingPower;

        public WeaponStats(int damage, float timeToAttack)
        {
            this.damage = damage;
            this.timeToAttack = timeToAttack;
        }

        public void Sum(WeaponStats weaponUpgradeStats)
        {
            damage += weaponUpgradeStats.damage;
            timeToAttack += weaponUpgradeStats.timeToAttack;
        }
    }
}
