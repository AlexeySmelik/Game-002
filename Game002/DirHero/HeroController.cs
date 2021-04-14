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
            if (MapDrawer.Map == null)
                throw new Exception("There is no map in the MapDrawer");
            if (MapDrawer.Map.IsBound(newLocation) && !MapDrawer.Map.IsBlock(newLocation))
                Hero.Move(dp);
        }
    }
}