namespace DotaAPI.Dto
{
    public class AbilityDto
    {
        public int AbilityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsScepterUpgradeable { get; set; }
        public string Cooldown { get; set; }
        public string ManaCost { get; set; }
    }
}
