namespace Modules.New
{
    public interface IManaSystem
    {
        int CurrentMana { get; }
        bool IsManaEnough(int spendingMana);
        void SpendMana(int spendingMana);
        void RefillMana();
    }
}