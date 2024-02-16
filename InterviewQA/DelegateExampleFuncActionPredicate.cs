namespace InterviewQA
{
    public class DelegateExampleFuncActionPredicate
    {
        /*
         1. Declare
         2. Create a reference
         3. Point the reference to Methods
         4. Invoke
        */

        /*
         1. Func takes 0 or more paramters and return a value
         2. Action takes 0 or more parameter and does not return anything
         3. Predicate takes 1 parameter and returns a bool
        */

        public DelegateExampleFuncActionPredicate()
        {
            // 4. Invoke
            int addResult = InvokeOperation("Add").Invoke(5, 5);
            int multiplyResult = InvokeOperation("Multiply").Invoke(5, 5);
            Console.WriteLine($"Add : {addResult} & Multiply : {multiplyResult}");

            actionAddition.Invoke(5, 5);

            Employee emp1 = new Employee()
            {
                Name = funcName("Hasan", "Siddiqui"),
                Above18 = predicateAge(20),
                Gender = Gender.Male
            };
            Console.WriteLine(emp1);

            Employee emp2 = new Employee()
            {
                Name = ConcateNameWithMethod(ConcateName, "Hasan_F", "Siddiqui_F"),
                Above18 = CalculateAgeWithPredicate(i => i > 18, 16),
                Gender = Gender.Male
            };
            Console.WriteLine(emp2);

            Console.WriteLine(PredicateStringExample(i => i.Equals(emp1.Name), "Hasan Siddiqui" ));
            Console.WriteLine(PredicateStringExample(i => i.Equals(emp2.Name), "Hasan Siddiqui"));
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public static string ConcateName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        public static string ConcateNameWithMethod(Func<string, string,string> func,
            string firstname, string lastName)
        {
            return ConcateName(firstname, lastName);
        }

        public static void AddForAction(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public static bool CalculateAge(int year)
        {
            return year > 18 ? true : false;
        }

        public static bool CalculateAgeWithPredicate(Predicate<int> predicate, int age)
        {
            return predicate(age);
        }

        public static bool PredicateStringExample(Predicate<string> predicate, string value)
        {
            return predicate(value);
        }

        // 1. Declare
        public delegate int MathOperation(int arg1, int arg2);        

        // 3. Point the reference to Methods        
        public MathOperation InvokeOperation(string opsName)
        {
            // 2. Create a reference
            MathOperation ops = Add;
            if (opsName.Equals("Multiply"))
            {
                ops = Multiply;
            }
            return ops;
        }

        // Func example
        Func<string, string, string> funcName = ConcateName;

        // Action example
        Action<int, int> actionAddition = AddForAction;

        // Predicate
        Predicate<int> predicateAge = CalculateAge;
    }

    public record Employee
    {
        public required string Name { get; set; }
        public bool Above18 { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Other,
        Male,
        FeMale
    }
}