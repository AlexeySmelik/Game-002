using System.Drawing;
using System.Windows.Forms;
using TestGame002.Model;

namespace TestGame002.Controllers.Observers
{
    public static class HeroObserver
    {
        public static void SetKeyDownActions(KeyEventArgs args, GameModel model)
        {
            switch (args.KeyCode)
            {
                case Keys.A:
                    model.CurrentLevel.CurrentHero.Manipulator.LeftMove(model.CurrentLevel.GetCurrentMap());
                    break;
                case Keys.D:
                    model.CurrentLevel.CurrentHero.Manipulator.RightMove(model.CurrentLevel.GetCurrentMap());
                    break;
                case Keys.Space:
                    model.CurrentLevel.CurrentHero.Manipulator.SpaceMove(model.CurrentLevel.GetCurrentMap());
                    break;
                case Keys.S:
                    model.CurrentLevel.CurrentHero.Manipulator.DownMove(model.CurrentLevel.GetCurrentMap());
                    break;
            }
        } 
    }
}