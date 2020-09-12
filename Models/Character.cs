namespace _dotnetSandBox.Models
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; } = "frodo";
        public int hitpoints { get; set; } = 100;
        public int strenght { get; set; } = 10;
        public int defense { get; set; } = 10;
        public int intelligence { get; set; } = 10;
        public RpgClass playClass { get; set; } = RpgClass.knight;
    }
}