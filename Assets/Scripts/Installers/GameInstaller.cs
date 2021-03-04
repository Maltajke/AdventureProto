using ECS.Utils.Impls;
using Game.Ui.InGameMenu;
using Game.Ui.LocationChoise;
using Game.Utils.MonoBehUtils;
using Initializers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GetPointFromScene _getPointFromScene;
        private string SceneName => SceneManager.GetActiveScene().name;
        public override void InstallBindings()
        {
            BindWindows();
            BindServices();
            Container.BindInterfacesAndSelfTo<GetPointFromScene>().FromInstance(_getPointFromScene).AsSingle();
            Container.BindInterfacesAndSelfTo<GameInitializer>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<LocationChoiseWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<InGameMenuWindow>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SpawnService>().AsSingle();
        }
    }
}