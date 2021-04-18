using System.Drawing;
using Game002.Model.DirHero;

namespace Game002.Controllers.Drawers
{
    public static class HeroDrawer
    {
        public static void DrawSheetHero(Graphics g, Hero hero) =>
            g.DrawRectangle(new Pen(Color.Blue), new Rectangle(hero.Location, hero.Size));
        
        public static void DrawHero(Graphics g, Hero hero) => 
            g.DrawImage(hero.HeroView, new Rectangle(hero.Location, hero.Size));
    }
}