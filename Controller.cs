using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    // A controller class to manage the game
    class Controller
    {

        // An instance of the Model class that handles the game data and rules
        private Model model;

        // An instance of the View class that displays the game board (and messages)
        private View view;

        // previous version: An array to store the players
        // previous version: public static Player[] players = new Player[2];

        // A list to store the players (either human or computer)
        private List<Player> players;

        // A variable to keep track of the current player's index in the list
        // 0 means the first player, 1 means the second player in the list
        //  previous version: public static int player = 1
        private int player;


        // A variable to store the choice of the current player
        // The choice is the column number where the player wants to drop a disc
        // public static int choice;
        private int choice;

        // A variable to store the state (stand) of the game
        // True means the game is over (either win or draw), false means the game is still on
        //public static bool state = false;
        private bool state;




        // A constructor to initialize the model, the view, and the players list
        public Controller()
        {
            model = new Model();
            view = new View();
            players = new List<Player>();
            player = 0;
            state = false;

            // Create two players & ask the name and the symbol of the players
            // Use the view to show messages and get user input
            view.Message("Enter the name of the first player:");
            string name_player1 = view.Input();
            view.Message("Enter the symbol of the first player:");
            string symbol_player1 = view.Input();
            CreatePlayer(name_player1, symbol_player1);

            view.Message("Enter the name of the second player (Computer):");
            string name_player2 = view.Input();
            view.Message("Enter the symbol of the second player (Computer):");
            string symbol_player2 = view.Input();
            CreatePlayer(name_player2, symbol_player2);
        }




        // A method to create a player object and add it to the players list

        public void CreatePlayer(string name, string symbol)
        {
            if (players.Count == 0)
            {
                // The first player is a human player, which requires user input
                players.Add(new HumanPlayer(name, symbol));
            }
            else
            {
                // The second player is a Computer player
                players.Add(new ComputerPlayer(name, symbol));
            }
        }


        //  A method to start the game loop
        public void StartGameLoop()
        {
            // A while loop to repeat the game until there is a winner or a draw (gelijkspel)
            // state is false in the beginning. If winner or draw, state becomes true
            while (!state)
            {
                // Clear the screen
                Console.Clear();

                // Show the players and their symbols
                view.Message($"{players[0].Name} ({players[0].Symbol}) and {players[1].Name} ({players[1].Symbol})");
                view.Message("\n");

                // Check who is on the turn
                view.Message($"{GetCurrentPlayer().Name}'s turn");
                view.Message("\n");

                // Show the board using the view
                view.Board(model);

                // Get the move (zet) of the current player
                choice = GetMove(model);

                // Find the lowest empty row in the chosen column
                // - 1 is because the array start with 0
                int row = model.FindLowestEmptyRow(choice - 1);

                // Set the value of the current player in the found cell
                model.SetCell(row, choice - 1, GetCurrentPlayer().Symbol);

                // Check the winner using the model
                // True means there is a winner, false means there is no winner
                state = model.CheckWin(GetCurrentPlayer().Symbol);

                // Break the loop if there is a winner
                if (state) break;

                // No winner? --> switch player
                SwitchPlayer();
            }

            // Clear the screen
            Console.Clear();

            // Show the filled board again using the view
            view.Board(model);

            // If the state value is true, then someone has won (the one who played last)
            if (state)
            {
                view.Message("\n");
                view.Message($"{GetCurrentPlayer().Name} has won!");
            }
            // If the state value is false, then the match is a draw (gelijkspel) and no one is the winner
            else
            {
                view.Message("\n");
                view.Message("Draw");
            }
            view.Input();
        }






        // A method to get the current player
        // public static Player GetCurrentPlayer()
        public Player GetCurrentPlayer()
        {
            return players[player % 2];
        }


        // A method to get the move (zet) of the current player
        // public static int GetMove(Model model)
        public int GetMove(Model model)
        {
            return GetCurrentPlayer().GetMove(model);
        }

        // A method to switch the player by incrementing the index
        // public static void SwitchPlayer()
        public void SwitchPlayer()
        {
            player++;
        }




    }
}

