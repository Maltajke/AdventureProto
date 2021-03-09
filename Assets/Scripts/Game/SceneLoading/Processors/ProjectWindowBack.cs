using System;
using PdUtils.SceneLoadingProcessor.Impls;
using Signals;
using UniRx;
using Zenject;

namespace Game.SceneLoading.Processors
{
	public class ProjectWindowBack : Process
	{
		private readonly SignalBus _signalBus;
		private readonly object _signalToFire;

		public ProjectWindowBack(SignalBus signalBus, object signalToFire = null)
		{
			_signalBus = signalBus;
			_signalToFire = signalToFire;
		}

		public override void Do(Action onComplete)
		{
			_signalBus.Fire(new SignalBlackScreen(true, () =>
			{
				_signalBus.Fire(_signalToFire);
			}));
			Observable.NextFrame().Subscribe(_ => onComplete());
		}
	}
}