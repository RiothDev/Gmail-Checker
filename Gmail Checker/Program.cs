using System;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Program
    {
        public static string GenerateEmail()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < random.Next(5, 10); i++)
            {
                int index = random.Next(chars.Length);
                builder.Append(chars[index]);
            }

            string email = $"{builder.ToString()}@gmail.com";

            return email;
        }

        static async Task ProcessOption(int opt)
        {
            switch(opt)
            {
                case 1:
                    string randomEmail = GenerateEmail();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Email: {randomEmail}");

                    await ProcessEmail(randomEmail);

                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("> Email: ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? email = Console.ReadLine();

                    await ProcessEmail(email);

                    break;

                default:
                    break;
            }
        }

        static async Task ProcessEmail(string? email)
        {
            if (email != null)
            {
                bool result = await EmailAPI.SendRequest(email);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Email status: {EmailAPI.Check(result)}");
            }
        }

        static async Task _Init()
        {
            try
            {
                Console.ResetColor();
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                string text = @"
                
                ███████╗███╗░░░███╗░█████╗░██╗██╗░░░░░  ░█████╗░██╗░░██╗███████╗░█████╗░██╗░░██╗███████╗██████╗░
                ██╔════╝████╗░████║██╔══██╗██║██║░░░░░  ██╔══██╗██║░░██║██╔════╝██╔══██╗██║░██╔╝██╔════╝██╔══██╗
                █████╗░░██╔████╔██║███████║██║██║░░░░░  ██║░░╚═╝███████║█████╗░░██║░░╚═╝█████═╝░█████╗░░██████╔╝
                ██╔══╝░░██║╚██╔╝██║██╔══██║██║██║░░░░░  ██║░░██╗██╔══██║██╔══╝░░██║░░██╗██╔═██╗░██╔══╝░░██╔══██╗
                ███████╗██║░╚═╝░██║██║░░██║██║███████╗  ╚█████╔╝██║░░██║███████╗╚█████╔╝██║░╚██╗███████╗██║░░██║
                ╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝╚══════╝  ░╚════╝░╚═╝░░╚═╝╚══════╝░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝
                ";

                Console.WriteLine(text);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1 - Random Email\n2 - Email");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("> Option: ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                int opt = int.Parse(Console.ReadLine());

                Console.Write("\n");

                await ProcessOption(opt);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nContinue? ");
                Console.ReadKey();

                await _Init();

            } catch(Exception ex)
            {
                await _Init();
            }
        }

        static async Task Main(string[] args) => await _Init();
    }
}
