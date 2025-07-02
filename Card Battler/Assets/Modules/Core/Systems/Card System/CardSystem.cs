using System;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Card_System.Sub_Systems.Draw_Card_System;
using Modules.New;
using Zenject;

namespace Modules.Core.Systems.Card_System
{
    public sealed class CardSystem : IInitializable, IDisposable
    {
        private readonly ActionSystem _actionSystem;
        private readonly IDrawCardSystem _drawCardSystem;
        private readonly IDiscardCardSystem _discardCardSystem;

        [Inject]
        public CardSystem( ActionSystem actionSystem, IDrawCardSystem drawCardSystem , IDiscardCardSystem discardCardSystem )
        {
            _actionSystem = actionSystem; 
            _drawCardSystem = drawCardSystem;
            _discardCardSystem = discardCardSystem;
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<DrawCardsGA>(_drawCardSystem.DrawCardsPerformer);
            _actionSystem.AttachPerformer<DiscardCardsGA>(_discardCardSystem.DiscardCardPerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<DrawCardsGA>();
            _actionSystem.DetachPerformer<DiscardCardsGA>();
        }
    }
}