using System.Drawing;
using Game002.Model.DirHero;
using Game002.Model;

namespace Game002.Controllers.Drawers
{
    public static class HeroDrawer
    {
        public static void DrawHero(Graphics g, Hero hero) => 
            g.DrawImage(hero.HeroView, new Rectangle(hero.Location, hero.Size));
    }
}