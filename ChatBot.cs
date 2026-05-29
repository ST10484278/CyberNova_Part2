using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;

namespace CyberNova
{

        public class ChatBot
        {
            // ================= DEPENDENCIES =================
            private readonly KeywordResponder _keywordResponder;
            private readonly SentimentDetector _sentimentDetector;
            private readonly MemoryStore _memoryStore;

            // ================= CHAT STATE =================
            private bool _nameCaptured = false;
            private string _userName = "";

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
                    // Prevent application crash if audio fails
                }
            }

            // ================= STARTUP MESSAGE =================
            public string GetStartupMessage()
            {
                return "Please enter your name to begin the conversation.";
            }

            // ================= MAIN RESPONSE METHOD =================
            public string GetResponse(string userInput)
            {
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    return "Please type something.";
                }

                string input = userInput.ToLower().Trim();

                // ================= FIRST INPUT = USER NAME =================
                if (!_nameCaptured)
                {
                    _userName = userInput;

                    Thread.Sleep(500);

                    _nameCaptured = true;

                    return
                        "Hello " + _userName +
                        "! I am CyberNova, your cybersecurity assistant.\n\n" +
                        "Type 'help' to see topics\n" +
                        "Type 'exit' to quit";
                }

                // ================= SAVE MEMORY =================
                _memoryStore.Save(_userName, input);

                // ================= EXIT COMMAND =================
                if (input == "exit")
                {
                    return "Goodbye " + _userName + "! Stay safe online.";
                }

                // ================= SENTIMENT DETECTION =================
                string sentiment = _sentimentDetector.Detect(input);

                // ================= KEYWORD RESPONSE =================
                //string response = _keywordResponder.GetResponse(input);
            string response = _keywordResponder.GetResponse(input, _userName);
            // ================= SENTIMENT ENHANCEMENT =================
            if (sentiment == "negative")
                {
                    response = "I understand your concern. " + response;
                }

                return response;
            }
        }
    }
    