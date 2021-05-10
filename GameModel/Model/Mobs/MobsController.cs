using System.Linq;

namespace GameModel.Model.Mobs
{
    public static class MobsController
    { 
        public static void MakeMoveAndAttack(Map map, Hero hero)
        {
            map.MobList
                .Where(it => it.IsActive())
                .ForEach(it =>
            {
                if (it.Name == "Creeper")
                {
                    CreeperAi.SetVelocity(hero, it, map);
                    CreeperAi.TryAttack(hero, it);
                }

                if (it.Name == "SimpleFiend")
                {
                    SimpleFiendAi.SetVelocity(hero, it, map);
                    SimpleFiendAi.TryAttack(hero, it);
                }

                if (it.Name == "Pudge")
                {
                    PudgeAi.SetVelocity(hero, it);
                    PudgeAi.DoRot(hero, it);
                    PudgeAi.TryAttack(hero, it);
                }
            });
        }
    }
}