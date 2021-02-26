using Services.Input;
using Services.Input.Impls;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputManager>().AsSingle();
        }
    }
}