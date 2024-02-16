using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class BaseClass
    {
        private void PrivateMethod()
        { }

        public void PublicMethod()
        { }

        //cannot mark virtual so cannot inherit ctor of base class
        public BaseClass()
        {
            Console.WriteLine("from BaseClass ctor");
        }

        public virtual void ChildClass1Method()
        {
            System.Console.WriteLine("from BaseClass");
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public long Sum(long a, int b)
        {
            return a + b;
        }
    }
}