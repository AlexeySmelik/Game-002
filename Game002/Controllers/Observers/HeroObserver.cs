using System.Windows.Forms;
using GameModel.Model.DirHero;

namespace Game002.Controllers.Observers
{
    public static class HeroObserver
    {
        public static void SetKeyDownActions(KeyEventArgs args, Hero hero)
        {
            switch (args.KeyCode)
            {
                case Keys.A:
                    hero.Manipulator.SetHorizontalVelocity(-1);
                    break;
                case Keys.D:
                    hero.Manipulator.SetHorizontalVelocity(1);
                    break;
            }
        }

        public static void SetKeyPassActions(KeyPressEventArgs args, Hero hero)
        {
            switch (args.KeyChar)
            {
                case (char)Keys.Space:
                    hero.Manipulator.SetUpVelocity(39);
                    break;
            }
        }
    }
}