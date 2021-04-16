using System.Drawing;

namespace TestGame002.Model.DirHero
{
    public partial class Manipulator //TODO
    {
        private readonly Hero CurrentHero;
        
        public Manipulator(Hero hero) => CurrentHero = hero;

        public void LeftMove(Map map)
        {
            CurrentHero.Move(new Point(-CurrentHero.StepSize, 0));
        }

        public void RightMove(Map map)
        {
            CurrentHero.Move(new Point(CurrentHero.StepSize, 0));
        }

        public void SpaceMove(Map map)
        {
            
        }
    }
}