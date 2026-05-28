using System.IO;
using System.Media;

namespace CyberNova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CyberNovaBot bot = new CyberNovaBot();

            /* try
             {
                 Console.WriteLine("Program directory:");
                 Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

                 string path = Path.Combine(
                     AppDomain.CurrentDomain.BaseDirectory,
                     "greeting.wav"
                 );

                 if (File.Exists(path))
                 {
                     Console.WriteLine("Audio file found. Playing sound...");
                     SoundPlayer player = new SoundPlayer(path);
                     player.PlaySync();
                 }
                 else
                 {
                     Console.WriteLine("Audio file NOT found at:");
                     Console.WriteLine(path);
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Audio file could not be played.");
                 Console.WriteLine(ex.Message);
             }
             */

            Console.WriteLine("========================================================================");
            Console.WriteLine(@"_________       ______             _____   ________               
__  ____/____  ____  /________________  | / /_  __ \__   _______ _
_  /    __  / / /_  __ \  _ \_  ___/_   |/ /_  / / /_ | / /  __ `/
/ /___  _  /_/ /_  /_/ /  __/  /   _  /|  / / /_/ /__ |/ // /_/ / 
\____/  _\__, / /_.___/\___//_/    /_/ |_/  \____/ _____/ \__,_/  
        /____/                                                    ");

            Console.WriteLine("========================================================================");
            Console.WriteLine("Please enter your name to begin the conversation.");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName + "! Welcome to cybersecurity chatbot.");



            Console.WriteLine("Type 'help' for topics.");
            Console.WriteLine("Type 'exit' to quit.");

            while (true)
            {
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine();

                string response = bot.GetResponse(userInput);

                Console.WriteLine("CyberNova: " + response);

                if (userInput.ToLower() == "exit")
                    break;
            }
        }
    }
}
