using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class User
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public User(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name} : Total result = {Points}".ToUpper();
        }
    }
}
