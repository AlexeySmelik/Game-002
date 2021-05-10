using System.Linq;

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
                SimpleEntityAi.TryAttackHero(it, hero, 5);
            });
        }
    }
}