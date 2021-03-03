using SimpleUi;

namespace Game.Ui.MainMenu
{
    public class MainMenuWindow : WindowBase
    {
        public override string Name => "MainMenu";
        protected override void AddControllers()
        {
            AddController<MainMenuViewController>();
        }
    }
}