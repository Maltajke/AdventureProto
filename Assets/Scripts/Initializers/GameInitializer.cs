using DataBase.Audio;
using Game.SceneLoading;
using Plugins.PdUtils.Runtime.PdAudio;
using Zenject;
namespace Initializers
{
    public class GameInitializer : IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly PdAudio _pdAudio;
        private readonly IAudioBase _audioBase;
        private readonly ISceneLoadingManager _sceneLoadingManager;

        public GameInitializer(SignalBus signalBus, PdAudio pdAudio, IAudioBase audioBase, ISceneLoadingManager sceneLoadingManager)
        {
            _signalBus = signalBus;
            _pdAudio = pdAudio;
            _audioBase = audioBase;
            _sceneLoadingManager = sceneLoadingManager;
        }

        public void Initialize()
        {
            _pdAudio.PlayMusic(_audioBase.Get(_sceneLoadingManager.CurrentScene));
        }
    }
}