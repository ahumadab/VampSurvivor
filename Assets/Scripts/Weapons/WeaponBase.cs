using Assets.Scripts.MessageSystem;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {
        private WeaponData _weaponData;
        protected WeaponStats weaponStats;
        private float _timeToAttack = 1f;
        private float _timer;


        protected void Update()
        {
            ProcessCooldown();
            if (!IsTimeToAttack()) return;
            Attack();
            ResetCooldown();
        }

        private void ResetCooldown()
        {
            _timer = _timeToAttack;
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
            _timeToAttack = weaponData.stats.timeToAttack;
            weaponStats = new WeaponStats(weaponData.stats.damage, weaponData.stats.timeToAttack);
        }

        public abstract void Attack();

        public virtual void PostDamage(int damage, Vector3 targetPosition)
        {
            MessageSystemManager.instance.PostMessage(damage.ToString(), targetPosition);
        }

    }

}
