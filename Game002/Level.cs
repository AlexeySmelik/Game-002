using System.Collections.Generic;
using Game002.DirHero;
using Game002.DirMap;

namespace Game002
{
    public class Level
    {
        public Hero CurrentHero;
        public List<Map> CurrentMaps;
        public int IndexMap = 0;

        public Level(Hero hero, List<Map> maps)
        {
            CurrentHero = hero;
            CurrentMaps = maps;
        }

        public Map GetCurrentMap() => CurrentMaps[IndexMap];
    }
}