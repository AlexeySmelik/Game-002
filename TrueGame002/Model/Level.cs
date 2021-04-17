using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Game002.Model.DirHero;
using Game002.Model.DirPhysic;

namespace Game002.Model
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
            Physics.MoveHero(LevelTimer.Interval);
        }

        public Map GetCurrentMap() => CurrentMaps[IndexMap];

        public bool NextMap()
        {
            IndexMap++;
            return IndexMap < CurrentMaps.Count;
        }
    }
}