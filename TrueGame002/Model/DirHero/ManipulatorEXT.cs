using System;
using System.Drawing;

namespace TestGame002.Model.DirHero
{
    public partial class Manipulator
    {
        public void PreDownMove(Map map) //TODO test
        {
            var dp = new Point(0, (int) CurrentHero.DownVelocity);
            var n = Math.Ceiling(1.0 * CurrentHero.Size.Width / map.CellSize);
            for (var i = 0; i < n; i++)
            {
                var checkPoint = new Point(
                    CurrentHero.Location.X + i * map.CellSize,
                    CurrentHero.Location.Y + CurrentHero.Size.Height + dp.Y);
                if (!map.IsBound(checkPoint))
                {
                    CurrentHero.Move(
                        new Point(
                            0,
                            map.Height - CurrentHero.Location.Y - CurrentHero.Size.Height)
                        );
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