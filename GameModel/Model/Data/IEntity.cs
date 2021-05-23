using System.Drawing;
using GameModel.Model.Manipulators;

namespace GameModel.Model.Data
{
    public interface IEntity
    {
        public string Name { get; }
        public Size Size { get; }
        public MovementManipulator MovementManipulator { get; }
        public CombatManipulator CombatManipulator { get; }
        public bool IsActive { get; set; }
        public Point Location { get; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        public bool IsReadyToJump { get; set; }
        public void Move(Point dp);
        public Direction Direction { get; set; }
    }
}