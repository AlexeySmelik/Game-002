using System.Drawing;

namespace TestGame002.Model.DirHero
{
    public class Hero
    {
        public readonly Size Size;
        public readonly int StepSize;

        public Point Location;
        public Image HeroView;
        public Manipulator Manipulator;

        public Hero(Size size, Point location)
        {
            Size = size;
            Location = location;
            StepSize = size.Width / 4;
            Manipulator = new Manipulator(this);
        }

        public void Move(Point dPoint)
        {
            Location.X += dPoint.X;
            Location.Y += dPoint.Y;
        }
    }
}