﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooClassLibrary.Abstract;
using ZooClassLibrary.Concrete.AnimalFactories;
using ZooClassLibrary.Concrete.Animals;
using ZooClassLibrary.Enums;
using ZooClassLibrary.Extensions;

namespace ZooClassLibrary.Concrete
{
    public class ZooRepository : IRepository
    {
        List<Animal> animals = new List<Animal>()
        {
            new Tiger("Tiger1"),
            new Lion("Lion2"),
            new Elephant("Elephant"),
            new Fox("Fox4"),
            new Wolf("Wolf5"),
            new Bear("Bear6")
        };

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

        public void ShowAnimals()
        {
            animals.ForEach(); // Extensions.ListExtensions.cs
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
