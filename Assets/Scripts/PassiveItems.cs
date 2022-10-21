using System.Collections.Generic;
using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts
{
    public class PassiveItems : MonoBehaviour
    {
        [SerializeField] List<Item> items;
        Character character;
        [SerializeField] Item armorTest;

        private void Awake()
        {
            character = GetComponent<Character>();
        }

        private void Start()
        {
            Equip(armorTest);
        }

        public void Equip(Item itemToEquip)
        {
            if (items == null)
            {
                items = new List<Item>();
            }
            items.Add(itemToEquip);
            itemToEquip.Equip(character);
        }
        public void UnEquip(Item itemToUnEquip)
        {

        }


    }
}
