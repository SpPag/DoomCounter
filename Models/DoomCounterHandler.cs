using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomCounter.Models
{
    public class DoomCounterHandler
    {
        private string filePath;
        private int doomCounter;

        public DoomCounterHandler(string filePath)
        {
            this.filePath = filePath;
            doomCounter = ReadDoomCounter();
        }

        public int GetCounter()
        {
            return doomCounter;
        }

        private int ReadDoomCounter()
        {
            if (File.Exists(filePath))
            {
                // If file exists, read the doom counter from it
                string storedValue = File.ReadAllText(filePath);
                return int.TryParse(storedValue, out int savedCounter) ? savedCounter : 0;  // Default to 0 if parsing fails
            }
            return 0;  // If file doesn't exist, start from Day 1 once the counter is increased
        }

        public void IncrementCounter()
        {
            doomCounter++;
            SaveDoomCounter();
        }

        private void SaveDoomCounter()
        {
            File.WriteAllText(filePath, doomCounter.ToString());
        }
    }
}
