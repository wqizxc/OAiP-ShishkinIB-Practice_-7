using TaxiPark.Tests;
namespace TaxiPark
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerTester.RunAllTests();
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            System.Console.ReadKey();
        }
    }
}