using System;
using System.Collections.Generic;
using System.Drawing;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace GameModel.Model.DirPhysic
{
    public static class Physics
    {
        private static Map map;
        private const double G = 100;
        
        public static void UpdateMap(Map newMap)
        {
            map = newMap;
        }
        
        public static void TryMoveForEntity(List<IEntity> entityList, double interval)
        {
            entityList.ForEach(it => TryMove(it, interval));
        }

        private static void TryMove(IEntity entity, double dt) //TODO Tests
        {
            if (CheckOnJump(entity))
            {
                entity.UpVelocity = Math.Max(0, entity.UpVelocity - dt / 100 * G);
                entity.Move(entity.Manipulator.PreDownOrUpMove(new Point(0, -(int) entity.UpVelocity), map));
            }
            else if (CheckOnFall(entity))
            {
                entity.DownVelocity = Math.Min(map.CellSize - 1, entity.DownVelocity + dt / 100 * G);
                entity.Move(entity.Manipulator.PreDownOrUpMove(new Point(0, (int)entity.DownVelocity), map));
            }
            else
            {
                entity.DownVelocity = 0;
            }

            if (CheckOnHorizontalMove(entity))
            {
                entity.HorizontalVelocity = 
                    Math.Sign(entity.HorizontalVelocity) * Math.Max(0, Math.Abs(entity.HorizontalVelocity) - dt / 100 * G);
                entity.Move(
                    entity.Manipulator.PreRightOrLeftMove(new Point((int) entity.HorizontalVelocity, 0), map));
            }
        }

        private static bool CheckOnFall(IEntity entity)
        {
            for (var i = 0; i < entity.Size.Width; i++)
                if (!map.IsBound(new Point(entity.Location.X + i, entity.Location.Y + entity.Size.Height + 1)) ||
                    map.IsBlock(new Point(entity.Location.X + i, entity.Location.Y + entity.Size.Height + 1)))
                    return false;
            return true;
        }

        private static bool CheckOnJump(IEntity entity) => entity.UpVelocity > 0;

        private static bool CheckOnHorizontalMove(IEntity entity) => entity.HorizontalVelocity != 0;
    }
}