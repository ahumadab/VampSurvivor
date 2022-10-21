using UnityEngine;

namespace Assets.Scripts
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
