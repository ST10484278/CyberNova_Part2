using System;
using System.Collections.Generic;
using System.Text;

namespace CyberNova
{
    public class SentimentDetector
    {
        public string Detect(string input)
        {
            input = input.ToLower();

            if (input.Contains("angry") || input.Contains("frustrated") || input.Contains("annoyed"))
                return "negative";

            if (input.Contains("happy") || input.Contains("good") || input.Contains("great"))
                return "positive";

            return "neutral";
        }
    }
}
