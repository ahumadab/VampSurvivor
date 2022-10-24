using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _weapons;
        public GameObject gameOverPanel;



        public void GameOver()
        {
            Debug.Log("GameOver");
            GetComponent<PlayerMove>().enabled = false; 
            gameOverPanel.SetActive(true);
            _weapons.SetActive(false);
        }
    }
}
