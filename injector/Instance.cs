using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EasyChecker.injector
{
    class Instance
    {
        private Stack Commands;

        public Instance(){}

        public Stack getCommands()
        {
            return this.Commands;
        }

        public Instance setCommands(Stack C)
        {
            this.Commands = C;
            return this;
        }

    }
}
