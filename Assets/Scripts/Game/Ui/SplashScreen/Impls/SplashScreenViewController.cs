using System;
using Game.SceneLoading;
using Game.Ui.BlackScreen;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using Zenject;

namespace Game.Ui.SplashScreen.Impls
{
    public class SplashScreenViewController : UiController<SplashScreenView>, IInitializable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly SignalBus _signalBus;

        public SplashScreenViewController(ISceneLoadingManager sceneLoadingManager, SignalBus signalBus)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
#if UNITY_EDITOR            
            OnComplete();
#else     
            View.CompleteClip(OnComplete);
#endif
        }
        
        private void OnComplete()
        {
            _signalBus.OpenWindow<BlackScreenWindow>(EWindowLayer.Project);
            _signalBus.Fire(new SignalBlackScreen(false, () =>
            {
                _sceneLoadingManager.LoadScene("MainMenu");
            }));
        }
    }
}