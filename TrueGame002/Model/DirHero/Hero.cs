using System.Drawing;

namespace TestGame002.Model.DirHero
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

        public bool IsFall(Map map) //TODO Tests
        {
            return map.IsBound(new Point(Location.X, Location.Y + Size.Height)) &&
                   !map.IsBlock(new Point(Location.X, Location.Y + Size.Height));
        }
    }
}