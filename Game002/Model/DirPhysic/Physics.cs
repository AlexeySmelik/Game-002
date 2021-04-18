using System;
using System.Drawing;
using Game002.Model.DirHero;

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
                hero.UpVelocity = Math.Max(0, hero.UpVelocity - dt / 300 * G);
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

        private bool CheckOnJump()
        {
            var hero = level.CurrentHero;
            return hero.UpVelocity > 0;
        }
    }
}