using System.Drawing;

namespace Game002.Model.DirHero
{
    public partial class Manipulator //TODO
    {
        private readonly Hero hero;

        public Manipulator(Hero hero) => this.hero = hero;

        public void LeftMove(Map map)
        {
            hero.Move(PreRightOrLeftMove(new Point(-hero.StepSize, 0), map));
        }

        public void RightMove(Map map)
        {
            hero.Move(PreRightOrLeftMove(new Point(hero.StepSize, 0), map));
        }

        public void SpaceMove(Map map)
        {
            if (hero.UpVelocity == 0)
                hero.UpVelocity = 39;
        }
    }
}