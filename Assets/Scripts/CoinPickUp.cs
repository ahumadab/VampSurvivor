using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour, IPickUpObject
{
    [SerializeField] int coinValue;

    public void OnPickUp(Character character)
    {
        character.coins.AddCoin(coinValue);
    }

}
