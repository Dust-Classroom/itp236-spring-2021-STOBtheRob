#define stub
#undef  stub
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
            //TestInterface();
            //TestExtension();
            //TestDelegate();
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

        // 1. The old C# way //
        foreach (var num in numbers)
        {
            if (num == i)
            {
                j = i;
            }
        }

        // 2. Anonymous Method //
        j = -1;
        j = numbers.FirstOrDefault(delegate (int num) { return num == i; }); // FirstOrDefault only returns the first instance that is true.  //

        // 3. Uses LINQ with an anonymous Lambda (Lambda is =>).  //
        j = -1;
        j = numbers.FirstOrDefault(num => num == i);
        // All three of these examples do the same thing.

        // Old C# Way to get the total //
        foreach (var num in numbers)
        {
            total += num;
        }

        // LINQ way of getting the total //
        total = numbers.Sum(n => n);

        // LINQ way of getting the highest number //
        int max = numbers.Max();

        // LINQ way of getting the lowest number //
        int min = numbers.Min();

        // LINQ way of getting the first number //
        int first = numbers.First();

        // LINQ way of getting the last number //
        int last = numbers.Last();

        // LINQ way of getting the average of an array //
        double avg = numbers.Average();

        // Only adds the numbers greater than 50 to your total //
        total = numbers.Where(num => num > 50).Sum();

        // 
        var sortedNums = numbers.OrderBy(num => num);

        // "Lazy Loading" //
        int x = 0;
        var array = numbers.Where(num => num > x);
        // This defines the algorithm, but doesn't actually run anything. Just stores instructions.
        x = 80;
        total = array.Sum();
        // This returns nothing because nothing in our numbers array is above 80.

    }
    static void TestDelegate()
    {
        WriteLine($"\n<----- Delegate Test ----->");
        var name = "Bob Dust";
        var firstName = name.Left(3);
        var lastName = name.Right(4);
        WriteLine($"Name: {name}\t\tFirstName: {firstName}\t\tLastName: {lastName}");

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
#if stub
            IShape square = new Square(10,5);
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
