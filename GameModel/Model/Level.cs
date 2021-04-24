using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameModel.Model.DirHero;
using GameModel.Model.DirPhysic;

namespace GameModel.Model
{
    public class Level
    {
        public readonly Hero CurrentHero;
        public readonly int TimerInterval;
        
        private readonly List<Map> maps;
        
        private int indexMap;
        
        public Level(Hero hero, List<Map> maps, int t)
        {
            CurrentHero = hero;
            this.maps = maps;
            TimerInterval = t;
        }

        public void OnTimerTickEvents()
        {
            TryNextMap();
            UpdateLevelPhysics();
        }
        
        private void UpdateLevelPhysics()
        {
            Physics.UpdateMap(GetCurrentMap());
            var entityList = GetCurrentMap().MobList.Where(it => it.IsActive()).ToList();
            entityList.Add(CurrentHero);
            Physics.TryMoveForEntity(entityList, TimerInterval);
        }

        private bool TryNextMap()
        {
            if (GetCurrentMap().MobList.Any(it => it.IsActive()) || indexMap + 1 >= maps.Count) 
                return false;
            indexMap++;
            return true;
        }
        
        public Map GetCurrentMap() => maps[indexMap];
    }
}