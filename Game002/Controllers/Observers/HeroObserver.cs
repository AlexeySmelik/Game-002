using System.Windows.Forms;
using Game002.Model.DirHero;

namespace Game002.Controllers.Observers
{
    public static class HeroObserver
    {
        public static void SetKeyDownActions(KeyEventArgs args, Hero hero)
        {
            switch (args.KeyCode)
            {
                case Keys.A:
                    hero.Manipulator.LeftMove();
                    break;
                case Keys.D:
                    hero.Manipulator.RightMove();
                    break;
            }
        }

        public static void SetKeyPassActions(KeyPressEventArgs args, Hero hero)
        {
            switch (args.KeyChar)
            {
                case (char)Keys.Space:
                    hero.Manipulator.SpaceMove();
                    break;
            }
        }
    }
}