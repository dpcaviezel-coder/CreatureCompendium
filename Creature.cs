namespace CreatureCompendium
{
    public class Creature
    {
        public string Name { get; set; }
        public CreatureType CreatureType { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public List<Move> Moves { get; set; } = new();
        public Habitat Habitat { get; set; }
        public Rarity Rarity { get; set; }
        public string Description { get; set; }
        public string CreatureEvolvesTo { get; set; } 

        public void DisplayCreatureInfo()
        {
            Console.WriteLine("\n=== Creature Information: ===");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Type: {CreatureType}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"MP: {MP}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Habitat: {Habitat}");
            Console.WriteLine($"Rarity: {Rarity}"); 
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Evolves To: {CreatureEvolvesTo}");
            Console.WriteLine("==============================\n");
            Console.WriteLine("\n=== Moves: ===");
            foreach (var move in Moves)
            {
                Console.WriteLine($"Move Name: {move.Name}");
                Console.WriteLine($"Move Type: {move.Type}");
                Console.WriteLine($"Move Power: {move.Power}");
                Console.WriteLine($"Move Accuracy: {move.Accuracy}");
                Console.WriteLine("================================\n");
            }
        }
    }
}