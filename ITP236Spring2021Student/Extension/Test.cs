#define stub
//#undef  stub
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EDI
{
    /// <summary>
    /// Tests Extension Methods, Delegates, and Interfaces
    /// </summary>
    public class TestEDI
    {
        delegate string Int2String(int value);
        public static void Test()
        {
            TestInterface();
            TestExtension();
            TestDelegate();
            //TestLinq();
            //LinqStudent();
            //LinqExample();
        }

        static void LinqStudent()
        {
            // Loads the Student Object into the students variable //
            var students = Student.Load();
            // Counts the number of students //
            var count = students.Count();
            // Sums the students
            var sum = students.Sum(s => s.GPA);
            // Sorts students by GPA then returns last value. Essentially returns student with highest GPA.
            Student student = students.OrderBy(s => s.GPA).Last();

        }
        
    static void TestLinq()
    {
        int[] numbers = { 42, 7, 14, 63, 21, 70, 49, 28, 35, 56 };
        int total = 0, j = -1, i = 28;

        foreach (var num in numbers)
        {
            total += num;
        }

        // Uses LINQ with an anonymous Lambda (Lambda is =>).  //
        j = -1;
        j = numbers.FirstOrDefault(num => num == i);
        // All three of these examples do the same thing.

    }
    static void TestDelegate()
    {
        WriteLine($"\n<----- Delegate Test ----->");
            WriteLine();

            DateTime startTime = new DateTime(2020, 10, 25, 10, 30, 00);
            DateTime endTime = new DateTime(2020, 10, 28, 13, 20, 45);

            Delegate.DateDifference diff = Delegate.Days;
            int daysDiff = diff(startTime, endTime);
            Console.WriteLine($"Days Difference: {daysDiff}");

            diff = Delegate.Hours;
            int hoursDiff = diff(startTime, endTime);
            Console.WriteLine($"Hours Difference: {hoursDiff}");

            diff = Delegate.Minutes;
            int minsDiff = diff(startTime, endTime);
            Console.WriteLine($"Minutes Difference: {minsDiff}");

            //var name = "Bob Dust";
            //var firstName = name.Left(3);
            //var lastName = name.Right(4);
            //WriteLine($"Name: {name}\t\tFirstName: {firstName}\t\tLastName: {lastName}");

        }
    static void TestExtension()
    {
        Int2String zip = Zipper;
        WriteLine($"\n<----- Extension Test ----->\nint\tZip Code");
            int zipNum = 1;
        Display(zipNum, zip); zipNum += 10;
        Display(zipNum, zip); zipNum += 100;
        Display(zipNum, zip); zipNum += 1000;
        Display(zipNum, zip); zipNum += 10000;
        Display(zipNum, zip); zipNum += 100000;
        Display(zipNum, zip);
    }
    private static string Zipper(int value)
    {
        return value.ZipCode();
    }
    private static void TestInterface()
    {
        WriteLine($"\n<----- Interface Test ----->");
            WriteLine();
#if stub
            IShape square = new Square(10);
            Display(square);
#endif
    }
#if stub
        private static void Display(IShape shape)
        {
            WriteLine($"Area\tPerimeter\n{shape.Area}\t{shape.Perimeter}");
        }
#endif
    private static void Display(int zip, Int2String zipCode)
    {
        WriteLine($"{zip}\t{zipCode(zip)}");
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }
        public Student() : this(1, "Nobody", 0.0f) { }
        public Student(int studentId, string name, float gpa)
        {
            StudentId = studentId;
            Name = name;
            GPA = gpa;
        }
        public static List<Student> Load()
        {
            return new List<Student>()
                {
                    new Student(101, "River, James", 3.8f),
                    new Student(107, "Walker, Maggie", 3.77f),
                    new Student(104, "Gaknot, Hugh", 3.28f),
                    new Student(103, "Ham, Chip N.", 2.98f),
                    new Student(109, "Wythe, Skip", 3.04f),
                    new Student(102, "de Gar, Tre", 4.00f),
                    new Student(105, "Lake, Anna", 2.79f),
                    new Student(112, "Terson, Pat", 3.72f),
                    new Student(108, "Allen, Glen", 3.08f),


                    new Student(111, "Ashe, Arthur", 3.93f)
                };
        }


    }
}
    public class LinqExample
    {
        public static void TestLinq()
        {
            LinqExamples();
        }
        
        static void LinqExamples()
        {
            WriteLine($"\n<----- LINQ Test ----->");
            WriteLine();

            int[] numbers = { 5, 9, 20, 6, 3, 1, 14, 12, 18, 10 };

            double avg = numbers.Average();

            int sum = numbers.Where(num => num > avg).Sum();
            int min = numbers.Where(num => num > avg).Min();
            int first = numbers.Where(num => num > avg).First();

            Console.Write($"Array: ");
            foreach (var i in numbers)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Average: {avg}");
            Console.Write($"Ints in array greater than {avg}: ");
            foreach (var x in numbers)
            {
                if (x >= avg)
                {
                    Console.Write($"{x} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"First: {first}");


        }
    }
}
