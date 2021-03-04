using Game.SceneLoading.Processors;
using PdUtils.SceneLoadingProcessor.Impls;
using Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.SceneLoading.Impls
{
	public class SceneLoadingManager : ISceneLoadingManager
	{
		private readonly SignalBus _signalBus;
		private LoadingProcessor _processor;
		
		private const string GAME_CONTEXT = "GameContext";
		private const string MENU_SCENE = "MainMenu";
		private const string LOAD_SCENE = "LoadingScene";

		public SceneLoadingManager(SignalBus signalBus)
		{
			_signalBus = signalBus;
			CurrentScene = MENU_SCENE;
		}
		public string CurrentScene { get; private set; }

		public void LoadGameScene(string key)
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess(LOAD_SCENE, LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess(CurrentScene))
				.AddProcess(new LoadingProcess(key, LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess(LOAD_SCENE))
				.AddProcess(new RunContextProcess(GAME_CONTEXT))
				.AddProcess(new ProjectWindowBack(_signalBus, new SignalGameInit()))
				.DoProcess();
			CurrentScene = key;
		}

		public void LoadMenu()
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess(MENU_SCENE, LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess(SceneManager.GetActiveScene().name))
				.AddProcess(new ProjectWindowBack(_signalBus, new SignalGameInit()))
				.DoProcess();
			CurrentScene = MENU_SCENE;
		}

		public float GetProgress() => _processor?.Progress ?? 0f;
	}
}