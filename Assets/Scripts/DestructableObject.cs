using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{
    public class DestructableObject : MonoBehaviour, IDamageable
    {
        public void TakeDamage(int damageAmount)
        {
            Destroy(gameObject);
            GetComponent<DropOnDestroy>().CheckDrop();
        }
    }
}
