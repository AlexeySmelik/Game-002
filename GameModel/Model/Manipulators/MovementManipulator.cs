using System;
using System.Drawing;
using GameModel.Model.Data;

namespace GameModel.Model.Manipulators
{
    public class MovementManipulator
    {
        private const int BasicHorizontalVelocity = 29;
        private readonly IEntity _entity;
        
        public MovementManipulator(IEntity entity) => _entity = entity;
        
        public void SetHorizontalVelocity(int direction, int step = BasicHorizontalVelocity)
        {
            if (Math.Abs(direction) != 1)
                throw new Exception("Direction should be 1 or -1");
            _entity.HorizontalVelocity = direction * step;
            _entity.Direction = (Direction) direction;
        }

        public void SetUpVelocity(int step = BasicHorizontalVelocity)
        {
            if (_entity.UpVelocity == 0)
                _entity.UpVelocity = step;
        }
        
        public Point PreDownOrUpMove(Point dp, Map map)
        {
            if (dp.X != 0)
                throw new ArgumentException("The X coordinate in PreDownOrUpMove method is not zero, but should");
            if (Math.Abs(dp.Y) > map.CellSize)
                throw new ArgumentException("Change in Y must not exceed the block height");
            if (dp.Y == 0)
                return new Point(0, 0);
            var nLPoint = new Point(
                _entity.Location.X,
                 _entity.Location.Y + dp.Y + (dp.Y > 0 ? _entity.Size.Height : 0));
            for (var i = 0; i < _entity.Size.Width; i++)
            {
                var cLPoint = new Point(nLPoint.X + i, nLPoint.Y);
                if (!map.IsBound(cLPoint))
                    return new Point(0, dp.Y > 0 ? map.Size.Height - nLPoint.Y + dp.Y : -_entity.Location.Y);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        0,
                        dp.Y > 0 ?
                            cLPoint.Y / map.CellSize * map.CellSize - nLPoint.Y + dp.Y :
                            cLPoint.Y / map.CellSize * map.CellSize - _entity.Location.Y + map.CellSize);
            }
            return dp;
        }
        
        public Point PreRightOrLeftMove(Point dp, Map map)
        {
            if (dp.Y != 0)
                throw new ArgumentException("The Y coordinate in PreRightOrLeftMove method is not zero, but should");
            if (Math.Abs(dp.X) > map.CellSize)
                throw new ArgumentException("Change in X must not exceed the block width");
            if (dp.X == 0)
                return new Point(0, 0);
            var nLPoint = new Point(
                _entity.Location.X + dp.X + (dp.X > 0 ? _entity.Size.Width : 0), 
                _entity.Location.Y);
            for (var i = 0; i < _entity.Size.Height; i++)
            {
                var cLPoint = new Point(nLPoint.X, nLPoint.Y + i);
                if (!map.IsBound(cLPoint))
                    return new Point(
                        dp.X > 0 ?
                            map.Size.Width - _entity.Location.X - _entity.Size.Width :
                            -_entity.Location.X,
                        0);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        dp.X > 0 ?
                            cLPoint.X / map.CellSize * map.CellSize - _entity.Location.X - _entity.Size.Width :
                            cLPoint.X / map.CellSize * map.CellSize - _entity.Location.X + map.CellSize,
                           0);
            }
            return dp;
        }
    }
}