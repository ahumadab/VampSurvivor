using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Assets.Scripts.Upgrade
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        public void Set(PowerUp upgradeData)
        {
            _icon.sprite = upgradeData.icon;
        }

        public void Clean()
        {
            _icon.sprite = null;
        }
    }
}
