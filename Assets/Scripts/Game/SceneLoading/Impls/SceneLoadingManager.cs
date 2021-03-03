﻿using Game.SceneLoading.Processors;
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

		public SceneLoadingManager(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void LoadMenuFromSplash()
		{
			_processor = new LoadingProcessor();
			_processor.AddProcess(new LoadingProcess("Menu", LoadSceneMode.Additive))
#if UNITY_EDITOR
				.AddProcess(new UnloadProcess("Splash"))
				.AddProcess(new RunContextProcess("MenuContext"))
#else
                .AddProcess(new SetActiveSceneProcess("Menu"))
                .AddProcess(new RunContextProcess("MenuContext"))
                .AddProcess(new WaitFramesProcessor(4))
                .AddProcess(new UnloadProcess("Splash"))
#endif
				.DoProcess();
		}

		public void LoadGameFromMenu()
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess("StartScene", LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess("MainMenu"))
				.AddProcess(new RunContextProcess("GameContext"))
				.AddProcess(new ProjectWindowBack(_signalBus, new SignalGameInit()))
				.DoProcess();
		}

		
		
		public void LoadMenuFromGame()
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess("Menu", LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess("Game"))
				.AddProcess(new RunContextProcess("MenuContext"))
				.AddProcess(new ProjectWindowBack(_signalBus))
				.DoProcess();
		}

		public void LoadSplashFromMenu()
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess("Menu", LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess("Menu"))
				.AddProcess(new RunContextProcess("MenuContext"))
				.DoProcess();
		}

		public void LoadZalupinskFromStartScene()
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess("Zalupinsk", LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess("StartScene"))
				.AddProcess(new RunContextProcess("GameContext"))
				.AddProcess(new ProjectWindowBack(_signalBus, new SignalGameInit()))
				.DoProcess();
		}

		public void LoadScene(string from, string to)
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess(to, LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess(from))
				.AddProcess(new RunContextProcess("GameContext"))
				.AddProcess(new ProjectWindowBack(_signalBus, new SignalGameInit()))
				.DoProcess();
		}

		public void LoadScene(string key)
		{
			_processor = new LoadingProcessor();
			_processor
				.AddProcess(new LoadingProcess("Zalupinsk", LoadSceneMode.Additive))
				.AddProcess(new UnloadProcess("StartScene"))
				.AddProcess(new RunContextProcess("GameContext"))
				.AddProcess(new ProjectWindowBack(_signalBus, new SignalGameInit()))
				.DoProcess();
		}

		public float GetProgress() => _processor?.Progress ?? 0f;
	}
}