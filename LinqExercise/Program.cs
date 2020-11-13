using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    public class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum(); //I did num => num in here for average and sum and didn't work
                                     //I also tried a foreach loop for these and I couldn't - have to do console.writeline
                                     //maybe this is because there is nothing in the parameters
            Console.WriteLine($"Sum: {sum}");
            var average = numbers.Average();
            Console.WriteLine($"Average: {average}");

            Console.WriteLine();

            //Order numbers in ascending order and decsending order. Print each to console.
            var desc = numbers.OrderByDescending(num => num);
            var asc = numbers.OrderBy(num => num);

            Console.WriteLine("Descending:");
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();
            Console.WriteLine("Ascending:");
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //Print to the console only the numbers greater than 6
            var greaterThan = numbers.Where(num => num > 6);
            Console.WriteLine("Greater than 6:");
            foreach (var num in greaterThan)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            //var ascFour = numbers.OrderBy(num => num).Take(4);
            var ascFour = asc.Take(4); //you can do this instead of the above.. just use the asc you made earlier
            Console.WriteLine("First Four:");
            foreach (var num in ascFour)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 28;
            //var descAge = numbers.OrderByDescending(num => num);
            //foreach(var num in descAge)
            Console.WriteLine("My Age Included");
            foreach (var num in numbers.OrderByDescending(num => num)) //you can store linq in foreach loop
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            
            
            
            
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Names of Employees where name starts with C or S:");
            var newEmployees = employees.Where(name => name.FirstName.Contains('C') || name.FirstName.Contains('S'));
            //var newEmployees = employees.Where(name => name.FirstName.StartsWith('C') || name.FirstName.StartsWith('S'));
                //so I learned here.. doesn't matter which I do since it's case sensitive.. lower case will not return
                //Cruz for example in .Contains or .StartWith if using 'c'
            foreach (var names in newEmployees.OrderBy(name => name.FirstName.Contains('C') || name.FirstName.Contains('S')))
            {
                Console.WriteLine(names.FullName);
            }
            Console.WriteLine();
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over the age of 26:");
            var over26 = employees.Where(emp => emp.Age > 26);
            foreach(var age in over26.OrderBy(emp => emp.FirstName))
            {
                Console.WriteLine(age.FullName);
            }
            Console.WriteLine();
            
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35           
            Console.WriteLine("Total and average years of experience:");
            var employeeYOE = employees.Where(yoe => yoe.YearsOfExperience <= 10 && yoe.Age > 35);
            var yoeSum = employeeYOE.Sum(yoe => yoe.YearsOfExperience);
            var yoeAvg = employeeYOE.Average(yoe => yoe.YearsOfExperience);

            Console.WriteLine($"Sum: {yoeSum}");
            Console.WriteLine($"Avg: {yoeAvg}");
            Console.WriteLine();

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Amber", "Riley", 28, 0)).ToList();
            foreach (var newList in employees.OrderBy(names => names.FirstName))
            {
                Console.WriteLine($"{newList.FullName}  {newList.Age}   {newList.YearsOfExperience}");
            }
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
