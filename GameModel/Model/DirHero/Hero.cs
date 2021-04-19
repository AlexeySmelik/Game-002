using System.Drawing;
using GameModel.Model.DirEntity;

namespace GameModel.Model.DirHero
{
    public class Hero : IEntity
    {
        public Size Size { get; }
        public Manipulator Manipulator { get; }

        public Point Location { get; private set; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }

        public Hero(Size size, Point location)
        {
            Size = size;
            Location = location;
            DownVelocity = 0;
            UpVelocity = 0;
            Manipulator = new Manipulator(this);
        }

        

        public void Move(Point dPoint)
        {
            Location = new Point(Location.X + dPoint.X, Location.Y + dPoint.Y);
        }
    }
}