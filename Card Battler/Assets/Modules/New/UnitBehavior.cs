using Modules.Content.Card.Scripts;
using Modules.Core.Utils.Mono_Destroyer;

namespace Modules.New
{
    public class UnitBehavior
    {
        private int _maxHealth;
        private int _maxDamage;
        private int _currentHealth;
        private int _currentDamage;

        public int CurrentHealth => _currentHealth;
        public int CurrentDamage => _currentDamage;

        public UnitBehavior(int maxHealth, int maxDamage)
        {
            _maxHealth = maxHealth;
            _maxDamage = maxDamage;

            _currentHealth = _maxHealth;
            _currentDamage = _maxDamage;
        }

        public void GetDamage(int damageAmount)
        {
            _currentHealth -= damageAmount; 
        }

        public bool IsUnitDead()
        {
            if (_currentHealth <= 0)
            {
                return true;
            }

            return false;
        }
    }
}