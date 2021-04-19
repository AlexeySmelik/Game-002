using System;
using System.Drawing;
using System.Numerics;

namespace Game002.Model.DirPhysic
{
    public class Physics
    {
        private readonly Level level;
        
        private const double G = 100;

        public Physics(Level level)
        {
            this.level = level;
        }

        public void TryMove(double dt) //TODO Tests
        {
            var hero = level.CurrentHero;
            var map = level.GetCurrentMap();
            
            if (CheckOnJump())
            {
                hero.UpVelocity = Math.Max(0, hero.UpVelocity - dt / 100 * G);
                hero.Move(hero.Manipulator.PreDownOrUpMove(new Point(0, -(int) hero.UpVelocity), map));
            } 
            else if (CheckOnFall())
            {
                hero.DownVelocity = Math.Min(level.GetCurrentMap().CellSize - 1, hero.DownVelocity + dt / 100 * G);
                hero.Move(hero.Manipulator.PreDownOrUpMove(new Point(0, (int)hero.DownVelocity), map));
            }
            else
            {
                hero.DownVelocity = 0;
            }

            if (CheckOnHorizontalMove())
            {
                hero.HorizontalVelocity = 
                    Math.Sign(hero.HorizontalVelocity) * Math.Max(0, Math.Abs(hero.HorizontalVelocity) - dt / 100 * G);
                hero.Move(
                    hero.Manipulator.PreRightOrLeftMove(new Point((int) hero.HorizontalVelocity, 0), map)
                    );
            }
        }

        private bool CheckOnFall()
        {
            var hero = level.CurrentHero;
            var map = level.GetCurrentMap();
            for (var i = 0; i <= hero.Size.Width; i++)
                if (!map.IsBound(new Point(hero.Location.X, hero.Location.Y + hero.Size.Height + 1)) ||
                    map.IsBlock(new Point(hero.Location.X, hero.Location.Y + hero.Size.Height + 1)))
                    return false;
            return true;
        }

        private bool CheckOnJump() => level.CurrentHero.UpVelocity > 0;

        private bool CheckOnHorizontalMove() => level.CurrentHero.HorizontalVelocity != 0;
    }
}