using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] int xpAmount;
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(xpAmount);
    }
}
