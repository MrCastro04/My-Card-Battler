namespace Modules.Core.Systems.Mana_System
{
    public interface IManaSystem
    {
        int CurrentMana { get; }
        bool IsManaEnough(int spendingMana);
        void SpendMana(int spendingMana);
        void RefillMana();
    }
}