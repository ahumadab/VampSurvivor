using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WhipWeapon : WeaponBase
    {
        [SerializeField] GameObject leftWhipObject;
        [SerializeField] GameObject rightWhipObject;
        PlayerMove playerMove;
        [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);

        private void Awake()
        {
            playerMove = GetComponentInParent<PlayerMove>();
        }


        private void ApplyDamage(Collider2D[] colliders)
        {
            foreach (var collider2D1 in colliders)
            {
                if (!collider2D1.TryGetComponent<IDamageable>(out var target)) continue;
                PostDamage(weaponStats.damage, collider2D1.transform.position);
                target.TakeDamage(weaponStats.damage);
            }
        }

        public override void Attack()
        {

            if (NextAttackIsRight())
            {
                AttackRightSide();
            }
            else
            {
                AttackLeftSide();
            }
        }

        private void AttackLeftSide()
        {
            AttackToSide(false);
        }

        private void AttackRightSide()
        {
            AttackToSide(true);
        }

        private void AttackToSide(bool rightSide = true)
        {
            GameObject whipObject = rightSide ? rightWhipObject : leftWhipObject;
            whipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(whipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }

        private bool NextAttackIsRight()
        {
            return playerMove.lastHorizontalVector > 0;
        }
    }
}
