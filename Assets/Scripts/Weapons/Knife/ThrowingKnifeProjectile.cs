using Assets.Scripts.MessageSystem;
using UnityEngine;

namespace Assets.Scripts.Weapons.Knife
{
    public class ThrowingKnifeProjectile : MonoBehaviour
    {

        Vector3 direction;
        [SerializeField] float speed;
        [SerializeField] int damage = 5;


        [SerializeField] int piercingCapacity = 1;
        int enemiesHit = 0;
        [SerializeField] float areaOfEffect = 0.7f;
    


        void Update()
        {
            TravelDistance();

            DealDamageOnHit();
            HandleDestroyOnHit();
        }

        public void SetData(int damage, int piercingCapacity)
        {
            this.damage = damage;
            this.piercingCapacity += piercingCapacity;
        }

        private void HandleDestroyOnHit()
        {
            if (enemiesHit >= piercingCapacity)
            {
                Destroy(gameObject);
            }
        }

        public void SetDirection(float dir_x, float dir_y)
        {
            direction = new Vector3(dir_x, dir_y);
            bool directionIsLeft = dir_x < 0;

            if (directionIsLeft)
            {
                SetDirectionToLeft();
            }
            else
            {
                SetDirectionToRight();
            }
        }

        private void SetDirectionToLeft()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            transform.Rotate(0f, 0f, 135f);
        }

        private void SetDirectionToRight()
        {
            transform.Rotate(0f, 0f, -135f);
        }

        private void DealDamageOnHit()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, areaOfEffect);
            foreach (Collider2D hit in hits)
            {
                if (hit.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(damage);
                    enemiesHit++;
                    MessageSystemManager.instance.PostMessage(damage.ToString(), enemy.transform.position);
                    break;
                }
            }
        }

        private void TravelDistance()
        {
            transform.position += speed * Time.deltaTime * direction;
        }
    }
}
