using ECS.Utils.Impls;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            BindWindows();
            BindServices();
        }

        private void BindWindows()
        {
            
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SpawnService>().AsSingle();
        }
    }
}