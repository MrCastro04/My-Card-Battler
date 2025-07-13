using Modules.Core.Systems.Phase_System;
using UnityEngine;
using Zenject;

namespace Modules.Core.UI.Canvas.Go_To_Next_Phase_Button
{
    public class GoToNextPhaseButton : MonoBehaviour
    {
        private PhaseSystem _phaseSystem;
    
        [Inject]
        private void Construct(PhaseSystem phaseSystem)
        {
            _phaseSystem = phaseSystem;
        }

        public void OnClick()
        {
            _phaseSystem.RequestNextPhase();
        }
    }
}
