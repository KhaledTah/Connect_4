using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Connect_4
{
    // A class to define a human player
    public class HumanPlayer : Player
    {
        // A constructor to set the name and symbol of the player
        public HumanPlayer(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // A method to get the move of the player
        public override int GetMove(Model model)
        {
            // A boolean variable to check the validity of the input
            bool valid = false;

            // A variable to store the choice of the player
            int choice = 0;

            // A loop until the input is valid
            while (!valid)
            {
                // Ask player to enter a number
                Console.WriteLine("\n");
                Console.WriteLine("{0}, please enter a number between 1 and {1}", Name, Model.COLS);

                // Read input of the player
                string input = Console.ReadLine();

                // Try to parse the input as an integer and assign it to choice
                if (int.TryParse(input, out choice))
                {
                    // Check if the choice is within the range of the array
                    if (choice >= 1 && choice <= Model.COLS)
                    {
                        // Check if the column is full
                        // -1 because the array starts from 0
                        if (!model.IsColumnFull(choice - 1))
                        {
                            // If the column is not full
                            valid = true;
                        }
                        // If the column is full
                        else
                        {

                            // Show an error message
                            Console.WriteLine("\n");
                            Console.WriteLine("Invalid choice. The column {0} is full.", choice);
                        }
                    }


                    // If the choice is out of range
                    else
                    {

                        // Show an error message
                        Console.WriteLine("\n");
                        Console.WriteLine("Invalid choice. The number must be between 1 and {0}.", Model.COLS);
                    }
                }
                // If the input is not an integer
                else
                {

                    // Show an error message
                    Console.WriteLine("\n");
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            // Return the choice of the player
            return choice;
        }
    }
}

