using System;
using System.Collections.Generic;
using System.Linq;

namespace Module15.Employees
{
    internal class Program
    {

        static List<Department> departments;
        static List<Employee> employees;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InitStaff();

            var deptsWithEmp = departments.Join(employees,
                dept => dept.Id,
                emp => emp.DepartmentId,
                (dept, emp) => new
                {
                    d = dept.Name,
                    e = emp.Name
                });

            foreach (var rec in deptsWithEmp)
                Console.WriteLine("");
            //Console.WriteLine($"{rec.d}: {rec.e}");

            var groupped = departments.GroupJoin(employees,
                d => d.Id,
                e => e.DepartmentId,
                (d, e) => new
                {
                    DeptName = d.Name,
                    EmpList = e.Select(emp => emp)
                });

            foreach (var rec in groupped)
            {
                Console.WriteLine($"{rec.DeptName}:");
                foreach (var emp in rec.EmpList)
                    Console.WriteLine($"\t {emp.Id} {emp.Name}");
            }

        }

        public static void InitStaff()
        {
            departments = new List<Department>()
            {
               new Department() {Id = 1, Name = "Программирование"},
               new Department() {Id = 2, Name = "Продажи"}
            };

            employees = new List<Employee>()
            {
               new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
               new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
               new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
               new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };
        }
    }

    internal class Employee
    {
        public int DepartmentId;
        internal string Name;
        internal int Id;
    }

    internal class Department
    {
        internal int Id;
        internal string Name;
    }
}
