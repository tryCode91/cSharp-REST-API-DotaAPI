namespace DotaAPI.Models
{
    // Attributes, could not be called that because its reserved keyword in C#. So i went with characteristic
    public class Characteristic
    {
        public int CharacteristicId { get; set; }
        public string HP { get; set; }
        public string Mana { get; set; }
        public string Strength { get; set; }
        public string Agility { get; set; }
        public string Intelligence { get; set; }
        public int? HeroId { get; set; }
        public Hero? Hero { get; set; }
    }
}
