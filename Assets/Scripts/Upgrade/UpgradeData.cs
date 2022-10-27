
using UnityEngine;

namespace Assets.Scripts.Upgrade
{
    public enum UpgradeType
    {
        WeaponUpgrade,
        ItemUpgrade
    }

    [CreateAssetMenu]
    public class UpgradeData : PowerUp
    {
        public UpgradeType upgradeType;
    }
}
