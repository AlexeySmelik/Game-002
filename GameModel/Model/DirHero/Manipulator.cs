using System.Drawing;

namespace Game002.Model.DirHero
{
    public partial class Manipulator //TODO
    {
        private readonly Hero hero;

        public Manipulator(Hero hero) => this.hero = hero;

        public void LeftMove()
        {
            hero.HorizontalVelocity = -30;
        }

        public void RightMove()
        {
            hero.HorizontalVelocity = 30;
        }

        public void SpaceMove()
        {
            if (hero.UpVelocity == 0)
                hero.UpVelocity = 39;
        }
    }
}