using Modules.Content.Player_Enemy;
using Modules.Core.Gameplay_Phases;
using Modules.Core.Gameplay_Phases.Attack_Phase;
using Modules.Core.Gameplay_Phases.Base_Phase;
using Modules.Core.Gameplay_Phases.Cast_Phase;
using Modules.Core.Gameplay_Phases.Draw_Phase;
using Modules.Core.Gameplay_Phases.Pre_Draw_Phase;
using Modules.Core.Systems.Phase_System;
using Modules.Core.Utils.Coroutine_Runner;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Phase_System_Installer
{
    public class PhaseSystemInstaller : MonoInstaller
    {
        [SerializeField] private LayerMask _playZoneMaskForAttackPhase;
        
        private BasePhase[] _phases;
        
        public override void InstallBindings()
        {
            BindPreDrawPhase();
            
            BindDrawPhase();

            BindCastPhase();

            BindAttackPhase();

            BindPhaseSystem();
        }

        private void BindPhaseSystem()
        {
            var preDrawPhase = Container.Resolve<PreDrawPhase>();
            var drawPhase = Container.Resolve<DrawPhase>();
            var castPhase = Container.Resolve<CastPhase>();
            var attackPhase = Container.Resolve<AttackPhase>();
            var turnOwner = Container.Resolve<ITurnOwner>();
            var runner = Container.Resolve<CoroutineRunner>();

            _phases = new BasePhase[] { preDrawPhase,drawPhase, castPhase, attackPhase , castPhase };

            Container
                .BindInterfacesAndSelfTo<PhaseSystem>()
                .AsSingle()
                .WithArguments(_phases, turnOwner, runner);
        }

        private void BindPreDrawPhase()
        {
            Container
                .BindInterfacesAndSelfTo<PreDrawPhase>()
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

        private void BindAttackPhase()
        {
            Container
                .BindInterfacesAndSelfTo<AttackPhase>()
                .AsSingle()
                .WithArguments(_playZoneMaskForAttackPhase);
        }
    }
}