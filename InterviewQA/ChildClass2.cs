using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class ChildClass2 : BaseClass
    {
        public override void ChildClass1Method()
        {
            System.Console.WriteLine("from ChildClass2");
        }
    }
}