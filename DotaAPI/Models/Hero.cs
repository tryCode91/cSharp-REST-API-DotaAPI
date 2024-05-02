namespace DotaAPI.Models
{
    // Main model
    // has one characteristic
    // has one stats
    // has many abilities

    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Characteristic? Characteristic { get; set; }
        public Stats? Stats { get; set; }
        public ICollection<HeroAbility>? HeroAbilities { get; set; }
    }
}
