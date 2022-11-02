using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Variable : Command
    {
        int value = 0;

        public int Value { get { return value; } }

        public Variable(int value)
        {
            this.value = value;
        }

        public override void VerifyParameters()
        {
            throw new NotImplementedException();
        }

        public override void Operation()
        {
            throw new NotImplementedException();
        }
    }
}
