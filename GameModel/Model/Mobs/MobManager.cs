using System.Drawing;
using System.Linq;
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
                SimpleEntityAi.GoToHero(hero, it);
                if (it.Name == "Pudge")
                {
                    it.CombatManipulator.Rot(new[] {hero}, 1);
                    SimpleEntityAi.TryAttackHero(it, hero, 5);
                }
                if (it.Name == "Creeper")
                {
                    var range = new Rectangle(it.Location, it.Size);
                    it.CombatManipulator.IsReadyToAttack = it.CombatManipulator.IsReadyToAttack ||
                                                           CombatManipulator.IsItInRange(hero, range);
                    it.CombatManipulator.TryExplode(new[] {hero});
                }
                else
                {
                    SimpleEntityAi.TryAttackHero(it, hero, 5);
                }
            });
        }
    }
}