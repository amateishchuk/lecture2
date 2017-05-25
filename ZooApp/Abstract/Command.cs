using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Abstract
{
    public abstract class Command
    {
        protected IRepository repository;

        public Command(IRepository repo)
        {
            repo = repository;
        }
        public abstract void Execute();
    }
}
