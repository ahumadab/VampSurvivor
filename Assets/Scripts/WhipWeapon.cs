using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{
    public class WhipWeapon : MonoBehaviour
    {
        [SerializeField] float timeToAttack = 4f;
        float timer;

        [SerializeField] GameObject leftWhipObject;
        [SerializeField] GameObject rightWhipObject;

        PlayerMove playerMove;
        [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
        [SerializeField] int whipDamage = 10;

        private void Awake()
        {
            playerMove = GetComponentInParent<PlayerMove>();
        }
        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                Attack();
            }
        }

        private void Attack()
        {
            timer = timeToAttack;

            if (playerMove.lastHorizontalVector > 0)
            {
                rightWhipObject.SetActive(true);
                Collider2D[] colliders =  Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
                ApplyDamage(colliders);
            } else
            {
                leftWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
                ApplyDamage(colliders);
            }
        }

        private void ApplyDamage(Collider2D[] colliders)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                IDamageable target = colliders[i].GetComponent<IDamageable>();
                if (target != null)
                {
                    target.TakeDamage(whipDamage);
                }
            }
        }
    }
}
