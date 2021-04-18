using System;
using System.Drawing;
using System.Linq.Expressions;

namespace Game002.Model.DirHero
{
    public partial class Manipulator
    {
        public void SetStopMoves(Map map)
        {
            var c11 = CurrentHero.Location;
            var c12 = new Point(CurrentHero.Location.X + CurrentHero.Size.Width, CurrentHero.Location.Y);
            var c21 = new Point(CurrentHero.Location.X, CurrentHero.Location.Y + CurrentHero.Size.Height);
            var c22 = new Point(CurrentHero.Location.X + CurrentHero.Size.Width, CurrentHero.Location.Y + CurrentHero.Size.Height);
            
        }
        
        public Point PreDownOrUpMove(Point dp, Map map) //TODO Testing
        {
            if (dp.X != 0)
                throw new ArgumentException("The X coordinate in PreDownOrUpMove method is not zero, but should");
            if (dp.Y == 0)
                return new Point(0, 0);
            var nLPoint = new Point(
                CurrentHero.Location.X, 
                 CurrentHero.Location.Y + dp.Y + dp.Y > 0 ? CurrentHero.Size.Height : 0);
            var checkPoints = CurrentHero.Size.Width / map.CellSize;
            for (var i = 0; i < checkPoints; i++)
            {
                var cLPoint = new Point(nLPoint.X + i * (map.CellSize - 1), nLPoint.Y);
                if (!map.IsBound(cLPoint))
                    return new Point(0, dp.Y > 0 ? map.Height - nLPoint.Y + dp.Y : -CurrentHero.Location.Y);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        0,
                        dp.Y > 0 ?
                            cLPoint.Y / map.CellSize * map.CellSize - nLPoint.Y + dp.Y + map.CellSize / 3 :
                            cLPoint.Y / map.CellSize * map.CellSize - CurrentHero.Location.Y + map.CellSize);
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
                CurrentHero.Location.X + dp.X + dp.X > 0 ? CurrentHero.Size.Width : 0, 
                CurrentHero.Location.Y);
            var checkPoints = CurrentHero.Size.Height / map.CellSize;
            for (var i = 0; i < checkPoints; i++)
            {
                var cLPoint = new Point(nLPoint.X, nLPoint.Y + i * (map.CellSize - 1));
                if (!map.IsBound(cLPoint))
                    return new Point(dp.X > 0 ? map.Width - nLPoint.X + dp.X : -CurrentHero.Location.X, 0);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        dp.X > 0 ?
                            cLPoint.X / map.CellSize * map.CellSize - nLPoint.X + dp.X + map.CellSize :
                            cLPoint.X / map.CellSize * map.CellSize - CurrentHero.Location.X + map.CellSize,
                           0);
            }
            return dp;
        }
    }
}