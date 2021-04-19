using System.Collections.Generic;
using GameModel.Model.DirHero;
using GameModel.Model.DirPhysic;

namespace GameModel.Model
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
            Physics = new Physics(hero, GetCurrentMap());
        }
        
        public void OnTimerTickEvents()
        {
            Physics.TryMoveForAllEntity(TimerInterval);
        }

        public Map GetCurrentMap() => CurrentMaps[IndexMap];

        public bool NextMap()
        {
            IndexMap++;
            return IndexMap < CurrentMaps.Count;
        }
    }
}