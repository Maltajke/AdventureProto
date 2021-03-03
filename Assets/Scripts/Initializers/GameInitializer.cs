using DataBase.Audio;
using Plugins.PdUtils.Runtime.PdAudio;
using Zenject;
namespace Initializers
{
    public class GameInitializer : IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly PdAudio _pdAudio;
        private readonly IAudioBase _audioBase;
        private readonly string _sceneName;

        public GameInitializer(SignalBus signalBus, PdAudio pdAudio, IAudioBase audioBase, string sceneName)
        {
            _signalBus = signalBus;
            _pdAudio = pdAudio;
            _audioBase = audioBase;
            _sceneName = sceneName;
        }

        public void Initialize()
        {
            _pdAudio.PlayMusic(_audioBase.Get(_sceneName));
        }
    }
}