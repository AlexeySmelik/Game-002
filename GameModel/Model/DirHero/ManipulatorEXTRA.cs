using System;
using System.Drawing;
using System.Linq.Expressions;

namespace Game002.Model.DirHero
{
    public partial class Manipulator
    {
        private const int K = 0; // Up padding const
        
        public Point PreDownOrUpMove(Point dp, Map map) //TODO Testing
        {
            if (dp.X != 0)
                throw new ArgumentException("The X coordinate in PreDownOrUpMove method is not zero, but should");
            if (dp.Y == 0)
                return new Point(0, 0);
            var nLPoint = new Point(
                hero.Location.X, 
                 hero.Location.Y + dp.Y + (dp.Y > 0 ? hero.Size.Height : 0));
            for (var i = 0; i < hero.Size.Width; i++)
            {
                var cLPoint = new Point(nLPoint.X + i, nLPoint.Y);
                if (!map.IsBound(cLPoint))
                    return new Point(0, dp.Y > 0 ? map.Height - nLPoint.Y + dp.Y : -hero.Location.Y);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        0,
                        dp.Y > 0 ?
                            cLPoint.Y / map.CellSize * map.CellSize - nLPoint.Y + dp.Y + K :
                            cLPoint.Y / map.CellSize * map.CellSize - hero.Location.Y + map.CellSize);
            }
            return dp;
        }
        
        public Point PreRightOrLeftMove(Point dp, Map map)
        {
            if (dp.Y != 0)
                throw new ArgumentException("The Y coordinate in PreRightOrLeftMove method is not zero, but should");
            if (dp.X == 0)
                return new Point(0, 0);
            var nLPoint = new Point(
                hero.Location.X + dp.X + (dp.X > 0 ? hero.Size.Width : 0), 
                hero.Location.Y);
            for (var i = 0; i < hero.Size.Height - K; i++)
            {
                var cLPoint = new Point(nLPoint.X, nLPoint.Y + i);
                if (!map.IsBound(cLPoint))
                    return new Point(
                        dp.X > 0 ?
                            map.Width - hero.Location.X - hero.Size.Width :
                            -hero.Location.X,
                        0);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        dp.X > 0 ?
                            cLPoint.X / map.CellSize * map.CellSize - hero.Location.X - hero.Size.Width :
                            cLPoint.X / map.CellSize * map.CellSize - hero.Location.X + map.CellSize,
                           0);
            }
            return dp;
        }
    }
}