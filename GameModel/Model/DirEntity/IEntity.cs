using System.Drawing;
using Manipulator = GameModel.Model.DirHero.Manipulator;

namespace GameModel.Model.DirEntity
{
    public interface IEntity
    {
        public Size Size { get; }
        public Manipulator Manipulator { get; }
        public Point Location { get; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        
        public void Move(Point dp);
    }
}