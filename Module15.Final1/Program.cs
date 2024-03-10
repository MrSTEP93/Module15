using System;
using System.Collections.Generic;
using System.Linq;

namespace Module15.Final1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, },
               new Classroom { Students = {"Stephan", "Evgeniy", "Vladimir", "Jule"}}
           };
            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
        }

        static string[] GetAllStudents(Classroom[] classes)
        {
            string[] allStudents = classes.SelectMany(s => s.Students).ToArray();

            return allStudents;
        }

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}
