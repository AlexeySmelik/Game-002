namespace GameModel.Model.Mobs
{
    public static class PudgeAi
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
        
        private static int _ticks;
        
        public static void DoRot(Hero hero, Mob pudge)
        {
            hero.GetDamage(_ticks++ % (pudge.Cooldown / 4) == 0 ? 1 : 0);
            pudge.GetDamage(pudge.Health > 50 ? _ticks++ % (pudge.Cooldown / 4) == 0 ? 1 : 0 : 0);
        }
    }
}