using Assets.Scripts.Behaviours;

namespace Assets.Scripts
{
    public class Health
    {
        private int currentHealth;
        private int maxHealth;
        private readonly DyingBehaviour target;

        public Health(int currentHealth, int maxHealth, DyingBehaviour target)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
            this.target = target;
        }

        public int CurrentHealth { get { return currentHealth; } }

        public int MaxHealth { get { return maxHealth; } }

        public void TakeDamage(int damageTaken)
        {
            currentHealth -= damageTaken;
            if (IsDead())
            {
                target.Die();
            }
        }

        public void Heal(int healAmout)
        {
            if (!IsDead())
            {
                int newHealth = currentHealth + healAmout;
                if (newHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                else
                {
                    currentHealth += newHealth;
                }
            }
        }

        private bool IsDead()
        {
            return currentHealth <= 0;
        }
    }
}
