using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class RefAndOut
    {
        public void RefMethod(ref int age, out string name)
        {
            age += 10;
            name = "hasan";
        }

        public void OutMethod(out int age, ref string name)
        {
            //value assignment inside the method is mandatory for ref
            age = 20;
        }
    }
}