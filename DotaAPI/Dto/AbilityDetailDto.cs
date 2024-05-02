namespace DotaAPI.Dto
{
    public class AbilityDetailDto
    {
        public int AbilityDetailId { get; set; }
        public string Affects { get; set; }
        public string DamageType { get; set; }
        public bool PiercesSpellImmunity { get; set; }
        public bool Dispellable { get; set; }
        public string AttackDamageReduction { get; set; }
        public string CastRangeReduction { get; set; }
        public string Duration { get; set; }
        public string Damage { get; set; }
        public string CastRange { get; set; }
    }
}
