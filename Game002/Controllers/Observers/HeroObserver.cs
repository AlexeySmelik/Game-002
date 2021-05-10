using System.Windows.Forms;
using GameModel.Model.Mobs;

namespace TestGame002.Controllers.Observers
{
    public static class HeroObserver
    {
        public static void SetKeyDownActions(KeyEventArgs args, Hero hero)
        {
            switch (args.KeyCode)
            {
                case Keys.A:
                    hero.MovementManipulator.SetHorizontalVelocity(-1);
                    break;
                case Keys.D:
                    hero.MovementManipulator.SetHorizontalVelocity(1);
                    break;
                case Keys.F:
                    hero.CombatManipulator.IsReadyToAttack = true;
                    break;
            }
        }

        public static void SetKeyPassActions(KeyPressEventArgs args, Hero hero)
        {
            switch (args.KeyChar)
            {
                case (char)Keys.Space:
                    hero.MovementManipulator.SetUpVelocity(39);
                    break;
            }
        }
    }
}