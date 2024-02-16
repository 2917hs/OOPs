using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQA
{
    public class Lambda
    {
        public Lambda()
        {
            var data = GetStudentsFromDb();

            var passedStudents = data
                                //.Where(s => s.Mark < 50)
                                //.Where(s => s.City.Equals("CA"))

                                //.OrderBy(s => s.StudentName)
                                //.ThenByDescending(s => s.Mark)
                                .GroupBy(s => s.Mark)

                                .ToList();

            foreach (var item in passedStudents)
            {
                foreach (var k in item)
                {
                    Console.WriteLine(item.Key + "-" + k.StudentName);
                }
            }

        }

        private IQueryable<Student> GetStudentsFromDb()
        {
            return new[] {
                new Student() { StudentID = 1, StudentName = "John Nigel", Mark = 90, City ="NYC"} ,
                new Student() { StudentID = 2, StudentName = "Alex Roma",  Mark = 49 , City ="CA"} ,
                new Student() { StudentID = 3, StudentName = "Noha Shamil",  Mark = 88 , City ="CA"} ,
                new Student() { StudentID = 4, StudentName = "James Palatte" , Mark = 90, City ="NYC"} ,
                new Student() { StudentID = 5, StudentName = "Ron Jenova" , Mark = 85 , City ="NYC"}
            }.AsQueryable();
        }
    }

    internal class Student
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public int Mark { get; set; }
        public string? City { get; set; }
        public int Age { get; internal set; }
    }
}