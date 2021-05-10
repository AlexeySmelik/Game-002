using System.Drawing;
using GameModel.Model.Data;
using GameModel.Model.Manipulators;

namespace GameModel.Model.Mobs
{
    public class Mob : IEntity
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
        public Direction Direction { get; set; }

        public Mob(
            string name,
            Size size,
            Point location,
            bool isPeaceful = false,
            int health = 100,
            int attack = 10,
            int stamina = 100,
            int cooldown = 10)
        {
            Name = name;
            Size = size;
            Location = location;
            Direction = Direction.Right;
            IsActive = true;
            MovementManipulator = new MovementManipulator(this);
            CombatManipulator = isPeaceful ? null : new CombatManipulator(this, health, attack, stamina, cooldown);
        }
        
        public void Move(Point dPoint)
        {
            Location += new Size(dPoint);
        }

        public bool IsPeaceful() => CombatManipulator == null;
    }
}