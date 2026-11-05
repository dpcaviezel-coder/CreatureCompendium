namespace CreatureCompendium
{
    public class Move
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public int MPCost { get; set; } 
        public string Description { get; set; }
        public Move(string name, string type, int power, int accuracy, int mpCost, string description)
        {
            Name = name;
            Type = type;
            Power = power;
            Accuracy = accuracy;
            MPCost = mpCost;    
            Description = description;
        }
    }
}