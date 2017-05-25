﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Abstract;
using ZooApp.Concrete.Animals;

namespace ZooApp.Concrete.AnimalFactories
{
    public class LionFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string name)
        {
            return new Lion(name);
        }
    }
}
