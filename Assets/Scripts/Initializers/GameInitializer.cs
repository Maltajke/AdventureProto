using DataBase.Audio;
using Game.SceneLoading;
using Plugins.PdUtils.Runtime.PdAudio;
using Services.Input;
using Services.PauseService;
using Zenject;
namespace Initializers
{
    public class GameInitializer : IInitializable
    {
        private readonly PdAudio _pdAudio;
        private readonly IAudioBase _audioBase;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly IInputManager _inputManager;

        public GameInitializer(PdAudio pdAudio, IAudioBase audioBase, ISceneLoadingManager sceneLoadingManager, IInputManager inputManager)
        {
            _pdAudio = pdAudio;
            _audioBase = audioBase;
            _sceneLoadingManager = sceneLoadingManager;
            _inputManager = inputManager;
        }

        public void Initialize()
        {
            _pdAudio.PlayMusic(_audioBase.Get(_sceneLoadingManager.CurrentScene));
            _inputManager.PlayerEnable(true);
        }
    }
}