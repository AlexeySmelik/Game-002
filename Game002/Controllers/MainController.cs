#nullable enable
using System;
using System.Drawing;
using System.Windows.Forms;
using TestGame002.Controllers.Drawers;
using TestGame002.Controllers.Observers;

namespace TestGame002.Controllers
{
    public static class MainController
    {
        public static GameModel.Model.GameModel Model = null!;

        public static void OnKeyDown(object sender, KeyEventArgs args)
        {
            HeroObserver.SetKeyDownActions(args, Model.CurrentLevel.CurrentHero);
        }            
        
        public static void Draw(Graphics g)
        {
            LevelDrawer.Draw(g, Model);
        }

        public static void OnKeyPress(object? sender, KeyPressEventArgs args)
        {
            HeroObserver.SetKeyPassActions(args, Model.CurrentLevel.CurrentHero);
        }

        public static void TimerTickEvents(object sender, EventArgs args)
        {
            Model.CurrentLevel.OnTimerTickEvents();
        }
    }
}