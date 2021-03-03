using Game.Ui.LocationChoise;
using SimpleUi;
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
        public override void InstallBindings()
        {
            var canvasObj = Instantiate(canvas);
            var canvasTransform = canvasObj.transform;
            var eventSystem = canvasTransform.GetComponentInChildren<EventSystem>();

            Container.Bind<Canvas>().FromInstance(canvasObj).AsSingle().NonLazy();
            Container.Bind<EventSystem>().FromInstance(eventSystem).AsSingle().NonLazy();
           
            Container.BindUiView<LocationChoiseController, LocationChoiseView>(locationChoise, canvasTransform);
        }
    }
}