using System.Drawing;
using System.Windows.Forms;
using TestGame002.Controllers.Drawers;
using TestGame002.Controllers.Observers;
using TestGame002.Model;

namespace TestGame002.Controllers
{
    public static class MainController
    {
        public static GameModel Model;

        public static void OnKeyDown(object sender, KeyEventArgs args)
        {
            if (Model.CurrentMode == GameMods.PlayMode)
                HeroObserver.SetKeyDownActions(args, Model);
        }            
        
        public static void Draw(Graphics g)
        {
            if (Model.CurrentMode == GameMods.PlayMode)
                LevelDrawer.Draw(g, Model);
        }

        public static void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (Model.CurrentMode == GameMods.PlayMode)
                HeroObserver.SetKeyPassActions();
        }
    }
}