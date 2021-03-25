using ECS.DataSave;
using ECS.Utils.Impls;
using Game.Ui.InGameMenu;
using Game.Ui.LocationChoise;
using Game.Utils.MonoBehUtils;
using Initializers;
using PdUtils;
using Services.AI.Impl;
using Services.Input.Impls;
using Services.PauseService;
using Services.PauseService.Impls;
using UnityEngine;
using Utils.SeparateThreadExecutor.Impl;
using Utils.ThreadLocalStorage;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GetPointFromScene _getPointFromScene;
        public override void InstallBindings()
        {
            BindWindows();
            BindServices();
            BindMemoryPools();
            
            Container.BindInterfacesAndSelfTo<GetPointFromScene>().FromInstance(_getPointFromScene).AsSingle();
            Container.BindInterfacesAndSelfTo<GameInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameInputCallbackReceiver>().AsSingle();
            Container.BindInterfacesTo<ThreadedLocalStorageDao<GeneralState>>()
                .AsTransient().WithArguments("gameState");
            Container.BindInterfacesTo<DefaultSeparateThreadExecutor<string>>().AsSingle();
            Container.BindInterfacesTo<DefaultSeparateThreadExecutor>().AsSingle();
            Container.BindInterfacesTo<DefaultSeparateThreadExecutor<DataPool>>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<LocationChoiseWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<InGameMenuWindow>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SpawnService>().AsSingle();
            Container.BindInterfacesTo<PauseService>().AsSingle();
            Container.BindInterfacesTo<PathCalculator>().AsSingle();
        }

        private void BindMemoryPools()
        {
            Container.BindMemoryPoolCustomInterface<GeneralState, GeneralStatePool, IMemoryPool<GeneralState>>();
        }
    }
}