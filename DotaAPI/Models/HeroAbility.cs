namespace DotaAPI.Models
{
    public class HeroAbility
    {
        public int HeroId { get; set; }
        public int AbilityId { get; set; }
        public Hero Hero { get; set; }
        public Ability Ability { get; set; }
    }
}
