namespace GameModel.Model.DirEntity
{
    public interface IPVP
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public void GetDamage(int damage);
    }
}