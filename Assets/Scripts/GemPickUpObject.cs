using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{
    public class GemPickUpObject : MonoBehaviour, IPickUpObject
    {
        [SerializeField] int xpAmount;
        public void OnPickUp(Character character)
        {
            character.level.AddExperience(xpAmount);
        }
    }
}
