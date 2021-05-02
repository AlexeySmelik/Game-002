using System.Drawing;
using GameModel.Model.DirHero;

namespace GameModel.Model.Mobs
{
    public static class PudgeAI
    {
        public const int PudgeStep = 10;
        public static void SetVelocity(Hero hero, Mob pudge) //TODO Tests
        {
            pudge.Manipulator.SetHorizontalVelocity(hero.Location.X > pudge.Location.X ? 1 : -1, PudgeStep);
        }
        
        public static void TryAttack(Hero hero, Mob pudge)
        {
            pudge.IsReadyToAttack = true;
            pudge.Manipulator.TryDamage(new [] {hero});
        }
        
        private static int ticks;
        
        public static void DoRot(Hero hero, Mob pudge)
        {
            hero.GetDamage(ticks++ % (pudge.Cooldown / 4) == 0 ? 1 : 0);
            pudge.GetDamage(pudge.Health > 50 ? ticks++ % (pudge.Cooldown / 4) == 0 ? 1 : 0 : 0);
        }
    }
}