namespace DotaAPI.Models
{
    public class Ability
    {
        public int AbilityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsScepterUpgradeable { get; set; }
        public string Cooldown { get; set; }
        public string ManaCost{ get; set; }
        public AbilityDetail? AbilityDetail { get; set; }
        public ICollection<HeroAbility>? HeroAbilities { get; set; }
    }
}
