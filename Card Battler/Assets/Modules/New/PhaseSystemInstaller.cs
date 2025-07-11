
using Modules.Core.Utils.Coroutine_Runner;
using Modules.New;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Turn_System_Installer
{
    public class PhaseSystemInstaller : MonoInstaller
    {
        private BasePhase[] _phases;
        
        public override void InstallBindings()
         {
             Container
                 .BindInterfacesAndSelfTo<DrawPhase>()
                 .AsSingle();

             var drawPhaseResolve = Container.Resolve<DrawPhase>();
             var turnOwnerResolve = Container.Resolve<ITurnOwner>();
             var runnerResolve = Container.Resolve<CoroutineRunner>();

             _phases = new BasePhase[] {drawPhaseResolve};
             
             Container
                 .BindInterfacesAndSelfTo<PhaseSystem>()
                 .FromInstance(new PhaseSystem(_phases, turnOwnerResolve, runnerResolve))
                 .AsSingle();
         }
    }
}