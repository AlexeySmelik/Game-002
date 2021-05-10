namespace GameModel.Model.DirEntity
{
    public interface ICombat : IEntity
    {
        public int Health { get; }
        public int Attack { get; }
        public int Stamina { get; }
        public int Cooldown { get; }
        public bool IsReadyToAttack { get; set; }
        public void GetDamage(int damage);
    }
}