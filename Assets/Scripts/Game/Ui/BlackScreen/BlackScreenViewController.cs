using System;
using DG.Tweening;
using Game.SceneLoading;
using Plugins.PdUtils.Runtime.PdAudio;
using Services.Input;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using Zenject;

namespace Game.Ui.BlackScreen
{
    public class BlackScreenViewController : UiController<BlackScreenView>, IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly PdAudio _pdAudio;

        public BlackScreenViewController(SignalBus signalBus, ISceneLoadingManager sceneLoadingManager, PdAudio pdAudio)
        {
            _signalBus = signalBus;
            _sceneLoadingManager = sceneLoadingManager;
            _pdAudio = pdAudio;
        }
        
        public void Initialize()
        {
            var duration = 2f;
            _signalBus.Subscribe<SignalBlackScreen>(x=>
            {
                View.Show(() => OnComplete(x.Open, x.Complete), x.Open, duration);
                DOVirtual.Float(x.Open ? 0 : 1, x.Open ? 1 : 0, duration, _pdAudio.SetMusicVolume);
            });
        }

        private void OnComplete(bool open, Action complete)
        {
            if (open)
            {
                _signalBus.BackWindow(EWindowLayer.Project);
            }
            complete?.Invoke();
        }
    }
}