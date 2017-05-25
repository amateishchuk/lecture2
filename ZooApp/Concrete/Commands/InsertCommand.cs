using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Abstract;

namespace ZooApp.Concrete.Commands
{
    public class InsertCommand : Command
    {
        public InsertCommand(IRepository repo) : base(repo)
        {
        }

        public override void Execute()
        {
            Console.Write("INSERTING: Input animal's name: ");
            string name = Console.ReadLine();

            Console.Write("DELETING: Input animal's kind (lion, tiger, elephant, wolf, bear, fox): ");
            string kind = Console.ReadLine();

            repository.InsertAnimal(name, kind);
        }
    }
}
