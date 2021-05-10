using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameModel.Model.DirEntity
{
    public partial class Manipulator
    {
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

        private int _ticks; 

        public void TryDamage(IEnumerable<IEntity> entities)
        {
            if (((ICombat) _entity).IsReadyToAttack &&
                _ticks % ((ICombat)_entity).Cooldown == 0)
                entities.ForEach(it =>
                {
                    var r1 = new Rectangle(it.Location, it.Size);
                    var r2 = new Rectangle(
                        new Point(
                            _entity.Direction == Direction.Right ?
                                _entity.Location.X + _entity.Size.Width / 2 :
                                _entity.Location.X - 25, _entity.Location.Y),
                        _entity.Size);
                    if (Rectangle.Intersect(r1, r2) != Rectangle.Empty &&
                        ((ICombat) _entity).IsReadyToAttack)
                    {
                        DoDamage(it as ICombat);
                        ((ICombat) _entity).IsReadyToAttack = false;
                        _ticks++;
                    }
                });
            else if (_ticks > 0)
                _ticks = (1 + _ticks) % ((ICombat)_entity).Cooldown;
            ((ICombat) _entity).IsReadyToAttack = false;
        }


        private void DoDamage(ICombat e)
        {
            _ticks = 0;
            e.GetDamage(((ICombat) _entity).Attack);
        }
    }
}