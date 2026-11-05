using System;

namespace CreatureCompendium
{
    class Program
    {
        static void Main()
        {
            CreatureCompendium compendium = BuildStarterCreatures();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Creature Compendium =====");
                Console.WriteLine("1. View All Creatures");
                Console.WriteLine("2. Search Creature");
                Console.WriteLine("3. Calculate Type Matchup");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Load");
                Console.WriteLine("6. Exit");

                Console.Write("\nChoice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        compendium.DisplayAllCreatures();
                        break;

                    case "2":
                        RunSearch(compendium);
                        break;

                    case "3":
                        RunTypeMatchup(compendium);
                        break;

                    case "4":
                        compendium.SaveCreatureToJson(
                            "creatures.json");

                        Console.WriteLine("Creatures saved.");
                        break;

                    case "5":
                        compendium.LoadCreatureFromJson(
                            "creatures.json");

                        Console.WriteLine("Creatures loaded.");
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine(
                            "Invalid selection.");
                        break;
                }
            }
        }

        static void RunSearch(
            CreatureCompendium compendium)
        {
            Console.WriteLine(
                "\nSearch Method:");

            Console.WriteLine("1. Name");
            Console.WriteLine("2. First Letter");
            Console.WriteLine("3. Habitat");
            Console.WriteLine("4. Type");
            Console.WriteLine("5. Rarity");

            Console.Write("\nChoice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    Console.Write(
                        "Creature Name: ");

                    string? name =
                        Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        compendium.SearchCreature(name);
                    }

                    break;

                case "2":

                    Console.Write(
                        "First Letter: ");

                    string? letter =
                        Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(letter)
                        && letter.Length == 1)
                    {
                        compendium.GetCreatureByFirstLetter(
                            letter[0]);
                    }

                    break;

                case "3":

                    Console.Write(
                        "Habitat: ");

                    string? habitat =
                        Console.ReadLine();

                    if (Enum.TryParse(
                        habitat,
                        true,
                        out Habitat habitatValue))
                    {
                        compendium.GetCreatureByHabitat(
                            habitatValue);
                    }

                    break;

                case "4":

                    Console.Write(
                        "Type: ");

                    string? type =
                        Console.ReadLine();

                    if (Enum.TryParse(
                        type,
                        true,
                        out CreatureType typeValue))
                    {
                        compendium.GetCreatureByType(
                            typeValue);
                    }

                    break;

                case "5":

                    Console.Write(
                        "Rarity: ");

                    string? rarity =
                        Console.ReadLine();

                    if (Enum.TryParse(
                        rarity,
                        true,
                        out Rarity rarityValue))
                    {
                        compendium.GetCreatureByRarity(
                            rarityValue);
                    }

                    break;
            }
        }

        static void RunTypeMatchup(
            CreatureCompendium compendium)
        {
            Console.Write(
                "Attacker: ");

            string attackerName =
                Console.ReadLine() ?? "";

            Console.Write(
                "Defender: ");

            string defenderName =
                Console.ReadLine() ?? "";

            Creature? attacker =
                compendium.GetCreatureByName(
                    attackerName);

            Creature? defender =
                compendium.GetCreatureByName(
                    defenderName);

            if (attacker == null ||
                defender == null)
            {
                Console.WriteLine(
                    "Creature not found.");

                return;
            }

            double multiplier =
                TypeCalculator.GetMultiplier(
                    attacker,
                    defender);

            int damage =
                TypeCalculator.CalculateDamage(
                    attacker,
                    defender);

            Console.WriteLine(
                $"Multiplier: {multiplier}");

            Console.WriteLine(
                $"Damage: {damage}");
        }

        static CreatureCompendium BuildStarterCreatures()
        {
            CreatureCompendium compendium =
                new CreatureCompendium();

            Creature creature1 = new Creature
            {
                Name = "Flametail",
                CreatureType = CreatureType.Fire,
                HP = 100,
                MP = 50,
                Attack = 80,
                Defense = 60,
                Speed = 70,
                Moves = new List<Move>
                {
                    new Move(
                        "Fire Blast",
                        CreatureType.Fire.ToString(),
                        100,
                        80,
                        20,
                        "A powerful fire attack.")
                },
                Habitat = Habitat.Forest,
                Rarity = Rarity.Common,
                Description = "A small dragon that breathes fire.",
                CreatureEvolvesTo = "Ignisaur"
            };

            Creature creature2 = new Creature
            {
                Name = "AquaFin",
                CreatureType = CreatureType.Water,
                HP = 90,
                MP = 60,
                Attack = 70,
                Defense = 65,
                Speed = 75,
                Moves = new List<Move>
                {
                    new Move(
                        "Water Pulse",
                        CreatureType.Water.ToString(),
                        90,
                        85,
                        15,
                        "A pulsing blast of water.")
                },
                Habitat = Habitat.Ocean,
                Rarity = Rarity.Uncommon,
                Description = "A nimble fish with a powerful tail.",
                CreatureEvolvesTo = "Hydrake"
            };

            Creature creature3 = new Creature
            {
                Name = "Leafy",
                CreatureType = CreatureType.Grass,
                HP = 90,
                MP = 70,
                Attack = 60,
                Defense = 70,
                Speed = 80,
                Moves = new List<Move> 
                { 
                    new Move(
                        "Vine Whip",
                        CreatureType.Grass.ToString(),
                        45,
                        100,
                        10,
                        "A sharp whip of vines." )
                },
                Habitat = Habitat.Forest,
                Rarity = Rarity.Common,
                Description = "A peaceful creature that lives in the forest.",
                CreatureEvolvesTo = "Herbivore"
            };

            compendium.AddCreature(creature1);
            compendium.AddCreature(creature2);
            compendium.AddCreature(creature3);

            return compendium;
        }
    }
}