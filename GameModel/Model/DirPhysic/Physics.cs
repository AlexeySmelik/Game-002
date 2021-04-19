using System;
using System.Drawing;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace GameModel.Model.DirPhysic
{
    public class Physics
    {
        private readonly Map map;
        private readonly Hero hero;
        
        private const double G = 100;

        public Physics(Hero hero, Map map)
        {
            this.hero = hero;
            this.map = map;
        }

        public void TryMoveForAllEntity(double interval)
        {
            TryMove(hero, interval);
            map.MobsArray.ForEach(mob => TryMove(mob, interval));
        }

        private void TryMove(IEntity entity, double dt) //TODO Tests
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
                    entity.Manipulator.PreRightOrLeftMove(new Point((int) entity.HorizontalVelocity, 0), map)
                    );
            }
        }

        private bool CheckOnFall(IEntity entity)
        {
            for (var i = 0; i <= entity.Size.Width; i++)
                if (!map.IsBound(new Point(entity.Location.X, entity.Location.Y + entity.Size.Height + 1)) ||
                    map.IsBlock(new Point(entity.Location.X, entity.Location.Y + entity.Size.Height + 1)))
                    return false;
            return true;
        }

        private bool CheckOnJump(IEntity entity) => entity.UpVelocity > 0;

        private bool CheckOnHorizontalMove(IEntity entity) => entity.HorizontalVelocity != 0;
    }
}