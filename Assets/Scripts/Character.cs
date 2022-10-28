using UnityEngine;

namespace Assets.Scripts
{
    public class Character : MonoBehaviour
    {
        public int armor = 0;
        public int maxHp = 1000;
        public int currentHp = 1000;

        [SerializeField] StatusBar hpBar;
        [HideInInspector] public Level level;
        [HideInInspector] public Coins coins;

        private void Awake()
        {
            level = GetComponent<Level>();
            coins = GetComponent<Coins>();
        }

        private void Start()
        {
            hpBar.SetState(currentHp, maxHp);
        }

        public void TakeDamage(int damage)
        {
            if (IsDead())
            {
                return;
            }
            ApplyArmor(ref damage);
            currentHp -= damage;

            if (IsDead())
            {
                GetComponent<CharacterGameOver>().GameOver();
            }
            hpBar.SetState(currentHp, maxHp);
        }

        private bool IsDead()
        {
            return currentHp <= 0;
        }

        private void ApplyArmor(ref int damage)
        {
            damage -= armor;
            if (damage < 0)
            {
                damage = 0;
            }
        }

        public void Heal(int amount)
        {
            if (IsDead()) { return; }
            currentHp += amount;
            if (currentHp > maxHp)
            {
                currentHp = maxHp;
            }
            hpBar.SetState(currentHp, maxHp);
        }
    }
}
