using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18_4_1
{
    abstract class Command
    {
        public abstract void Run();
        public abstract void Cancel();
    }
}
