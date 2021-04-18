using System;
using System.Windows.Forms;
using Game002.Model;

namespace Game002.Controllers.Observers
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
            }
        }

        public static void SetKeyPassActions(KeyPressEventArgs args, GameModel model)
        {
            switch (args.KeyChar)
            {
                case (char)Keys.Space:
                    model.CurrentLevel.CurrentHero.Manipulator.SpaceMove(model.CurrentLevel.GetCurrentMap());
                    break;
            }
        }
    }
}