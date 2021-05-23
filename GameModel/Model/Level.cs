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
        public bool IsFinished;
        public TimeSpan Time;
        
        private readonly DateTime _startLevelDate;
        private readonly List<Map> _maps;
        private int _indexMap;
        
        public Level(Hero hero, List<Map> maps, int t)
        {
            CurrentHero = hero;
            _maps = maps;
            TimerInterval = t;
            _startLevelDate = DateTime.Now;
        }

        private TimeSpan GetTime() => DateTime.Now - _startLevelDate;

        public void OnTimerTickEvents()
        {
            IsFinished = !CurrentHero.IsActive || !GetCurrentMap().GetActiveMobs().Any();
            if (TryNextMap())
                CurrentHero.SetLocation(new Point(0, 415));
            if (IsFinished)
                return;
            Time = GetTime();
            UpdateLevelPhysics();
            CurrentHero.CombatManipulator.RestoreStamina(1);
            CurrentHero.CombatManipulator.DoSimpleAttack(
                GetCurrentMap().GetActiveMobs().Select(x => x as IEntity), 50);
            MobManager.MakeMove(GetCurrentMap(), CurrentHero);
        }
        
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
            CurrentHero.CombatManipulator.RestoreHealth(25);
            _indexMap++;
            return true;
        }
        
        public Map GetCurrentMap() => _maps[_indexMap];
    }
}