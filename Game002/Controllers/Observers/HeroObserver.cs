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
                case Keys.W:
                    hero.MovementManipulator.SetUpVelocity(39);
                    break;
            }
        }
    }
}