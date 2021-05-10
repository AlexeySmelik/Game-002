using System.Drawing;
using GameModel.Model.Data;

namespace GameModel.Model.Mobs
{
    public static class SimpleEntityAi
    {
        public static void GoToHero(Hero hero, IEntity enemy)
        {
            enemy.MovementManipulator
                .SetHorizontalVelocity(hero.Location.X > enemy.Location.X ? 1 : -1, 10);
            
            if (hero.Location.Y < enemy.Location.Y)
                enemy.MovementManipulator.SetUpVelocity();
        }

        public static void TryAttackHero(IEntity entity, IEntity hero, int cost)
        {
            var r1 = new Rectangle(hero.Location, hero.Size);
            var r2 = new Rectangle(
                new Point(
                    entity.Location.X + (int) entity.Direction * entity.Size.Width / 2,
                    entity.Location.Y),
                entity.Size);
            if (Rectangle.Intersect(r1, r2) != Rectangle.Empty)
            {
                entity.CombatManipulator.IsReadyToAttack = true;
                entity.CombatManipulator.DoSimpleAttack(new []{hero}, cost);
            }
        }
    }
}