using Game.Ui.BlackScreen;
using SimpleUi;
using Tayx.Graphy;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/ProjectUiPrefabInstaller", fileName = "ProjectUiPrefabInstaller")]
    public class ProjectUiPrefabInstaller : ScriptableObjectInstaller
    {
        [FormerlySerializedAs("Canvas"), SerializeField]
        private Canvas canvas;

        [SerializeField] private BlackScreenView blackScreen;
        
        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            var camera = canvasTransform.GetComponentInChildren<Camera>();
            camera.depth = 0;
            Container.BindUiView<BlackScreenViewController, BlackScreenView>(blackScreen, canvasTransform);
        }
    }
}