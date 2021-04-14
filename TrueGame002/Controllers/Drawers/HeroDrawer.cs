using System.Drawing;
using TestGame002.Model;
using TestGame002.Model.DirHero;

namespace TestGame002.Controllers.Drawers
{
    public static class HeroDrawer
    {
        public static void DrawHero(Graphics g, Hero hero) => 
            g.DrawImage(hero.HeroView, new Rectangle(hero.Location, hero.Size));
    }
}