using CreatureCompendium;

namespace CreatureCompendium
{

    public static class TypeCalculator
    {
        public static double GetMultiplier(
            Creature attacker,
            Creature defender)
        {
            if (attacker.CreatureType == CreatureType.Fire
                && defender.CreatureType == CreatureType.Grass)
            {
                return 2.0;
            }

            if (attacker.CreatureType == CreatureType.Water
                && defender.CreatureType == CreatureType.Fire)
            {
                return 2.0;
            }

            if (attacker.CreatureType == CreatureType.Grass
                && defender.CreatureType == CreatureType.Water)
            {
                return 2.0;
            }
            if (attacker.CreatureType == CreatureType.Electric
                && defender.CreatureType == CreatureType.Water)
            {
                return 2.0;
            }
            if (attacker.CreatureType == CreatureType.Earth
                && defender.CreatureType == CreatureType.Electric)
            {
                return 2.0;
            }
            if (attacker.CreatureType == CreatureType.Air
                && defender.CreatureType == CreatureType.Earth)
            {
                return 2.0;
            }
            if (attacker.CreatureType == CreatureType.Ice
                && defender.CreatureType == CreatureType.Fire)
            {
                return 2.0;
            }

            if (attacker.CreatureType == CreatureType.Fire
                && defender.CreatureType == CreatureType.Water)
            {
                return 0.5;
            }

            if (attacker.CreatureType == CreatureType.Water
                && defender.CreatureType == CreatureType.Grass)
            {
                return 0.5;
            }

            if (attacker.CreatureType == CreatureType.Grass
                && defender.CreatureType == CreatureType.Fire)
            {
                return 0.5;
            }

            return 1.0;
        }

        public static int CalculateDamage(
        Creature attacker,
        Creature defender)
        {
            int baseDamage =
                attacker.Attack -
                defender.Defense;

            if (baseDamage < 1)
            {
                baseDamage = 1;
            }

            double multiplier =
                GetMultiplier(
                    attacker,
                    defender);

            return
                (int)(baseDamage * multiplier);
        }

        public static void AttackTarget(
        Creature attacker,
        Creature defender)
        {
            int damage =
                CalculateDamage(
                    attacker,
                    defender);

            defender.HP -= damage;

            if (defender.HP < 0)
            {
                defender.HP = 0;
            }

            Console.WriteLine(
                $"{attacker.Name} dealt {damage} damage to {defender.Name}");
            }
        }
    }