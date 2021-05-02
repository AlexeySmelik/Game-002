namespace GameModel.Model.DirEntity
{
    public interface IDangerous : IEntity
    {
        public int Health { get; }
        public int Attack { get; }
        public int Cooldown { get; set; }
        public void GetDamage(int damage);
        public bool IsReadyToAttack { get; set; }
    }
}