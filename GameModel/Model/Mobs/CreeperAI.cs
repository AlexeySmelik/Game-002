using System.Drawing;
using GameModel.Model.DirHero;

namespace GameModel.Model.DirEntity
{
    public class CreeperAI
    {
        private readonly Hero hero;
        private readonly Creeper currentCreeper;
        private readonly Map map;
        private readonly int cooldown;
        
        private int waitTime;

        public CreeperAI(Hero hero, Creeper creeper, Map map, int interval)
        {
            this.hero = hero;
            currentCreeper = creeper;
            this.map = map;
            cooldown = interval * 20;
            waitTime = 0;
        }

        public void SetVelocity() //TODO Tests
        {
            if (hero.Location.X < currentCreeper.Location.X)
            {
                currentCreeper.Manipulator.SetHorizontalVelocity(-1, 15);
            }
            else
            {
                currentCreeper.Manipulator.SetHorizontalVelocity(1, 15);
            }
            
            if (hero.Location.Y < currentCreeper.Location.Y)
            {
                currentCreeper.Manipulator.SetUpVelocity();
            }
        }

        public void TryDamage()
        {
            if (IsExplosion() && waitTime == 0)
                hero.GetDamage(currentCreeper.Attack);
            waitTime = (waitTime + cooldown / 20) % cooldown;
        }

        private bool IsExplosion() //TODO Tests
        {
            var r1 = new Rectangle(hero.Location, hero.Size);
            var r2 = new Rectangle(currentCreeper.Location, currentCreeper.Size);
            return r1.Bottom >= r2.Top &&
                   r1.Right >= r2.Left &&
                   r2.Bottom >= r1.Top &&
                   r2.Right >= r1.Left; // are intersected
        }
    }
}