using UnityEngine;

namespace Assets.Scripts.MainMenu.Buttons
{
    public class ExitButton : MonoBehaviour
    {
        public void QuitApplication()
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }
}
