using System;

namespace GameModel.Model.DirEntity
{
    public partial class Manipulator
    {
        private const int BasicHorizontalVelocity = 29;
        private readonly IEntity _entity;
        
        public Manipulator(IEntity entity) => _entity = entity;
        
        public void SetHorizontalVelocity(int direction, int step = BasicHorizontalVelocity)
        {
            if (Math.Abs(direction) != 1)
                throw new Exception("Direction should be 1 or -1");
            _entity.HorizontalVelocity = direction * step;
            _entity.Direction = direction == 1 ? Direction.Right : Direction.Left;
        }

        public void SetUpVelocity(int step = BasicHorizontalVelocity, bool isJump = true)
        {
            if (isJump && _entity.UpVelocity == 0 || !isJump)
                _entity.UpVelocity = step;
        }
    }
}