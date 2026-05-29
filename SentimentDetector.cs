using System;
using System.Collections.Generic;

namespace CyberNova
{
    // 1. Enum for all possible sentiments
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Happy
    }

    public class SentimentDetector
    {
        // 2. Dictionary mapping sentiments to trigger words
        private readonly Dictionary<Sentiment, string[]> _triggers =
            new Dictionary<Sentiment, string[]>
        {
            { Sentiment.Worried, new[] { "worried", "scared", "afraid", "anxious", "nervous", "unsafe" } },
            { Sentiment.Curious, new[] { "curious", "wondering", "interested", "want to know", "how does" } },
            { Sentiment.Frustrated, new[] { "frustrated", "annoyed", "confused", "don't understand", "dont understand" } },
            { Sentiment.Happy, new[] { "great", "thanks", "helpful", "awesome", "love", "good", "happy" } }
        };

        // 3. Detect sentiment from input text
        public Sentiment Detect(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Sentiment.Neutral;

            input = input.ToLower();

            foreach (var entry in _triggers)
            {
                foreach (var keyword in entry.Value)
                {
                    if (input.Contains(keyword))
                    {
                        return entry.Key;
                    }
                }
            }

            return Sentiment.Neutral;
        }

        // 4. Optional: empathetic response generator
        public string GetSentimentResponse(Sentiment sentiment)
        {
            switch (sentiment)
            {
                case Sentiment.Worried:
                    return "It sounds like you're feeling a bit worried. I'm here to help.";

                case Sentiment.Curious:
                    return "That’s interesting! Let’s explore that together.";

                case Sentiment.Frustrated:
                    return "I understand this can be frustrating. Let’s work through it.";

                case Sentiment.Happy:
                    return "That’s great to hear! I'm glad you're feeling positive.";

                default:
                    return "Thanks for sharing. How can I assist you further?";
            }
        }
    }
}