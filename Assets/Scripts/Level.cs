using Assets.Scripts.LevelUpMenu;
using UnityEngine;

namespace Assets.Scripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] ExperienceBar _experienceBar;
        [SerializeField] LevelUpPanelManager _levelUpPanelManager;
        private int _level = 1;
        private int _experience = 0;
        

        private int ToLevelUp() => _level * 1000;

        private void Start()
        {
            _experienceBar.UpdateExperienceSlider(_experience, ToLevelUp());
            _experienceBar.SetLevelText(_level);
        }

        public void AddExperience(int amount)
        {
            _experience += amount;
            CheckLevelUp();
            _experienceBar.UpdateExperienceSlider(_experience, ToLevelUp());
        }

        public void CheckLevelUp()
        {
            if (HasToLevelUp())
            {
                LevelUp();
            }
        }

        private bool HasToLevelUp()
        {
            return _experience >= ToLevelUp();
        }

        private void LevelUp()
        {
            _levelUpPanelManager.OpenPanel();
            _experience -= ToLevelUp();
            _level += 1;
            _experienceBar.SetLevelText(_level);
        }
    }
}
