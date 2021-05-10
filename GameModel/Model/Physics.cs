using System;
using System.Collections.Generic;
using System.Drawing;
using GameModel.Model.Data;

namespace GameModel.Model
{
    public static class Physics
    {
        private static Map _map;
        private const double G = 100;
        
        public static void UpdateMap(Map newMap)
        {
            _map = newMap;
        }
        
        public static void TryMoveEntities(List<IEntity> entityList, double interval)
        {
            entityList.ForEach(it => TryMove(it, interval));
        }

        private static void TryMove(IEntity entity, double dt)
        {
            if (CheckOnJump(entity))
            {
                entity.UpVelocity = Math.Max(0, entity.UpVelocity - dt / 100 * G);
                entity.Move(entity.MovementManipulator.PreDownOrUpMove(new Point(0, -(int) entity.UpVelocity), _map));
            }
            else if (CheckOnFall(entity))
            {
                entity.DownVelocity = Math.Min(_map.CellSize - 1, entity.DownVelocity + dt / 100 * G);
                entity.Move(entity.MovementManipulator.PreDownOrUpMove(new Point(0, (int)entity.DownVelocity), _map));
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
                    entity.MovementManipulator.PreRightOrLeftMove(new Point((int) entity.HorizontalVelocity, 0), _map));
            }
        }

        private static bool CheckOnFall(IEntity entity)
        {
            for (var i = 0; i < entity.Size.Width; i++)
                if (!_map.IsBound(new Point(entity.Location.X + i, entity.Location.Y + entity.Size.Height + 1)) ||
                    _map.IsBlock(new Point(entity.Location.X + i, entity.Location.Y + entity.Size.Height + 1)))
                    return false;
            return true;
        }

        private static bool CheckOnJump(IEntity entity) => entity.UpVelocity > 0;

        private static bool CheckOnHorizontalMove(IEntity entity) => entity.HorizontalVelocity != 0;
    }
}