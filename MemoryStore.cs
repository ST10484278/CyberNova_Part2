using System;
using System.Collections.Generic;

namespace CyberNova
{
    public class MemoryStore
    {
        // Stores conversation history per user
        private Dictionary<string, List<string>> _memory
            = new Dictionary<string, List<string>>();

        // ================= SAVE MEMORY =================
        public void Save(string userName, string input)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(input))
                return;

            if (!_memory.ContainsKey(userName))
            {
                _memory[userName] = new List<string>();
            }

            _memory[userName].Add(input);
        }

        // ================= RECALL LAST INPUT =================
        public string RecallLast(string userName)
        {
            if (_memory.ContainsKey(userName) && _memory[userName].Count > 0)
            {
                return _memory[userName][_memory[userName].Count - 1];
            }

            return "No previous conversation found.";
        }

        // ================= RECALL FULL HISTORY =================
        public List<string> RecallAll(string userName)
        {
            if (_memory.ContainsKey(userName))
            {
                return _memory[userName];
            }

            return new List<string>();
        }

        // ================= OPTIONAL: CHECK IF USER EXISTS =================
        public bool HasUser(string userName)
        {
            return _memory.ContainsKey(userName);
        }
    }
}