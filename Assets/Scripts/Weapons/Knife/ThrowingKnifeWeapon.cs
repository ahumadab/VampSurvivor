using UnityEngine;

namespace Assets.Scripts.Weapons.Knife
{
    public class ThrowingKnifeWeapon : WeaponBase
    {
        [SerializeField] private GameObject _knifeProjectilePrefab;
        private PlayerMove _playerMove;

        private void Awake()
        {
            _playerMove = GetComponentInParent<PlayerMove>();
        }
        public override void Attack()
        {
            GameObject thrownKnifeProjectile = Instantiate(_knifeProjectilePrefab);
            thrownKnifeProjectile.transform.position = transform.position;
            if (thrownKnifeProjectile.TryGetComponent<ThrowingKnifeProjectile>(out var throwingKnifeProjectile))
            {
                throwingKnifeProjectile.SetDirection(_playerMove.lastHorizontalVector, 0f);
            }
        }
    }
}
