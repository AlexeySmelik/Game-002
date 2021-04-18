using System.Drawing;

namespace Game002.Model.DirHero
{
    public partial class Manipulator //TODO
    {
        private readonly Hero CurrentHero;

        public Manipulator(Hero hero) => CurrentHero = hero;

        public void LeftMove(Map map)
        {
            CurrentHero.Move(PreRightOrLeftMove(new Point(-CurrentHero.StepSize, 0), map));
        }

        public void RightMove(Map map)
        {
            CurrentHero.Move(PreRightOrLeftMove(new Point(CurrentHero.StepSize, 0), map));
        }

        public void SpaceMove(Map map)
        {
            if (CurrentHero.UpVelocity == 0)
                CurrentHero.UpVelocity = 39;
        }
    }
}