using Game.Ui.LocationChoise;
using Game.Ui.MainMenu;
using SimpleUi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/MenuUiPrefabInstaller", fileName = "MenuUiPrefabInstaller")]
    public class MenuUiPrefabInstaller : ScriptableObjectInstaller
    {
        [FormerlySerializedAs("Canvas"), SerializeField]
        private Canvas canvas;
        [SerializeField] private MainMenuView mainMenu;
        public override void InstallBindings()
        {
            var canvasObj = Instantiate(canvas);
            var canvasTransform = canvasObj.transform;
            var eventSystem = canvasTransform.GetComponentInChildren<EventSystem>();
            canvasObj.gameObject.AddComponent<AudioListener>();
            Container.Bind<Canvas>().FromInstance(canvasObj).AsSingle().NonLazy();
            Container.Bind<EventSystem>().FromInstance(eventSystem).AsSingle().NonLazy();
           
            Container.BindUiView<MainMenuViewController, MainMenuView>(mainMenu, canvasTransform); 
        }
    }
}