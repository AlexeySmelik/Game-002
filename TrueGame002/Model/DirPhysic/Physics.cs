using System;
using System.Drawing;
using System.Windows.Forms;
using TestGame002.Model.DirHero;

namespace TestGame002.Model.DirPhysic
{
    public class Physics //TODO
    {
        private Hero CurrentHero;

        public Physics(Hero currentHero)
        {
            CurrentHero = currentHero;
            var timer = new Timer {Interval = 100};
            timer.Tick += (sender, args) => UpdateLocation();
            timer.Start();
        }

        private void UpdateLocation()
        {
            CurrentHero.Move(new Point(0, CurrentHero.StepSize));
        }
    }
}