using System.Drawing;

namespace Game002.Model.DirHero
{
    public partial class Manipulator //TODO
    {
        private readonly Hero CurrentHero;
        
        public Manipulator(Hero hero) => CurrentHero = hero;

        public void LeftMove(Map map)
        {
            CurrentHero.Manipulator.PreLeftMove(map);
        }

        public void RightMove(Map map)
        {
            CurrentHero.Manipulator.PreRightMove(map);
        }

        public void SpaceMove(Map map)
        {
            if (CurrentHero.UpVelocity == 0)
                CurrentHero.UpVelocity = 20;
        }
    }
}