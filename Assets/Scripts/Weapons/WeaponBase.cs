using Assets.Scripts.MessageSystem;
using Assets.Scripts.Upgrade;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {
        private WeaponData _weaponData;
        protected WeaponStats weaponStats;
        private float _timer;

        public WeaponData WeaponData { get => _weaponData; }

        protected void Update()
        {
            ProcessCooldown();
            if (!IsTimeToAttack()) return;
            Attack();
            ResetCooldown();
        }

        private void ResetCooldown()
        {
            _timer = weaponStats.timeToAttack;
        }

        private void ProcessCooldown()
        {
            _timer -= Time.deltaTime;
        }

        private bool IsTimeToAttack()
        {
            return _timer < 0f;
        }

        public virtual void SetData(WeaponData weaponData)
        {
            _weaponData = weaponData;
            weaponStats = new WeaponStats(weaponData.stats.damage, weaponData.stats.timeToAttack, weaponData.stats.piercingPower);
        }

        public abstract void Attack();

        public virtual void PostDamage(int damage, Vector3 targetPosition)
        {
            MessageSystemManager.instance.PostMessage(damage.ToString(), targetPosition);
        }

        public void Upgrade(UpgradeWeapon upgradeData)
        {
            weaponStats.AddStats(upgradeData.weaponUpgradeStats);
        }
    }

}
