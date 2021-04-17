using System.Drawing;
using Game002.Model;

namespace Game002.Controllers.Drawers
{
    public static class LevelDrawer
    {
        public static void Draw(Graphics g, GameModel model)
        {
            MapDrawer.DrawMap(g, model.CurrentLevel.GetCurrentMap());
            HeroDrawer.DrawHero(g, model.CurrentLevel.CurrentHero);
        }
    }
}