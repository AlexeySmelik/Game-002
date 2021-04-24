using System.Drawing;
using GameModel.Model.DirEntity;

namespace GameModel.Model.DirHero
{
    public class Hero : IEntity, IPVP
    {
        public Size Size { get; }
        public Manipulator Manipulator { get; }
        public Point Location { get; private set; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public Hero(Size size, Point location)
        {
            Size = size;
            Location = location;
            DownVelocity = 0;
            UpVelocity = 0;
            Health = 100;
            Manipulator = new Manipulator(this);
        }
        
        public void Move(Point dPoint)
        {
            Location = new Point(Location.X + dPoint.X, Location.Y + dPoint.Y);
        }
        
        public bool IsActive() => Health > 0;
        
        public void GetDamage(int damage)
        {
            Health -= damage;
        }

        public int GetHealth() => Health;

    }
}