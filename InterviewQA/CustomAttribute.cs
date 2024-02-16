using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InterviewQA
{
    [Custom("Hasan")]
    public class UseCustomAttribute
    {
        public UseCustomAttribute()
        {
            System.Console.WriteLine("Custom attribute is called.");

            Attribute[] attributes = Attribute.GetCustomAttributes(typeof(UseCustomAttribute));
            foreach (var item in attributes)
            {
                if (item is CustomAttribute ca)
                {
                    System.Console.WriteLine(ca.PrintName());
                }
            }

            int[] ints = new int[] { 1, 2, 3, 4, 5, 6,7 };
            ArraySegment<int> arraySegment = new ArraySegment<int>(ints, 2, 2);
            System.Console.WriteLine(string.Join(",", arraySegment));
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        public double version = 1.0;
        public CustomAttribute(string name)
        {
            this.Name = name;
            PrintName();
        }
        public string Name { get; set; }

        public string PrintName() => $"{Name} {version}";
    }
}