using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ExperienceBar : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] TMPro.TextMeshProUGUI levelText;

        public void UpdateExperienceSlider(int current, int target)
        {
            slider.maxValue = target;
            slider.value = current;
        }

        public void SetLevelText(int level)
        {
            levelText.text = "LEVEL: " + level.ToString();
        }
    }
}
