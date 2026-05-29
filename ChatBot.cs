using System;
using System.IO;
using System.Media;

namespace CyberNova
{
    public class ChatBot
    {
        // ================= DEPENDENCIES =================
        private readonly KeywordResponder _keywordResponder;
        private readonly SentimentDetector _sentimentDetector;
        private readonly MemoryStore _memoryStore;

        // ================= CHAT STATE =================
        private bool _awaitingName = true;
        private string _userName = "";
        private string _lastTopic = "";

        // ================= CONSTRUCTOR =================
        public ChatBot()
        {
            _keywordResponder = new KeywordResponder();
            _sentimentDetector = new SentimentDetector();
            _memoryStore = new MemoryStore();
        }

        // ================= ASCII ART =================
        public string GetAsciiArt()
        {
            return
@"   _____      _               _   _                 
  / ____|    | |             | \ | |                
 | |    _   _| |__   ___ _ __|  \| | _____   ____ _ 
 | |   | | | | '_ \ / _ \ '__| . ` |/ _ \ \ / / _` |
 | |___| |_| | |_) |  __/ |  | |\  | (_) \ V / (_| |
  \_____\__, |_.__/ \___|_|  |_| \_|\___/ \_/ \__,_|
         __/ |                                      
        |___/                                       ";
        }

        // ================= GREETING AUDIO =================
        public void PlayGreetingAudio()
        {
            try
            {
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "greeting.wav"
                );

                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.PlaySync();
                }
            }
            catch
            {
                // ignore audio failure
            }
        }

        // ================= GREETING =================
        public string GetGreeting()
        {
            return "Please enter your name to begin the conversation.";
        }

        // ================= MAIN ENTRY POINT =================
        public string ProcessInput(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please type something.";

            string input = userInput.ToLower().Trim();

            // =====================================================
            // 1. NAME CAPTURE (ONLY ONCE)
            // =====================================================
            if (_awaitingName)
            {
                _userName = userInput;
                _awaitingName = false;

                return $"Hello {_userName}! I am CyberNova, your cybersecurity assistant.\n\n" +
                       "Type 'help' to see topics\n" +
                       "Type 'exit' to quit";
            }

            // save memory
            _memoryStore.Save(_userName, input);

            // exit command
            if (input == "exit")
                return $"Goodbye {_userName}! Stay safe online.";

            // =====================================================
            // 2. FOLLOW-UP HANDLING
            // =====================================================
            if (input.Contains("tell me more") || input.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(_lastTopic))
                    return _keywordResponder.GetFollowUpResponse(_lastTopic, _userName);

                return "What topic would you like me to explain further?";
            }

            // =====================================================
            // 3. SENTIMENT DETECTION
            // =====================================================
            string sentiment = _sentimentDetector.Detect(input);

            // =====================================================
            // 4. KEYWORD RESPONSE
            // =====================================================
            string response = _keywordResponder.GetResponse(input, _userName);

            if (!string.IsNullOrEmpty(response))
            {
                _lastTopic = input;

                if (sentiment == "frustrated" || sentiment == "worried")
                {
                    response = "I understand your concern. " + response;
                }

                return response;
            }

            // =====================================================
            // 5. SPECIAL PHRASES
            // =====================================================
            if (input.Contains("how are you"))
                return "I'm doing well, thanks for asking! I'm here to help keep you safe online.";

            if (input.Contains("what can you do") || input.Contains("purpose"))
                return "I help you understand cybersecurity topics like phishing, passwords, malware, and safe browsing.";

            if (input == "help")
                return _keywordResponder.GetResponse("help", _userName);

            // =====================================================
            // 6. FALLBACK
            // =====================================================
            return "I'm not sure I understand. Try asking about cybersecurity topics or type 'help'.";
        }
    }
}