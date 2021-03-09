using DataBase.Audio;
using DG.Tweening;
using Game.Ui.MainMenu;
using PdUtils.PdAudio;
using Plugins.PdUtils.Runtime.PdAudio;
using Services.Input;
using SimpleUi.Signals;
using Zenject;

namespace Initializers
{
    public class MenuInitializer : IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly PdAudio _pdAudio;
        private readonly IAudioBase _audioBase;

        public MenuInitializer(SignalBus signalBus, PdAudio pdAudio, IAudioBase audioBase, IInputManager inputManager)
        {
            _signalBus = signalBus;
            _pdAudio = pdAudio;
            _audioBase = audioBase;
        }

        public void Initialize()
        {
            _signalBus.OpenWindow<MainMenuWindow>();
            _pdAudio.PlayMusic(_audioBase.Get("MainMenu"));
        }
    }
}