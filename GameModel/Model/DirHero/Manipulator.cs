using GameModel.Model.DirEntity;

namespace GameModel.Model.DirHero
{
    public partial class Manipulator
    {
        private const int RALS = 30; // Right and left step

        private readonly IEntity entity;
        
        public Manipulator(IEntity entity) => this.entity = entity;
        
        public void LeftMove()
        {
            entity.HorizontalVelocity = -RALS;
        }

        public void RightMove()
        {
            entity.HorizontalVelocity = RALS;
        }

        public void SpaceMove()
        {
            if (entity.UpVelocity == 0)
                entity.UpVelocity = 39;
        }
    }
}