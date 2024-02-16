using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class ConstReadonlyStatic
    {
        const string co = "const";
        //it is mandatory to assign value to const
        //const string co1;
        readonly string ro = "readonly";
        readonly string? ro1;
        readonly static string rs = "readonly static";
        readonly static string? rs1;
        //non readonly static can be set everywhere
        static string rs2;

        public void SetVariables()
        {
            System.Console.WriteLine("SetVariables is called");
            //cannot change the value of any in normal method call
            //co = "new const";
            //ro = "new readonly";
            //rs = "new static readonly";
            rs2 = "non readonly static";
        }

        public static void SetStaticVariables()
        {
            System.Console.WriteLine("static SetVariables is called");
            //cannot change the value of any in static method call
            //co = "new const";
            //ro = "new readonly";
            //rs = "new static readonly";
            rs2 = "non readonly static";
        }

        public ConstReadonlyStatic()
        {
            //can change only readonly inside ctor
            //co = "new const";
            ro = "new readonly";
            //rs = "new static readonly";
            rs2 = "non readonly static";
        }

        static ConstReadonlyStatic()
        {
            //can change only static memebers
            //co = "new const";
            //ro = "new readonly";
            rs = "new static readonly";
            rs2 = "non readonly static";
        }
    }
}