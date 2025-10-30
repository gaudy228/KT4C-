namespace KT4
{
    delegate void AttackAction(Warrior attacker, Warrior defender);
    class Program
    {
        static void Main()
        {
            Warrior warrior1 = new Warrior("Артем", 100);
            Warrior warrior2 = new Warrior("Степа", 100);

            Arena.Fight(warrior1, warrior2, AttackMethods.Hit);

            warrior1 = new Warrior("Артем", 100);
            warrior2 = new Warrior("Степа", 100);
            Console.WriteLine();
            AttackAction comboAttack = AttackMethods.Hit;
            comboAttack += AttackMethods.CriticalHit;
            Arena.Fight(warrior1, warrior2, comboAttack);
        }
    }
    class Warrior
    {
        public string Name { get; }
        public int Health { get; private set; }
        public Warrior(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void TakeDamage(int amount)
        {
            Health -= amount;
        }
        public void ShowStatus()
        {
            Console.WriteLine(Health);
        }
    }
    static class AttackMethods
    {
        public static void Hit(Warrior attacker, Warrior defender)
        {
            int damage = 10;
            defender.TakeDamage(damage);
            Console.WriteLine($"{defender.Name} - {damage}");
        }
        public static void CriticalHit(Warrior attacker, Warrior defender)
        {
            int damage = 20;
            defender.TakeDamage(damage);
            Console.WriteLine($"{defender.Name} - {damage}");
        }
    }
    static class Arena
    {
        public static void Fight(Warrior w1, Warrior w2, AttackAction attack)
        {
            int round = 1;
            while (w1.Health > 0 && w2.Health > 0 && round <= 10)
            {
                Console.WriteLine(round);
                attack(w1, w2);
                w1.ShowStatus();
                w2.ShowStatus();
                if (w2.Health <= 0)
                {
                    Console.WriteLine($"{w2.Name} умер");
                    break;
                }
                attack(w2, w1);
                w1.ShowStatus();
                w2.ShowStatus();
                if (w1.Health <= 0)
                {
                    Console.WriteLine($"{w1.Name} умер");
                    break;
                }
                round++;
                Console.WriteLine();
            }
        }
    }

    
}
