using System;
using System.Drawing;
using System.Windows.Forms;
using Game002.Controllers.Drawers;
using Game002.Controllers.Observers;
using Game002.Model;
using TestGame002;

namespace Game002.Controllers
{
    public static class MainController
    {
        public static GameModel Model;

        public static void OnKeyDown(object sender, KeyEventArgs args)
        {
            if (Model.CurrentMode == GameMods.PlayMode)
                HeroObserver.SetKeyDownActions(args, Model.CurrentLevel.CurrentHero);
        }            
        
        public static void Draw(Graphics g)
        {
            if (Model.CurrentMode == GameMods.PlayMode)
                LevelDrawer.Draw(g, Model);
        }

        public static void OnKeyPress(object? sender, KeyPressEventArgs args)
        {
            if (Model.CurrentMode == GameMods.PlayMode)
                HeroObserver.SetKeyPassActions(args, Model.CurrentLevel.CurrentHero);
        }

        public static void TimerTickEvents(object sender, EventArgs args)
        {
            if (Model.CurrentMode == GameMods.PlayMode)
            {
                Model.CurrentLevel.TimerInterval = 5;
                Model.CurrentLevel.OnTimerTickEvents();
            }
        }
    }
}