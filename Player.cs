using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    // An abstract class to define a player
    public abstract class Player
    {
        // A property to store the name of the player
        public string Name { get; set; }

        // A property to store the symbol of the player
        public string Symbol { get; set; }

        // An abstract method to get the move of the player
        public abstract int GetMove(Model model);
    }
}