using Services;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TestService>().AsSingle();
        }
    }
}