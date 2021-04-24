using System;
using GameModel.Model.DirEntity;

namespace GameModel.Model.DirHero
{
    public partial class Manipulator
    {
        private const int RALS = 30; // Right and left step
        private readonly IEntity entity;
        
        public Manipulator(IEntity entity) => this.entity = entity;
        
        public void SetHorizontalVelocity(int direction, int step = RALS)
        {
            if (Math.Abs(direction) != 1)
                throw new Exception("Direction should be 1 or -1");
            entity.HorizontalVelocity = direction * step;
        }

        public void SetUpVelocity(int step = RALS, bool isJump = true)
        {
            if (isJump && entity.UpVelocity == 0 || !isJump)
                entity.UpVelocity = step;
        }
    }
}