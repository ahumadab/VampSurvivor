using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealPickUpObject : MonoBehaviour, IPickUpObject
    {
        [SerializeField] int healAmount;
        public void OnPickUp(Character character)
        {
            character.Heal(healAmount);
        }

    }
}
