using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class PrintBinaryNumkbers
    {
        public PrintBinaryNumkbers(int number)
        {
            if (number <= 0)
            {
                System.Console.WriteLine("enter positive number.");
            }

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);

            for (int i = 0; i <= number; i++)
            {
                int current = queue.Dequeue();
                System.Console.WriteLine(current);
                queue.Enqueue(current * 10);
                queue.Enqueue(current * 10 + 1);
            }
        }
    }
}