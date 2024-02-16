using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class DelegateExample
    {
        delegate void Printer();
        delegate void Print(string message);
        Print LogToFile = (string message) =>
        {
            // Log to file, printing on console for test
            System.Console.WriteLine(message);
        };

        Print SendEmail = (string message) =>
        {
            // Send email, printing on console for test
            System.Console.WriteLine(message);
        };

        Print SendMessage = (string message) =>
        {
            // Send message, printing on console for test
            System.Console.WriteLine(message);
        };

        Print PrintOnConsole = (string message) =>
        {
            System.Console.WriteLine(message);
        };

        static void PerformSomeAction(Print message)
        {
            message($"from single delegate");
        }

        public DelegateExample()
        {
            List<Printer> printers = new List<Printer>();
            int i = 0;
            Console.WriteLine("delegate printer");
            for (; i < 10; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }

            foreach (var printer in printers)
            {
                printer();
            }

            Parallel.ForEach(printers, printer => printer());
            Parallel.For(0, 10, x => System.Console.WriteLine(x * x));

            Print p = new Print(LogToFile);
            p += SendEmail;
            p += SendMessage;
            p += PrintOnConsole;
            p("from multicast delegate");

            PerformSomeAction(LogToFile);
            PerformSomeAction(SendEmail);
            PerformSomeAction(SendMessage);
            PerformSomeAction(PrintOnConsole);
        }
    }
}