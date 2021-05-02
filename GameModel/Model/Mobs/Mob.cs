using System.Drawing;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace GameModel.Model.Mobs
{
    public class Mob : IEntity, IDangerous
    {
        public string Name { get; }
        public Size Size { get; }
        public Manipulator Manipulator { get; }
        public Point Location { get; private set; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        public int Health { get; private set; }
        public int Attack { get; }
        public int Cooldown { get; set; }
        public Direction Direction { get; set; }
        public bool IsReadyToAttack { get; set; }

        public Mob(
            string name,
            Size size,
            Point location,
            int health,
            int attack,
            int cd = 10)
        {
            Name = name;
            Size = size;
            Location = location;
            Health = health;
            Attack = attack;
            Direction = Direction.Right;
            Cooldown = cd;
            IsReadyToAttack = true;
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