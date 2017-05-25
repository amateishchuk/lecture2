using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Enums;

namespace ZooApp.Abstract
{
    public abstract class Animal
    {
        public string Name { get; protected set; }
        public State State { get; protected set; }
        public int Health { get; protected set; }
        public readonly int MAXHEALTH;

        public Animal(string name, int maxhealth)
        {
            Name = name;
            State = State.Full;
            Health = maxhealth;
            MAXHEALTH = maxhealth;
        }

        public void HealthUp()
        {
            if (State == State.Dead)
            {
                Console.WriteLine($"{Name} is dead");
                Console.WriteLine("You can delete from repository");
            }
            else if (Health < MAXHEALTH)
            {
                Health++;
                Console.WriteLine($"{Name} was heal");
            }
            else
                Console.WriteLine($"{Name} is healthy");
        }
        public void Eat()
        {
            State = State.Full;
        }
    }
}

