using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterGameOver : MonoBehaviour
    {

        public GameObject gameOverPanel;


        public void GameOver()
        {
            Debug.Log("GameOver");
            GetComponent<PlayerMove>().enabled = false; 
            gameOverPanel.SetActive(true);
        }
    }
}
