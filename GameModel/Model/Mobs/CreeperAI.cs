using System.Drawing;
using GameModel.Model.DirHero;

namespace GameModel.Model.DirEntity
{
    public static class CreeperAI
    {
        public static void SetVelocity(Hero hero, Creeper creeper, Map map) //TODO Tests
        {
            if (hero.Location.X < creeper.Location.X)
            {
                creeper.Manipulator.SetHorizontalVelocity(-1, 15);
            }
            else
            {
                creeper.Manipulator.SetHorizontalVelocity(1, 15);
            }
            
            if (hero.Location.Y < creeper.Location.Y)
            {
                creeper.Manipulator.SetUpVelocity();
            }
        }
        
        private static bool IsExplosion(Hero hero, Creeper creeper) //TODO Tests
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