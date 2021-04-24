using System.Linq;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;
using GameModel.Model.Mobs;

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
                if (it.Name == "Creeper")
                    CreeperAI.SetVelocity(hero, it as Mob, map);
            });
        }
    }
}