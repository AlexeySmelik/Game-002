using System.Collections.Generic;
using Game002.Model.DirHero;
using Game002.Model.DirPhysic;

namespace Game002.Model
{
    public class Level
    {
        public Hero CurrentHero;
        public int TimerInterval;

        private List<Map> CurrentMaps;
        private int IndexMap;
        private Physics Physics;

        public Level(Hero hero, List<Map> maps)
        {
            CurrentHero = hero;
            CurrentMaps = maps;
            Physics = new Physics(this);
        }
        
        public void OnTimerTickEvents()
        {
            Physics.TryMove(TimerInterval);
        }

        public Map GetCurrentMap() => CurrentMaps[IndexMap];

        public bool NextMap()
        {
            IndexMap++;
            return IndexMap < CurrentMaps.Count;
        }
    }
}