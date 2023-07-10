using System;
using System.Threading.Tasks;

namespace App
{
    public class Program
    {
        static async Task _Init()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("> Email: ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            string? email = Console.ReadLine();

            if (email != null)
            {
                bool result = await EmailAPI.SendRequest(email);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Email status: {EmailAPI.Check(result)}");
            }

            Console.ResetColor();

            Console.ReadKey();
            await _Init();
        }

        static async Task Main(string[] args) => await _Init();
    }
}