namespace GameModel.Model.Data
{
    public interface ICombat
    {
        public int Health { get; }
        public int Attack { get; }
        public bool IsReadyToAttack { get; set; }
        public int Stamina { get; }
        public int Cooldown { get; }
        public void GetDamage(int damage);
        public void DoDamage(IEntity enemy, int damage);
    }
}