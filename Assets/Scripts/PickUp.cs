using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{
    public class PickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Character character = collision.GetComponent<Character>();
            if (character != null)
            {
                GetComponent<IPickUpObject>().OnPickUp(character);
                Destroy(gameObject);
            }
        }
    }
}
