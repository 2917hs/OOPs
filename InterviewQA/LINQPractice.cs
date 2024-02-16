using System.Diagnostics.CodeAnalysis;

namespace InterviewQA
{
    internal class StudentList
    {
        public int StudentID { get; set; }
        public required String StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }
    }

    public class StandardList
    {
        public int StandardID { get; set; }
        public required string StandardName { get; set; }
    }

    class StudentComparer : IEqualityComparer<StudentList>
    {
        public bool Equals(StudentList? x, StudentList? y)
        {
            if (x?.StudentID == y?.StudentID && x?.StudentName == y?.StudentName)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] StudentList obj)
        {
            return obj.StudentID.GetHashCode();
        }
    }

    public class LINQPractice
    {
        public LINQPractice()
        {
            var query = new List<StudentList>();
            var methods = new List<StudentList>();

            Console.WriteLine("LINQPractice----------");
            IList<StudentList> studentList = new List<StudentList>() {
                new StudentList() { StudentID = 1, StudentName = "John", Age = 13, StandardID = 1} ,
                new StudentList() { StudentID = 2, StudentName = "Moin",  Age = 21, StandardID = 1 } ,
                new StudentList() { StudentID = 3, StudentName = "Bill",  Age = 18 , StandardID = 3} ,
                new StudentList() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 3} ,
                new StudentList() { StudentID = 5, StudentName = "Ron" , Age = 15, StandardID = 3 },
                new StudentList() { StudentID = 1, StudentName = "John" , Age = 14, StandardID = 3 }
            };

            IList<StandardList> standardList = new List<StandardList>() {
                new StandardList(){ StandardID = 1, StandardName="Standard 1"},
                new StandardList(){ StandardID = 2, StandardName="Standard 2"},
                new StandardList(){ StandardID = 3, StandardName="Standard 3"}
            };

            Console.WriteLine("zipp on list ---");
            var studentNames = studentList.Select(x => x.StudentName);
            var standardNames = standardList.Select(x => x.StandardName);
            foreach ((StudentList student, StandardList standard) in studentList.Zip(standardList))
            {
                Console.WriteLine($"Student {student.StudentName} is studying in {standard.StandardName}");
            }

            Console.WriteLine("index ---");
            Console.WriteLine(studentList.ElementAtOrDefault(10));
            Console.WriteLine(studentList.ElementAtOrDefault(1));

            Console.WriteLine("join on list ---");
            var newQuery = studentList.Join(
                standardList,
                student => student.StandardID,
                standard => standard.StandardID,
                (student, standard) =>
                            new
                            {
                                StudentID = student.StudentID,
                                StudentName = student.StudentName,
                                Age = student.Age,
                                Standard = standard.StandardID,
                                StandardName = standard.StandardName
                            }
                            ).ToList();
            newQuery.ForEach(nq => Console.WriteLine(nq.StudentName + " " + nq.StandardName));

            Console.WriteLine("Concat on list ---");
            var concat = studentNames.Concat(standardNames).ToList();
            concat.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Print teen age studnet ---");
            query = (from q in studentList
                     where q.Age > 12 && q.Age < 20
                     select q).ToList();
            query.ForEach(x => Console.WriteLine($"{x.StudentID} {x.StudentName}"));
            methods = studentList.Where(x => x.Age > 12 && x.Age < 20).ToList();
            methods.ForEach(x => Console.WriteLine($"{x.StudentID} {x.StudentName}"));

            Console.WriteLine("Print studnet contains a ---");
            query = (from q in studentList
                     where q.StudentName.Contains("a")
                     select q).ToList();
            query.ForEach(x => Console.WriteLine(x.StudentName));
            methods = studentList.Where(x => x.StudentName.Contains("a")).ToList();
            methods.ForEach(x => Console.WriteLine(x.StudentName));

            Console.WriteLine("Print standard query operations ---");
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(numbers.Sum());

            //ofType is used to filter specific type
            //alternatively is operator can be used

            Console.WriteLine("Sorting orders ---");
            query = (from s in studentList
                     orderby s.Age ascending
                     select s).ToList();
            var newList = (from s in studentList
                           orderby s.Age, s.StudentName descending
                           select new { s.Age, s.StudentName }).ToList();
            query.ForEach(x => Console.WriteLine(x.Age));
            methods = studentList.OrderBy(s => s.Age).ToList();
            Console.WriteLine("before then by");
            methods.ForEach(x => Console.WriteLine(x.Age));
            methods = studentList.OrderBy(s => s.Age).ThenBy(s => s.StudentName).ToList();
            Console.WriteLine("after then by");
            methods.ForEach(x => Console.WriteLine(x.Age));

            System.Console.WriteLine("complex type distinct using compare ---");
            var distinctStudentList = query.Distinct(new StudentComparer()).ToList();
            distinctStudentList.ForEach(x => Console.WriteLine(x.StudentName));

            Console.WriteLine("1".GetHashCode());
            Console.WriteLine("1".GetHashCode());
            Console.WriteLine(1.GetHashCode());
            Console.WriteLine("2".GetHashCode());
        }
    }
}