using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ExitToMenu : MonoBehaviour
    {
        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
