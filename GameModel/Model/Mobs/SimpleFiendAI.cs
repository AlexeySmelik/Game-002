using System;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace GameModel.Model.Mobs
{
    public class SimpleFiendAI
    {
        public static void SetVelocity(Hero hero, Mob fiend, Map map) //TODO Tests
        {
            fiend.Manipulator
                .SetHorizontalVelocity(hero.Location.X > fiend.Location.X ? 1 : -1);
            
            if (hero.Location.Y < fiend.Location.Y)
                fiend.Manipulator.SetUpVelocity(29);
        }

        public static void TryAttack(Hero hero, Mob fiend)
        {
            fiend.IsReadyToAttack = true;
            fiend.Manipulator.TryDamage(new [] {hero});
        }
    }
}