using System.Drawing;
using GameModel.Model.Data;
using GameModel.Model.Manipulators;

namespace GameModel.Model.Mobs
{
    public class Hero : IEntity
    {
        public string Name { get; }
        public Size Size { get; }
        public MovementManipulator MovementManipulator { get; }
        public CombatManipulator CombatManipulator { get; }
        public bool IsActive { get; set; }
        public Point Location { get; private set; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        public bool IsReadyToJump { get; set; }
        public Direction Direction { get; set; }

        public Hero(
            string name,
            Size size,
            Point location,
            int health = 100,
            int attack = 1000,
            int stamina = 100,
            int cooldown = 10)
        {
            Name = name;
            Size = size;
            Location = location;
            IsActive = true;
            Direction = Direction.Right;
            MovementManipulator = new MovementManipulator(this);
            CombatManipulator = new CombatManipulator(this, health, attack, stamina, cooldown);
        }
        
        public void Move(Point dPoint)
        {
            Location = new Point(Location.X + dPoint.X, Location.Y + dPoint.Y);
        }
        
        public void SetLocation(Point nLocation)
        {
            Location = nLocation;
        }
    }
}