using System;
using System.Collections;
using Modules.Core.Game_Actions.Destroy_Unit_GA;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Utils.Mono_Destroyer;
using Zenject;

namespace Modules.Core.Systems.Destroy_Unit_System
{
    public class DestroyUnitSystem : IInitializable , IDisposable
    {
        private readonly ActionSystem _actionSystem;
        private readonly MonoDestroyer _monoDestroyer;
        
        [Inject]
        public DestroyUnitSystem(ActionSystem actionSystem, MonoDestroyer monoDestroyer)
        {
            _actionSystem = actionSystem;

            _monoDestroyer = monoDestroyer;
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<DestroyUnitGA>(DestroyUnitPerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<DestroyUnitGA>();
        }

        private IEnumerator DestroyUnitPerformer(DestroyUnitGA destroyUnitGa)
        {
            _monoDestroyer.Kill(destroyUnitGa.Target.gameObject);

            yield return null;
        }
    }
}