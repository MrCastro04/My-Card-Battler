using Modules.New;
using Zenject;

namespace Modules.Core.Systems.Mana_System
{
    public class ManaSystem : IManaSystem
    {
        private readonly int MAX_MANA;
        private int _currentMana;

        public int CurrentMana => _currentMana;

        [Inject]
        public ManaSystem(int maxMana)
        {
            MAX_MANA = maxMana;

            _currentMana = MAX_MANA;
        }

        public bool IsManaEnough(int spendingMana)
        {
            if (spendingMana > _currentMana)
                return false;

            return true;
        }

        public void SpendMana(int spendingMana)
        {
            _currentMana -= spendingMana;
        }

        public void RefillMana()
        {
            _currentMana = MAX_MANA;
        }
    }
}