using System.Collections;
using Modules.Core.Utils.Coroutine_Runner;
using UnityEngine;
using Zenject;


namespace Modules.New
{
    public class PhaseSystem 
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
            
            _coroutineRunner.Run(PhasesFlow(_turnOwner));
        }
        
        private IEnumerator PhasesFlow(ITurnOwner turnOwner)
        {
            _currentPhase = _phases[0];
            
            yield return ExecutePhase(turnOwner);
            Debug.Log("ГЛАВНЫЙ ПОТОК DRAW PHASE закончилась");
            
            /*_currentPhase = _phases[1];
            yield return ExecutePhase(turnOwner);*/
            
            yield return new WaitForSeconds(5f);
            
            Debug.Log("прошло 5 секунд");
            
            yield return new WaitForSeconds(5f);
            
            Debug.Log("прошло 5 секунд");

        }
        
        private IEnumerator ExecutePhase(ITurnOwner turnOwner)
        {
            yield return _currentPhase.Enter(turnOwner);
        }

        private void ChangePhase(int phaseOrderNumber)
        {
            _currentPhase = _phases[phaseOrderNumber];
        }
    }
}