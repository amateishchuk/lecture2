using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Abstract
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string name);
    }
}
