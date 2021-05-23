using System.Drawing;

namespace TestGame002.Controllers.Drawers
{
    public static class LevelDrawer
    {
        public static void Draw(Graphics g, GameModel.Model.GameModel model)
        {
            MapDrawer.DrawMap(g, model.CurrentLevel.GetCurrentMap());
            HeroDrawer.DrawHero(g, model.CurrentLevel.CurrentHero);
            g.DrawString(
                model.CurrentLevel.Time.ToString(@"hh\:mm\:ss"),
                new Font("Courier New", 40, FontStyle.Bold),
                new SolidBrush(Color.GhostWhite),
                new Point(500, 10));
        }
    }
}