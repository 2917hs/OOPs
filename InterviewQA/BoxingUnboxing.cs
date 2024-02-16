using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class BoxingUnboxing
    {
        public BoxingUnboxing()
        {
            int a = 10;
            object b = a;

            object c = "5";
            int d = Convert.ToInt32(c);
        }
    }
}