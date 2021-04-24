using System.Drawing;
using Manipulator = GameModel.Model.DirHero.Manipulator;

namespace GameModel.Model.DirEntity
{
    public class Creeper : IEntity, IPVP
    {
        public Size Size { get; }
        public Manipulator Manipulator { get; }
        public Point Location { get; private set; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        
        public Creeper(Size size, Point location)
        {
            Size = size;
            Location = location;
            Health = 10;
            Attack = 10;
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
    }
}