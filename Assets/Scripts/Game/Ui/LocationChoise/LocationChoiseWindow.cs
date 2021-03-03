using SimpleUi;

namespace Game.Ui.LocationChoise
{
    public class LocationChoiseWindow : WindowBase
    {
        public override string Name => "LocationChoise";
        protected override void AddControllers()
        {
            AddController<LocationChoiseController>();
        }
    }
}