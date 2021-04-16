using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestGame002.Model.DirHero;
using TestGame002.Model.DirPhysic;

namespace TestGame002.Model
{
    public class Level
    {
        public Hero CurrentHero;
        public Timer LevelTimer;

        private List<Map> CurrentMaps;
        private int IndexMap;
        private Physics Physics;

        public Level(Hero hero, List<Map> maps)
        {
            CurrentHero = hero;
            CurrentMaps = maps;
            LevelTimer = new Timer {Interval = 10};
            LevelTimer.Tick += OnTimerTick;
            Physics = new Physics(this);
        }

        private void OnTimerTick(object sender, EventArgs args)
        {
            CurrentHero.Manipulator.PreDownMove(GetCurrentMap());
            Physics.MoveHero(LevelTimer.Interval);
            CurrentHero.Manipulator.PreUpMove(GetCurrentMap());
        }

        public Map GetCurrentMap() => CurrentMaps[IndexMap];

        public bool NextMap()
        {
            IndexMap++;
            return IndexMap < CurrentMaps.Count;
        }
    }
}