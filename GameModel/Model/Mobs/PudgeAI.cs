using System.Drawing;
using GameModel.Model.DirHero;

namespace GameModel.Model.Mobs
{
    public class PudgeAI
    {
        public static void SetVelocity(Hero hero, Mob pudge, Map map) //TODO Tests
        {
            pudge.Manipulator
                .SetHorizontalVelocity(hero.Location.X > pudge.Location.X ? 1 : -1, 10);
        }
        
        public static void TryAttack(Hero hero, Mob pudge)
        {
            DoRot(hero, pudge);
            pudge.IsReadyToAttack = true;
            pudge.Manipulator.TryDamage(new [] {hero});
        }
        
        private static void DoRot(Hero hero, Mob pudge)
        {
            hero.GetDamage(pudge.Attack / 50);
        }
    }
}