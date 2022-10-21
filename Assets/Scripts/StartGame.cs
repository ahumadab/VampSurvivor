using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StartGame : MonoBehaviour
    {
        public void StartGameplay()
        {
            SceneManager.LoadScene("GameplayStage");
        }
    }
}
