
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

             var drawPhase = Container.Resolve<DrawPhase>();
             var turnOwner = Container.Resolve<ITurnOwner>();
             var runner = Container.Resolve<CoroutineRunner>();

             _phases = new BasePhase[] {drawPhase};
             
             Container
                 .Bind<PhaseSystem>()
                 .FromInstance(new PhaseSystem(_phases, turnOwner, runner))
                 .AsSingle();

         }
    }
}