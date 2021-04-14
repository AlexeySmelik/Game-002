using System.Drawing;

namespace Game002.DirHero
{
    public static class HeroDrawer
    {
        public static void DrawHeroSheet(Graphics g, Hero hero) => 
            g.DrawRectangle(new Pen(Color.Red), hero.Location.X, hero.Location.Y, hero.Size.Width, hero.Size.Height);

        public static void DrawHero(Graphics g, Hero hero) => 
            g.DrawImage(hero.HeroView, new Rectangle(hero.Location, hero.Size));
    }
}