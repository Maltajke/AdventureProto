using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace SimpleUi
{
	public class SimpleUiInstaller : MonoInstaller
	{
		[SerializeField] private EWindowLayer windowLayer;

		public override void InstallBindings()
		{
			Container.BindInitializableExecutionOrder<WindowsController>(-1000);
			Container.BindInterfacesTo<WindowsController>().AsSingle()
				.WithArguments(windowLayer).NonLazy();
			Container.Bind<WindowState>().AsSingle();

			Container.BindUiSignals(windowLayer);
		}
	}
}