namespace DotaAPI.Dto
{
    public class StatsDto
    {
        public int StatsId { get; set; }
        public int Attack { get; set; }
        public double AttackTime { get; set; }
        public int AttackRange { get; set; }
        public int ProjectileSpeed { get; set; }
        public double Defence { get; set; }
        public string MagicResist { get; set; }
        public int MovementSpeed { get; set; }
        public double TurnRate { get; set; }
        public string Vision { get; set; }
    }
}
