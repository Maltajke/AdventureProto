using System;
using PdUtils.SceneLoadingProcessor.Impls;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Game.SceneLoading.Processors
{
	public class OpenLoadingWindowProcess : Process
	{
		private readonly SignalBus _signalBus;

		public OpenLoadingWindowProcess(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public override void Do(Action complete)
		{
			Observable.NextFrame().Subscribe(_ => complete());
		}
	}
}