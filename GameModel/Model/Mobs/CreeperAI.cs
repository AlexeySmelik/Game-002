using System.Drawing;
using GameModel.Model.DirHero;
using GameModel.Model.Mobs;

namespace GameModel.Model.DirEntity
{
    public static class CreeperAI
    {
        private const int TimeToExplosion = 5; // 150 / TimerInterval = TimeToExplosion
        
        public static void SetVelocity(Hero hero, Mob creeper, Map map) //TODO Tests
        {
            creeper.Manipulator
                .SetHorizontalVelocity(hero.Location.X < creeper.Location.X ? -1 : 1, 15);
            
            if (hero.Location.Y < creeper.Location.Y)
                creeper.Manipulator.SetUpVelocity(29, false);
            
            TryAttack(hero, creeper);
        }

        private static void TryAttack(Hero hero, Mob creeper)
        {
            if (IsExplosion(hero, creeper) && creeper.Cooldown == TimeToExplosion)
            {
                creeper.GetDamage(creeper.Health);
                hero.GetDamage(creeper.Attack);
            } 
            else if (IsExplosion(hero, creeper))
                creeper.Cooldown++;
            else
                creeper.Cooldown = 0;
        }
        
        private static bool IsExplosion(Hero hero, Mob creeper) //TODO Tests
        {
            var r1 = new Rectangle(hero.Location, hero.Size);
            var r2 = new Rectangle(creeper.Location, creeper.Size);
            return r1.Bottom >= r2.Top &&
                   r1.Right >= r2.Left &&
                   r2.Bottom >= r1.Top &&
                   r2.Right >= r1.Left; // are intersected
        }
    }
}