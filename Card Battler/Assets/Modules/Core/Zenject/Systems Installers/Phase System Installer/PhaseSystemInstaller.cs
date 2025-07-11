using Modules.Content.Player_Enemy;
using Modules.Core.Gameplay_Phases;
using Modules.Core.Systems.Phase_System;
using Modules.Core.Utils.Coroutine_Runner;
using Modules.New;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Phase_System_Installer
{
    public class PhaseSystemInstaller : MonoInstaller
    {
        private BasePhase[] _phases;
        
        public override void InstallBindings()
        {
            BindDrawPhase();

            BindCastPhase();

            BindPhaseSystem();
        }

        private void BindPhaseSystem()
        {
            var drawPhaseResolve = Container.Resolve<DrawPhase>();
            var castPhaseResolve = Container.Resolve<CastPhase>();
            var turnOwnerResolve = Container.Resolve<ITurnOwner>();
            var runnerResolve = Container.Resolve<CoroutineRunner>();

            _phases = new BasePhase[] {drawPhaseResolve, castPhaseResolve};

            Container
                .BindInterfacesAndSelfTo<PhaseSystem>()
                .FromInstance(new PhaseSystem(_phases, turnOwnerResolve, runnerResolve))
                .AsSingle();
        }

        private void BindDrawPhase()
        {
            Container
                .BindInterfacesAndSelfTo<DrawPhase>()
                .AsSingle();
        }

        private void BindCastPhase()
        {
            Container
                .BindInterfacesAndSelfTo<CastPhase>()
                .AsSingle();
        }
    }
}