using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MainMenu.Buttons
{
    public class StartGame : MonoBehaviour
    {
        public void StartGameplay(string stageToPlay)
        {
            SceneManager.LoadScene("Essential", LoadSceneMode.Single);
            SceneManager.LoadScene(stageToPlay, LoadSceneMode.Additive);
        }
    }
}
