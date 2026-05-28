using System;
using System.Collections.Generic;
using System.Text;

namespace CyberNova
{
    public class MemoryStore
    {
        private readonly Dictionary<string, List<string>> _memory
            = new Dictionary<string, List<string>>();

        public void Save(string userName, string message)
        {
            if (!_memory.ContainsKey(userName))
            {
                _memory[userName] = new List<string>();
            }

            _memory[userName].Add(message);
        }

        public List<string> GetHistory(string userName)
        {
            if (_memory.ContainsKey(userName))
                return _memory[userName];

            return new List<string>();
        }
    }
}
