namespace GameModel.Model.Mobs
{
    public static class SimpleFiendAi
    {
        public static void SetVelocity(Hero hero, Mob fiend, Map map) //TODO Tests
        {
            fiend.Manipulator
                .SetHorizontalVelocity(hero.Location.X > fiend.Location.X ? 1 : -1);
            
            if (hero.Location.Y < fiend.Location.Y)
                fiend.Manipulator.SetUpVelocity();
        }

        public static void TryAttack(Hero hero, Mob fiend)
        {
            fiend.IsReadyToAttack = true;
            fiend.Manipulator.TryDamage(new [] {hero});
        }
    }
}