namespace GameModel.Model.Manipulators
{
    public class CooldownTimer
    {
        private readonly int _cooldown;
        
        public int Ticks { get; private set; }
        
        public CooldownTimer(int cooldown)
        {
            Ticks = 0;
            _cooldown = cooldown;
        }
        
        public void Tick() => Ticks = (Ticks + 1) % _cooldown;
    }
}