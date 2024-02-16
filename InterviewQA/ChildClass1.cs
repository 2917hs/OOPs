using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class ChildClass1 : BaseClass
    {
        public new void ChildClass1Method()
        {
            System.Console.WriteLine("from ChildClass1");
        }

        public static void PublicMethod()
        {}
    }
}