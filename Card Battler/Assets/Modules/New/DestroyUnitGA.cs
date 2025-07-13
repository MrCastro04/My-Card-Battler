using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.New
{
    public class DestroyUnitGA : GameAction
    {
        public readonly CardView Target;

        public DestroyUnitGA(CardView target)
        {
            Target = target;
        }
    }
}