using Game.Ui.InGameMenu;
using Game.Ui.LocationChoise;
using SimpleUi;
using Tests;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/GameUiPrefabInstaller", fileName = "GameUiPrefabInstaller")]
    public class GameUiPrefabInstaller : ScriptableObjectInstaller
    {

        [FormerlySerializedAs("Canvas"), SerializeField]
        private Canvas canvas;
        [SerializeField] private LocationChoiseView locationChoise;
        [SerializeField] private InGameMenuView inGameMenu;
        [SerializeField] private DebugView debug;
        public override void InstallBindings()
        {
            var canvasObj = Instantiate(canvas);
            var canvasTransform = canvasObj.transform;
            var eventSystem = canvasTransform.GetComponentInChildren<EventSystem>();

            Container.Bind<Canvas>().FromInstance(canvasObj).AsSingle().NonLazy();
            Container.Bind<EventSystem>().FromInstance(eventSystem).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<DebugView>()
                .FromComponentInNewPrefab(debug)
                .UnderTransform(canvasTransform).AsSingle();
            
            Container.BindUiView<LocationChoiseController, LocationChoiseView>(locationChoise, canvasTransform);
            Container.BindUiView<InGameMenuViewController, InGameMenuView>(inGameMenu, canvasTransform);
        }
    }
}