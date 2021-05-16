using System.Drawing;
using System.Linq;
using GameModel.Model.Data;
using GameModel.Model.Manipulators;

namespace GameModel.Model.Mobs
{
    public static class MobManager
    { 
        public static void MakeMove(Map map, Hero hero)
        {
            map.MobList
                .Where(it => it.IsActive)
                .ForEach(it =>
            {
                if (it.Name == "Pudge")
                {
                    it.CombatManipulator.Rot(new[] {hero}, 1);
                    UpdateXPosition(hero, it, 10);
                    it.CombatManipulator.RestoreStamina(1);
                    TryAttackEntity(it, hero, 50);
                }
                else if (it.Name == "Creeper")
                {
                    UpdateXPosition(hero, it, 20);
                    UpdateYPosition(hero, it, 20);
                    var range = new Rectangle(it.Location, it.Size);
                    it.CombatManipulator.IsReadyToAttack = it.CombatManipulator.IsReadyToAttack ||
                                                           CombatManipulator.IsItInRange(hero, range);
                    it.CombatManipulator.TryExplode(new[] {hero});
                }
                else
                {
                    UpdateXPosition(hero, it, 29);
                    UpdateYPosition(hero, it, 29);
                    it.CombatManipulator.RestoreStamina(1);
                    TryAttackEntity(it, hero, 40);
                }
            });
        }

        private static void TryAttackEntity(IEntity entity1, IEntity entity2, int cost)
        {
            var range = new Rectangle(
                new Point(
                    entity1.Location.X + (int) entity1.Direction * entity1.Size.Width / 2,
                    entity1.Location.Y),
                entity1.Size);
            if (CombatManipulator.IsItInRange(entity2, range))
            {
                entity1.CombatManipulator.IsReadyToAttack = true;
                entity1.CombatManipulator.DoSimpleAttack(new []{entity2}, cost);
            }
        }

        private static void UpdateXPosition(IEntity hero, IEntity enemy, int step)
        {
            enemy.MovementManipulator
                .SetHorizontalVelocity(hero.Location.X > enemy.Location.X ? 1 : -1, step);
        }

        private static void UpdateYPosition(IEntity hero, IEntity enemy, int step)
        {
            if (hero.Location.Y < enemy.Location.Y)
                enemy.MovementManipulator.SetUpVelocity(step);
        }
    }
}