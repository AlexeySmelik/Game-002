using System;
using System.Drawing;

namespace Game002.Model.DirHero
{
    public partial class Manipulator
    {
        public void PreRightMove(Map map)
        {
            var dp = new Point(CurrentHero.StepSize, 0);
            var n = Math.Ceiling(1.0 * CurrentHero.Size.Width / map.CellSize);
            for (var i = 0; i < n; i++)
            {
                var checkPoint = new Point(
                    CurrentHero.Location.X + dp.X + CurrentHero.Size.Width,
                    CurrentHero.Location.Y + i * map.CellSize);
                if (!map.IsBound(checkPoint) && checkPoint.X >= map.Width)
                {
                    CurrentHero.Move(new Point(map.Width - CurrentHero.Location.X - CurrentHero.Size.Width, 0));
                    return;
                }
                if (map.IsBound(checkPoint) && map.IsBlock(checkPoint))
                {
                    CurrentHero.Move(
                        new Point(
                            checkPoint.X / map.CellSize * map.CellSize - CurrentHero.Location.X - CurrentHero.Size.Width,
                            0)
                    );
                    return;
                }
            }
            CurrentHero.Move(dp);
        }
        
        public void PreLeftMove(Map map)
        {
            var dp = new Point(-CurrentHero.StepSize, 0);
            var n = Math.Ceiling(1.0 * CurrentHero.Size.Width / map.CellSize);
            for (var i = 0; i < n; i++)
            {
                var checkPoint = new Point(
                    CurrentHero.Location.X + dp.X,
                    CurrentHero.Location.Y + i * map.CellSize);
                if (!map.IsBound(checkPoint) && 0 > checkPoint.X)
                {
                    CurrentHero.Move(new Point(-CurrentHero.Location.X, 0));
                    return;
                }
                if (map.IsBound(checkPoint) && map.IsBlock(checkPoint))
                {
                    CurrentHero.Move(
                        new Point(
                            checkPoint.X / map.CellSize * map.CellSize - CurrentHero.Location.X + map.CellSize,
                            0)
                    );
                    return;
                }
            }
            CurrentHero.Move(dp);
        }
        
        public void PreUpMove(Map map) //TODO Testing and refactoring
        {
            var dp = new Point(0, -(int) CurrentHero.UpVelocity);
            var n = Math.Ceiling(1.0 * CurrentHero.Size.Width / map.CellSize);
            for (var i = 0; i < n; i++)
            {
                var checkPoint = new Point(
                    CurrentHero.Location.X + i * map.CellSize,
                    CurrentHero.Location.Y + dp.Y);
                if (!map.IsBound(checkPoint) && checkPoint.Y < 0)
                {
                    CurrentHero.Move(new Point(0, -CurrentHero.Location.Y));
                    return;
                }
                if (map.IsBound(checkPoint) && map.IsBlock(checkPoint))
                {
                    CurrentHero.Move(
                        new Point(
                            0,
                            checkPoint.Y / map.CellSize * map.CellSize - CurrentHero.Location.Y + 4 * map.CellSize / 3)
                    );
                    return;
                }
            }
            CurrentHero.Move(dp);
        }
        
        public void PreDownMove(Map map) //TODO Testing
        {
            var dp = new Point(0, (int) CurrentHero.DownVelocity);
            var n = Math.Ceiling(1.0 * CurrentHero.Size.Width / map.CellSize);
            for (var i = 0; i < n; i++)
            {
                var checkPoint = new Point(
                    CurrentHero.Location.X + i * map.CellSize,
                    CurrentHero.Location.Y + CurrentHero.Size.Height + dp.Y);
                if (!map.IsBound(checkPoint) && checkPoint.Y >= map.Height)
                {
                    CurrentHero.Move(new Point(0, map.Height - CurrentHero.Location.Y - CurrentHero.Size.Height));
                    //DEATH
                    return;
                }
                if (map.IsBound(checkPoint) && map.IsBlock(checkPoint))
                {
                    CurrentHero.Move(
                        new Point(
                            0,
                            checkPoint.Y / map.CellSize * map.CellSize - CurrentHero.Location.Y - CurrentHero.Size.Height + map.CellSize / 3)
                        );
                    return;
                }
            }
            CurrentHero.Move(dp);
        }
    }
}