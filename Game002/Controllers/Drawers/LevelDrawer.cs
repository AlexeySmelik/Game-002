using System.Drawing;

namespace Game002.Controllers.Drawers
{
    public static class LevelDrawer
    {
        public static void Draw(Graphics g, GameModel.Model.GameModel model)
        {
            MapDrawer.DrawMap(g, model.CurrentLevel.GetCurrentMap());
            //MapDrawer.DrawSheetMap(g, model.CurrentLevel.GetCurrentMap());
            HeroDrawer.DrawHero(g, model.CurrentLevel.CurrentHero);
            //HeroDrawer.DrawSheetHero(g, model.CurrentLevel.CurrentHero);
        }
    }
}