using System.Collections.Generic;
using TestGame002.Model.DirHero;

namespace TestGame002.Model
{
    public class Level
    {
        public Hero CurrentHero;
        public List<Map> CurrentMaps;
        private int IndexMap;

        public Level(Hero hero, List<Map> maps)
        {
            CurrentHero = hero;
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