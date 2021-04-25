using System;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace GameModel.Model.Mobs
{
    public class SimpleFiendAI
    {
        public static void SetVelocity(Hero hero, Mob sasuke, Map map) //TODO Tests
        {
            sasuke.Manipulator
                .SetHorizontalVelocity(hero.Location.X > sasuke.Location.X ? 1 : -1);
            
            if (hero.Location.Y < sasuke.Location.Y)
                sasuke.Manipulator.SetUpVelocity(29);
        }

        public static void TryAttack(Hero hero, Mob sasuke)
        {
            sasuke.IsReadyToAttack = true;
            sasuke.Manipulator.TryDamage(new [] {hero});
        }
    }
}