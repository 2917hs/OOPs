using System;
using System.Linq.Expressions;
namespace InterviewQA
{
    public class IndicesAndRanges
    {
        public IndicesAndRanges()
        {
            string[] names = new string[] { "Hasan", "Kamal", "Siddiqui" };
            Console.WriteLine($"The first name is {names[0]}");
            Console.WriteLine($"The middle name is {names[1]}");
            Console.WriteLine($"The last name is {names[^1]}");

            var jagged = new int[10][]
                            {
                               new int[10] {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                               new int[10] { 10,11,12,13,14,15,16,17,18,19 },
                               new int[10] { 20,21,22,23,24,25,26,27,28,29 },
                               new int[10] { 30,31,32,33,34,35,36,37,38,39 },
                               new int[10] { 40,41,42,43,44,45,46,47,48,49 },
                               new int[10] { 50,51,52,53,54,55,56,57,58,59 },
                               new int[10] { 60,61,62,63,64,65,66,67,68,69 },
                               new int[10] { 70,71,72,73,74,75,76,77,78,79 },
                               new int[10] { 80,81,82,83,84,85,86,87,88,89 },
                               new int[10] { 90,91,92,93,94,95,96,97,98,99 },
                            };

            var selectedRows = jagged[3..^3];

            foreach (var row in selectedRows)
            {
                var selectedColumns = row[2..^2];
                foreach (var cell in selectedColumns)
                {
                    Console.Write($"{cell}, ");
                }
                Console.WriteLine();
            }

            Expression<Func<int, int, int>> addExpression = (a, b) => a + b;

            // Access the expression tree structure for examination or manipulation
            BinaryExpression body = (BinaryExpression)addExpression.Body;
            ParameterExpression left = (ParameterExpression)body.Left;
            ParameterExpression right = (ParameterExpression)body.Right;

            Console.WriteLine("Expression: {0} + {1}", left.Name, right.Name);

            // Compile the expression tree to a delegate to execute it
            Func<int, int, int> addFunc = addExpression.Compile();

            int result = addFunc(3, 5);
            Console.WriteLine("Result: {0}", result);
        }
    }
}

