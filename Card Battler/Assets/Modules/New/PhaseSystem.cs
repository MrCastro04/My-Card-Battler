using System.Collections;
using Modules.Core.Utils.Coroutine_Runner;
using Zenject;


namespace Modules.New
{
    public class PhaseSystem : IInitializable
    {
        private readonly BasePhase[] _phases;
        private readonly ITurnOwner _turnOwner;
        private readonly CoroutineRunner _coroutineRunner;
        private BasePhase _currentPhase;

        [Inject]
        public PhaseSystem(BasePhase[] phases, ITurnOwner turnOwner, CoroutineRunner coroutineRunner)
        {
            _phases = phases;
            
            _turnOwner = turnOwner;

            _coroutineRunner = coroutineRunner;
        }

        public void Initialize()
        {
            _coroutineRunner.Run(PhasesFlow(_turnOwner));
        }

        private IEnumerator PhasesFlow(ITurnOwner turnOwner)
        {
            for (int i = 0; i < _phases.Length; i++)
            {
                _currentPhase = _phases[i];
                
                yield return ExecutePhase(turnOwner);
            }
        }

        private IEnumerator ExecutePhase(ITurnOwner turnOwner)
        {
            yield return _currentPhase.Enter(turnOwner);
        }
    }
}