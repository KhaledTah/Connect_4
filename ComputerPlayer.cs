using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connect_4
{
    // A class to define a computer player
    public class ComputerPlayer : Player
    {
        // A constructor to set the name and symbol of the player
        public ComputerPlayer(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // A method to get the move of the player
        public override int GetMove(Model model)
        {
            // Create a random object
            Random random = new Random();

            // A variable to store the choice of the player
            int choice = 0;

            // A loop until the choice is valid
            do
            {
                // Generate a random number between 1 and Model.COLS
                choice = random.Next(1, Model.COLS);

                // This loop will be executed until the column is not full
            } while (model.IsColumnFull(choice - 1));

            // Show the choice of the player
            Console.WriteLine("\n");
            Thread.Sleep(750);
            Console.WriteLine("{0} chooses column {1}", Name, choice);
            Thread.Sleep(500);

            // Return the choice of the player
            return choice;
        }
    }
}