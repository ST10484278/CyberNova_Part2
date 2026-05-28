using System;
using System.Collections.Generic;
using System.Text;

namespace CyberNova
{
    public class CyberNovaBot
    {
        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please type a question.";

            string input = userInput.ToLower();

            if (input.Contains("phishing"))
            {
                return "Phishing emails try to trick you into giving personal information. Always verify the sender.";
            }

            if (input.Contains("password"))
            {
                return "Use strong passwords with letters, numbers, and symbols. Never share your password.";
            }

            if (input.Contains("link"))
            {
                return "Be careful with suspicious links. Check the website address before clicking.";
            }

            if (input == "help")
            {
                return "I can help with:\n- Phishing emails\n- Safe password practices\n- Suspicious links";
            }

            if (input == "exit")
            {
                return "Goodbye!";
            }

            return "I can help with cybersecurity topics. Type 'help' to see options.";
        }
    }
}
