using System;

namespace Assets.Scripts.Weapons
{
    [Serializable]
    public class WeaponStats
    {
        public int damage;
        public float timeToAttack;
        public int piercingPower;

        public WeaponStats(int damage, float timeToAttack, int piercingPower)
        {
            this.damage = damage;
            this.timeToAttack = timeToAttack;
            this.piercingPower = piercingPower; ; 
        }

        public void AddStats(WeaponStats weaponUpgradeStats)
        {
            damage += weaponUpgradeStats.damage;
            timeToAttack += weaponUpgradeStats.timeToAttack;
            piercingPower += weaponUpgradeStats.piercingPower;
        }
    }
}
