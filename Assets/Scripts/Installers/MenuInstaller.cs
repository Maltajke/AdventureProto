using Game.Ui.MainMenu;
using Initializers;
using Zenject;

namespace Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindWindows();
            Container.BindInterfacesAndSelfTo<MenuInitializer>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<MainMenuWindow>().AsSingle();
        }
    }
}