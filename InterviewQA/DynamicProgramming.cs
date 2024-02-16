using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace InterviewQA
{
    public class DynamicProgramming
    {
        public DynamicProgramming()
        {
            dynamic name = "Hasan";

            System.Console.WriteLine($"dynamic binding {name.GetType()}");

            System.Console.WriteLine(name.Length);

            name += " Siddiqui";

            System.Console.WriteLine(name);

            try
            {
                // int n = name.Area;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            dynamic w = new Widget();
            // var W = new Widget() as dynamic;
            System.Console.WriteLine(w.Hello);

            System.Console.WriteLine(w[7]);

            w.WhatIsThis();
        }
    }

    public class Widget : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            result = binder.Name;
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object? result)
        {
            if (indexes.Length == 1)
            {
                result = new string('*', (int)indexes[0]);
                return true;
            }

            result = null;
            return false;
        }

        public dynamic This => this;

        public void WhatIsThis()
        {
            System.Console.WriteLine(This.World);
        }
    }
}