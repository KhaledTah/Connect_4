using Connect_4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Connect_4
{
    // A view class to present the board
    public class View
    {

        // A method to show the board
        // An object of the type Model contains the state of the board
        public void Board(Model model)
        {

            // This lines writes the numbers of the columns of the board to the screen
            // a space before the first number
            Console.Write("  ");
            for (int i = 1; i <= Model.COLS; i++)
            {
                Console.Write($"{i}     ");
            }
            // go to the next line
            Console.WriteLine();

            // This lines writes the numbers of the columns of the board to the screen
            // a space before the first number
            Console.Write("     ");
            for (int i = 1; i <= Model.COLS; i++)
            {
                Console.Write("|     ");
            }
            // go to the next line
            Console.WriteLine();


            // This line writes a line with vertical bars to the screen, to separate the columns
            // Console.WriteLine("     |     |     |     |     |     |     |");

            for (int i = 0; i < Model.ROWS; i++)
            {
                for (int j = 0; j < Model.COLS; j++)
                {
                    Console.Write("  {0}  |", model.GetCell(i, j));
                }
                Console.WriteLine();

                Console.Write("");
                for (int x = 0; x < Model.COLS; x++)
                {
                    Console.Write("_____|");
                }
                // go to the next line
                Console.WriteLine();


                //  Console.WriteLine("_____|_____|_____|_____|_____|_____|_____| ");

                if (i < Model.ROWS - 1)
                {
                    // Only write the vertical bars if not on the last row
                    //   Console.WriteLine("     |     |     |     |     |     |     |");
                    Console.Write("     ");
                    for (int y = 1; y <= Model.COLS; y++)
                    {
                        Console.Write("|     ");
                    }
                    // go to the next line
                    Console.WriteLine();
                }
            }
        }

        // A method to show a message using the Console class
        public void Message(string message)
        {
            // Write the message in a new line
            Console.WriteLine(message);
        }

        // A method to get user input using the Console class
        public string Input()
        {
            // Read the input from the console
            return Console.ReadLine();
        }

    }
}


