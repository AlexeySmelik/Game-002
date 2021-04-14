using System;
using System.Drawing;
using System.Windows.Forms;
using Game002.DirMap;

namespace Game002.DirHero
{
    public static class HeroController
    {
        public static Hero Hero;

        public static void OnPressKey(object sender, KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                    PreMove(new Point(0, -Hero.MoveHeight));
                    break;
                case Keys.S:
                    PreMove(new Point(0, Hero.MoveHeight));
                    break;
                case Keys.A:
                    PreMove(new Point(-Hero.MoveWidth, 0));
                    break;
                case Keys.D:
                    PreMove(new Point(Hero.MoveWidth, 0));
                    break;
            }
        }

        private static void PreMove(Point dp)
        {
            var newLocation = new Point(Hero.Location.X + dp.X, Hero.Location.Y + dp.Y);
            if (MapController.Map == null)
                throw new Exception("There is no map in the MapController");
            if (MapController.Map.IsBound(newLocation) && !MapController.Map.IsBlock(newLocation))
                Hero.Move(dp);
        }

        public static void DrawHeroSheet(Graphics g) => 
            g.DrawRectangle(new Pen(Color.Red), Hero.Location.X, Hero.Location.Y, Hero.Size.Width, Hero.Size.Height);

        public static void DrawHero(Graphics g) => 
            g.DrawImage(Hero.HeroView, new Rectangle(Hero.Location, Hero.Size));
    }
}