using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Transform _weaponObjectsContainer;
        [SerializeField] private WeaponData _startingWeapon;

        private void Start()
        {
            AddWeapon(_startingWeapon);
        }

        public void AddWeapon(WeaponData weaponData)
        {
            GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, _weaponObjectsContainer);
            weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);
        }
    }
}
