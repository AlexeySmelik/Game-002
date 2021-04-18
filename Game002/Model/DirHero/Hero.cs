using System.Drawing;

namespace Game002.Model.DirHero
{
    public class Hero
    {
        public readonly Size Size;
        public readonly int StepSize;
        public readonly Manipulator Manipulator;

        public Point Location;
        public Image HeroView;
        public double DownVelocity;
        public double UpVelocity;

        public Hero(Size size, Point location)
        {
            Size = size;
            Location = location;
            StepSize = size.Width / 4;
            DownVelocity = 0;
            UpVelocity = 0;
            Manipulator = new Manipulator(this);
        }

        public void Move(Point dPoint)
        {
            Location.X += dPoint.X;
            Location.Y += dPoint.Y;
        }
    }
}