using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */
            Console.WriteLine("----------NUMBERS----------");
            Console.WriteLine();

            //TODO: Print the Sum of numbers
            Console.Write("Sum of all numbers: ");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine();

            //TODO: Print the Average of numbers
            Console.Write("Average of all numbers: ");
            Console.WriteLine(numbers.Average());
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("In ascending order:");
            var ascending = numbers.OrderBy(x => x);
            foreach (var x in ascending) { Console.WriteLine(x); }
            Console.WriteLine();

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("In descending order:");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers greater than 6:");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("4 of the numbers:");
            var descending = numbers.Where(x => x < 4).OrderByDescending(x => x);
            foreach (var x in descending) { Console.WriteLine(x); }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Altered list descending:");
            numbers[4] = 36;
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            Console.WriteLine("----------EMPLOYEES----------");
            Console.WriteLine();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("...whose names start with C or S:");
            employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S"))
                .OrderBy(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine(x.FullName));
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("...who are older than 26, sorted by age and first name:");
            employees.Where(x => x.Age > 26)
                .OrderBy(x => x.Age)
                .OrderBy(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FullName}, age {x.Age}"));
            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var over35 = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine("...who are over 35 and have joined in the last 10 years:");
            foreach (var e in over35) { Console.WriteLine($"- {e.FullName}, age {e.Age}, joined {DateTime.Now.Year - e.YearsOfExperience}"); }
            Console.WriteLine($"Between them, they represent {over35.Sum(x => x.YearsOfExperience)} years of experience.");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine($"On average, they've been employed for {over35.Average(x => x.YearsOfExperience)} years.");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Employee newGuy = new Employee("C", "Sharp", 24, 23);
            employees = employees.Concat(new List<Employee> { newGuy}).ToList();
            Console.WriteLine();
            Console.WriteLine($"Please welcome new employee {employees[employees.Count - 1].FullName} to the team!");

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
