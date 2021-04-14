using System.Drawing;

 namespace Game002.DirHero
{
    public class Hero
    {
        public readonly Size Size;
        public readonly int MoveHeight;
        public readonly int MoveWidth;

        public Point Location;
        public Image HeroView;

        public Hero(Size size, Point location)
        {
            Size = size;
            Location = location;
            MoveHeight = size.Height / 2;
            MoveWidth = size.Width / 2;
        }
        
        public void Move(Point dPoint)
        {
            Location.X += dPoint.X;
            Location.Y += dPoint.Y;
        }
    }
}