using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace CyberNova
{
    public class ChatBot
    {
        private readonly KeywordResponder _keywordResponder;
        private readonly SentimentDetector _sentimentDetector;
        private readonly MemoryStore _memoryStore;

        public ChatBot()
        {
            _keywordResponder = new KeywordResponder();
            _sentimentDetector = new SentimentDetector();
            _memoryStore = new MemoryStore();
        }

        public string GetResponse(string userInput, string userName)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please type a question.";

            string input = userInput.ToLower().Trim();

            // store memory
            _memoryStore.Save(userName, input);

            // sentiment check (optional enhancement)
            string sentiment = _sentimentDetector.Detect(input);

            // keyword-based response
            string response = _keywordResponder.GetResponse(input, userName);

            // optionally modify response based on sentiment
            if (sentiment == "negative")
            {
                response = "I understand you might be concerned. " + response;
            }

            return response;
        }
    }
}
