using Game.SceneLoading;
using Game.Ui.BlackScreen;
using Services.Input;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Game.Ui.InGameMenu
{
    public class InGameMenuViewController : UiController<InGameMenuView>, IInitializable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly SignalBus _signalBus;
        private readonly IInputManager _inputManager;

        public InGameMenuViewController(ISceneLoadingManager sceneLoadingManager, SignalBus signalBus, IInputManager inputManager)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _signalBus = signalBus;
            _inputManager = inputManager;
        }
        
        public void Initialize()
        {
            View.GoMenu.OnClickAsObservable().Subscribe(x => OnGoMenu()).AddTo(View.GoMenu);
            View.Continue.OnClickAsObservable().Subscribe(x => OnContinue()).AddTo(View.Continue);
        }

        public override void OnShow()
        {
            View.GoMenu.Select();
            View.GoMenu.OnSelect(null);
            _inputManager.PlayerEnable(false);
        }

        private void OnContinue()
        {
            _signalBus.BackWindow();
            _inputManager.PlayerEnable(true);
        }
        
        private void OnGoMenu()
        {
            _signalBus.BackWindow();
            _signalBus.OpenWindow<BlackScreenWindow>(EWindowLayer.Project);
            _signalBus.Fire(new SignalBlackScreen(false, () =>
            {
                _sceneLoadingManager.LoadMenu();
                _inputManager.PlayerEnable(true);
            }));
        }
    }
}