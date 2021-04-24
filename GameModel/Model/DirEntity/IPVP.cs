namespace GameModel.Model.DirEntity
{
    public interface IPVP
    {
        public int Health { get; }
        public int Attack { get; set; }
        public int Cooldown { get; set; }
        public void GetDamage(int damage);
    }
}