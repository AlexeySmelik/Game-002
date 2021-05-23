using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameModel.Model.Data;
using GameModel.Model.Mobs;

namespace GameModel.Model
{
    public class Level
    {
        public readonly Hero CurrentHero;
        public readonly int TimerInterval;
        
        private readonly List<Map> _maps;
        private int _indexMap;

        public TimeSpan Time { get; private set; }
        
        public Level(Hero hero, List<Map> maps, int t)
        {
            CurrentHero = hero;
            _maps = maps;
            TimerInterval = t;
        }

        public void OnTimerTickEvents()
        {
            if (TryNextMap())
                CurrentHero.SetLocation(new Point(100, 100));
            if (CheckOnEndLevel())
                return;
            Time += new TimeSpan(0, 0, 0, 1);
            Console.WriteLine(Time);
            UpdateLevelPhysics();
            CurrentHero.CombatManipulator.RestoreStamina(1);
            CurrentHero.CombatManipulator.DoSimpleAttack(
                GetCurrentMap().GetActiveMobs().Select(x => x as IEntity), 25);
            MobManager.MakeMove(GetCurrentMap(), CurrentHero);
        }

        private bool CheckOnEndLevel() => !CurrentHero.IsActive || !GetCurrentMap().GetActiveMobs().Any();

        private void UpdateLevelPhysics()
        {
            Physics.UpdateMap(GetCurrentMap());
            var entityList = GetCurrentMap().MobList
                .Where(it => it.IsActive)
                .Select(it => it as IEntity)
                .ToList();
            entityList.Add(CurrentHero);
            Physics.TryMoveEntities(entityList, TimerInterval);
        }

        private bool TryNextMap()
        {
            if (GetCurrentMap().MobList.Any(it => it.IsActive) || _indexMap + 1 >= _maps.Count) 
                return false;
            _indexMap++;
            return true;
        }
        
        public Map GetCurrentMap() => _maps[_indexMap];
    }
}