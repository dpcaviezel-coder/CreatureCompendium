using Newtonsoft.Json;

namespace CreatureCompendium
{
    public class CreatureCompendium
    {
        public List<Creature> Creatures { get; set; }
        public CreatureCompendium()
        {
            Creatures = new List<Creature>();
        }
        public void AddCreature(Creature creature)
        {
            Creatures.Add(creature);
        }

        public void RemoveCreature(Creature creature)
        {
            Creatures.Remove(creature);
        }

        public void EditCreature(Creature creature, string name, CreatureType type, int hP, int mP, int attack, int defense, int speed, List<Move> moves, Habitat habitat, Rarity rarity, string description, string evolvesTo)
        {
            creature.Name = name;
            creature.CreatureType = type;
            creature.HP = hP;
            creature.MP = mP;
            creature.Attack = attack;
            creature.Defense = defense;
            creature.Speed = speed;
            creature.Moves = moves;
            creature.Habitat = habitat;
            creature.Rarity = rarity;
            creature.Description = description;
            creature.CreatureEvolvesTo = evolvesTo;
        }

        public void SearchCreature(string name)
        {
            var creature =
                Creatures.FirstOrDefault(
                    c => c.Name.Equals(
                        name,
                        StringComparison.OrdinalIgnoreCase));

            if (creature != null)
            {
                creature.DisplayCreatureInfo();
            }
            else
            {
                Console.WriteLine(
                    $"Creature '{name}' not found.");
            }
        }

        public void SaveCreatureToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(Creatures, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void LoadCreatureFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Creatures =
                    JsonConvert.DeserializeObject<List<Creature>>(json)
                    ?? new List<Creature>();

            }
            else
            {
                Console.WriteLine($"File '{filePath}' not found.");
            }
        }

        public Creature? GetCreatureByName(string name)
        {
            return Creatures.FirstOrDefault(
                c => c.Name.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase));
        }

        public void GetCreatureByFirstLetter(char letter)
        {
            var matches = Creatures.Where(
                c => c.Name.StartsWith(
                    letter.ToString(),
                    StringComparison.OrdinalIgnoreCase));

            if (!matches.Any())
            {
                Console.WriteLine(
                    $"No creatures found beginning with '{letter}'.");
                return;
            }

            foreach (var creature in matches)
            {
                creature.DisplayCreatureInfo();
            }
        }

        public void GetCreatureByHabitat(
            Habitat habitat)
        {
            var matches =
                Creatures.Where(
                    c => c.Habitat == habitat);

            foreach (var creature in matches)
            {
                creature.DisplayCreatureInfo();
            }
        }

        public void GetCreatureByType(
            CreatureType type)
        {
            var matches =
                Creatures.Where(
                    c => c.CreatureType == type);

            foreach (var creature in matches)
            {
                creature.DisplayCreatureInfo();
            }
        }

        public void GetCreatureByRarity(
            Rarity rarity)
        {
            var matches =
                Creatures.Where(
                    c => c.Rarity == rarity);

            foreach (var creature in matches)
            {
                creature.DisplayCreatureInfo();
            }
        }

        public void DisplayAllCreatures()
        {
            foreach (var creature in Creatures)
            {
                creature.DisplayCreatureInfo();
            }
        }
    }
}