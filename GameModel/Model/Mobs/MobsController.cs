using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace GameModel.Model
{
    public static class MobsController
    {
        public static void SetMobsOnMap(Map map, Hero hero, int t)
        {
            SetMobAi(map, hero, t);
        }

        public static void MakeMove(Map map)
        {
            map.MobList.ForEach(
                it =>
                {
                    if (it is Creeper creeper)
                        creeper.AI.SetVelocity();
                });
        }

        private static void SetMobAi(Map map, Hero hero, int t)
        {
            map.MobList.ForEach(
                it =>
                {
                    if (it is Creeper creeper)
                        creeper.AI = new CreeperAI(hero, creeper, map, t);
                }
            );
        }
    }
}