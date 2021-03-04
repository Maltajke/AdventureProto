using Game.SceneLoading;
using Game.SceneLoading.Impls;
using Game.Ui.BlackScreen;
using Game.Utils;
using PdUtils.PlayerPrefs;
using PdUtils.PlayerPrefs.Impl;
using Services.Input;
using Services.Input.Impls;
using UniRx;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MainThreadDispatcher.Initialize();
            SignalBusInstaller.Install(Container);
            Container.BindSubstituteInterfacesTo<ISceneLoadingManager, SceneLoadingManager>().AsSingle();
            Container.BindSubstituteInterfacesTo<IInputManager, InputManager>().AsSingle();
            Container.BindFromSubstitute<IPlayerPrefsManager, PersistancePlayerPrefsManager>().AsSingle();
            Container.BindInterfacesTo<PdAudioInitializer>().AsSingle().NonLazy();
            
            BindWindows();
        }
        
        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<BlackScreenWindow>().AsSingle();
        }
    }
}