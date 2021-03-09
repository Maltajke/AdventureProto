using ECS.Utils.Impls;
using Game.Ui.InGameMenu;
using Game.Ui.LocationChoise;
using Game.Utils.MonoBehUtils;
using Initializers;
using Services.Input.Impls;
using Services.PauseService;
using Services.PauseService.Impls;
using UnityEngine;
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
            Container.BindInterfacesAndSelfTo<GetPointFromScene>().FromInstance(_getPointFromScene).AsSingle();
            Container.BindInterfacesAndSelfTo<GameInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameInputCallbackReceiver>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<LocationChoiseWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<InGameMenuWindow>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SpawnService>().AsSingle();
            Container.BindSubstituteInterfacesTo<IPauseService, PauseService>().AsSingle();
        }
    }
}