using Assets.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Scripts
{
    public class CoinPickUp : MonoBehaviour, IPickUpObject
    {
        [SerializeField] int coinValue;

        public void OnPickUp(Character character)
        {
            character.coins.AddCoin(coinValue);
        }

    }
}
