using UnityEngine;

namespace Assets.Scripts
{
    public class Coins : MonoBehaviour
    {
        public int coinsAcquired;
        [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

        private void Start()
        {
            coinsCountText.text = "Coins: " + coinsAcquired.ToString();
        }

        public void AddCoin(int coinsAmount)
        {
            coinsAcquired += coinsAmount;
            coinsCountText.text = "Coins: " + coinsAcquired.ToString();
        }

    }
}
