using System.Collections.Generic;
using TestGame002.Model.DirHero;
using TestGame002.Model.DirPhysic;

namespace TestGame002.Model
{
    public class Level
    {
        public Hero CurrentHero;
        private List<Map> CurrentMaps;
        private Physics _physic;  
        private int IndexMap;

        public Level(Hero hero, List<Map> maps)
        {
            CurrentHero = hero;
            _physic = new Physics(hero);
            CurrentMaps = maps;
        }

        public Map GetCurrentMap() => CurrentMaps[IndexMap];
        
        public bool NextMap()
        {
            IndexMap++;
            return IndexMap < CurrentMaps.Count;
        }
    }
}