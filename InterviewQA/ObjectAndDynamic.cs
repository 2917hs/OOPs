using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class ObjectAndDynamic
    {
        public ObjectAndDynamic()
        {
            String a1 = "Rohatash Kumar";
            object a2 = a1;
            //int a3 = (int)a2;

            string b1 = "Rohatash Kumar";
            dynamic b2 = b1;
            string b3 = (string)b2;
        }
    }
}