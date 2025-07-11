using Modules.Core.UI.Views.Mana_View;
using Modules.New;
using Zenject;

namespace Modules.Core.Systems.Mana_System
{
    public class ManaSystem : IManaSystem, IInitializable
    {
        private readonly ManaView _manaView;
        private readonly int MAX_MANA;
        private int _currentMana;

        public int CurrentMana => _currentMana;

        [Inject]
        public ManaSystem(int maxMana, ManaView manaView)
        {
            MAX_MANA = maxMana;

            _manaView = manaView;
        }

        public void Initialize()
        {
            _currentMana = MAX_MANA;
            
            _manaView.UpdateManaText(_currentMana);
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
            
            _manaView.UpdateManaText(_currentMana);
        }

        public void RefillMana()
        {
            _currentMana = MAX_MANA;
            
            _manaView.UpdateManaText(_currentMana);
        }
    }
}