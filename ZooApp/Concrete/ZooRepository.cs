using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Abstract;
using ZooApp.Concrete.AnimalFactories;
using ZooApp.Enums;

namespace ZooApp.Concrete
{
    public class ZooRepository : IRepository
    {
        List<Animal> animals = new List<Animal>();

        public void DeleteAnimal(string name)
        {
            Animal animal = getAnimalByName(name);

            if (animal != null)
            {
                if (animal.State == State.Dead)
                {
                    animals.Remove(animal);
                    Console.WriteLine($"{name} was deleted from repository");
                }
                else
                    Console.WriteLine($"You can delete {name}, because its not dead");               
            }
            else
                Console.WriteLine($"The animal with specified name ({name}) is apsend in repository");
        }

        public void FeedAnimal(string name)
        {
            Animal animal = getAnimalByName(name);

            if (animal != null)
            {
                animal.Eat();
                Console.WriteLine($"{name} was fed");
            }
            else
                Console.WriteLine($"The animal with specified name ({name}) is apsend in repository");
        }

        public void HealAnimal(string name)
        {
            Animal animal = getAnimalByName(name);

            if (animal != null)
            {
                animal.HealthUp();
            }
            else
                Console.WriteLine($"The animal with specified name ({name}) is apsend in repository");
        }

        public void InsertAnimal(string name, string kind)
        {
            Animal animal = getAnimalByName(name);

            if (animal != null)
                Console.WriteLine($"The animal with specified name ({name}) is present in repository");            
            else
            {
                animal = returnNewAnimal(name, kind);

                if (animal != null)
                    animals.Add(animal);
                else
                    Console.WriteLine("The specified kind of animal isn't implemented");
            }
        }

        private string formatWord(string word)
        {
            return word.Trim().ToLower();
        }

        private Animal getAnimalByName(string name)
        {
            return animals
                .FirstOrDefault(a => formatWord(a.Name) == formatWord(name));
        }
        
        private Animal returnNewAnimal(string name, string kind)
        {
            Animal animal = null;

            switch (formatWord(kind))
            {
                case "lion":
                    animal = new LionFactory().CreateAnimal(name);
                    break;

                case "tiger":
                    animal = new TigerFactory().CreateAnimal(name);
                    break;

                case "elephant":
                    animal = new ElephantFactory().CreateAnimal(name);
                    break;

                case "bear":
                    animal = new BearFactory().CreateAnimal(name);
                    break;

                case "wolf":
                    animal = new WolfFactory().CreateAnimal(name);
                    break;

                case "fox":
                    animal = new FoxFactory().CreateAnimal(name);
                    break;
            }

            return animal;
        }

    }
}

