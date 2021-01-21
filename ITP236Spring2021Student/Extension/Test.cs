#define stub
#undef  stub
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
            TestExtension();
            TestDelegate();
            TestInterface();
        }
        static void TestExtension()
        {
            WriteLine($"\n<----- Extension Test ----->");
            var name = "Bob Dust";
            var firstName = name.Left(3);
            var lastName = name.Right(4);
            WriteLine($"Name: {name}\t\tFirstName: {firstName}\t\tLastName: {lastName}");
        }
        static void TestDelegate()
        {
            Int2String zip = Zipper;
            WriteLine($"\n<----- Delegate Test ----->\nint\tZip Code");
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
    }
}
