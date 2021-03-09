using Game.SceneLoading.Processors;
using PdUtils.SceneLoadingProcessor.Impls;
using Services.Input;
using Services.Uid;
using Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.SceneLoading.Impls
{
	public class SceneLoadingManager : ISceneLoadingManager
	{
		private readonly SignalBus _signalBus;
		private readonly IInputManager _inputManager;
		private LoadingProcessor _processor;
		
		private const string GAME_CONTEXT = "GameContext";
		private const string MENU_CONTEXT = "MenuContext";
		private const string MENU_SCENE = "MainMenu";
		private const string SPLASH_SCENE = "SplashScene";
		private const string LOAD_SCENE = "LoadingScene";

		public SceneLoadingManager(SignalBus signalBus, IInputManager inputManager)
		{
			_signalBus = signalBus;
			_inputManager = inputManager;
			CurrentScene = SPLASH_SCENE;
		}
		public string CurrentScene { get; private set; }

		public void LoadScene(string key)
		{
			UidGenerator.Clear();
			_inputManager.Dispose();
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess(LOAD_SCENE, LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess(CurrentScene))
				.AddProcess(new LoadingProcess(key, LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess(LOAD_SCENE))
				.AddProcess(new RunContextProcess(key == MENU_SCENE ? MENU_CONTEXT : GAME_CONTEXT))
				.AddProcess(new ProjectWindowBack(_signalBus, new SignalGameInit()))
				.DoProcess();
			CurrentScene = key;
		}

		public float GetProgress() => _processor?.Progress ?? 0f;
	}
}