using SimpleUi;
using SimpleUi.Interfaces;

namespace Game.Ui.InGameMenu
{
    public class InGameMenuWindow : WindowBase, IPopUp
    {
        public override string Name => "InGameMenu";
        protected override void AddControllers()
        {
            AddController<InGameMenuViewController>();
        }
    }
}