using System.Linq;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace GameModel.Model
{
    public static class MobsController
    { 
        public static void MakeMove(Map map, Hero hero)
        {
            map.MobList
                .Where(it => it.IsActive())
                .ForEach(it =>
            {
                if (it is Creeper creeper)
                    CreeperAI.SetVelocity(hero, creeper, map);
            });
        }
    }
}