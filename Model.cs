using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Connect_4
{
    // A model class to implement the state of the board
    public class Model
    {


        // A constant to determine the number of rows of the board
        // A constant can't change during the execution of the game
        public const int ROWS = 6;

        // A constant to determine the number of columns of the board
        public const int COLS = 7;

        // A two-dimensional array to represent the board
        private string[,] board;

        private string emptyCell = " ";
        private int emptySpaces;

        // A constructor to initialize the board with empty values
        // A constructor is a special method of a class that's automatically called when an instance of the class is created
        public Model()
        {
            // A two-dimensional string array to represent the board
            board = new string[ROWS, COLS];
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    board[i, j] = emptyCell;
                }
            }
            emptySpaces = ROWS * COLS;
        }
        // A method to get the value of a cell on the board
        public string GetCell(int row, int col)
        {
            return board[row, col];
        }

        // A method to set the value of a cell on the board
        public void SetCell(int row, int col, string value)
        {

            board[row, col] = value;
            emptySpaces--;
        }

        // A method to check if a column is full
        // Row is 0 because i'm checking the first row
        public bool IsColumnFull(int col)
        {
            return board[0, col] != emptyCell;
        }

        // A method to find the lowest empty row in a column
        // ROWS = number of rows
        // ROWS - 1 = the bottom row
        // The while loop is executed as long as the row is greater or equal to 0 (until the top row) and that cell is not empty.
        // By decreasing row each time, one goes up a row each time.
        public int FindLowestEmptyRow(int col)
        {
            int row = ROWS - 1;
            while (row >= 0 && board[row, col] != emptyCell)
            {
                row--;
            }
            return row;
        }

        // A method to check if the board is full
        public bool IsBoardFull()
        {
            return emptySpaces == 0;
        }

        /*
        // A method to check if the board is full
        // if first column is not full, then return false
        public bool IsBoardFull()
        {
            for (int i = 0; i < COLS; i++)
            {
                if (!IsColumnFull(i))
                {
                    return false;
                }
            }
        // return true only if all columns are full
            return true;
        }
        */



        // A method to check if a player has won
        // return false if no winner
        // value = symbol of the player

        public bool CheckWin(string value)
        {
            // Horizontal check
            // Loop through all the rows of the board
            for (int i = 0; i < ROWS; i++)
            {
                // Loop through the columns from 0 to COLS - 3
                // This is because a horizontal line of four cannot start after the COLS - 3-th column
                for (int j = 0; j < COLS - 3; j++)
                {
                    // Check if the value in the board at position [i, j] is equal to the given value
                    // And also if the next three values in the same row are equal to the given value
                    if (board[i, j] == value && board[i, j + 1] == value && board[i, j + 2] == value && board[i, j + 3] == value)
                    {
                        return true;
                    }
                }
            }

            // Vertical check
            // Loop through all the rows from 0 to ROWS - 3
            // This is because a vertical line of four cannot start after the ROWS - 3-th row
            for (int i = 0; i < ROWS - 3; i++)
            {
                // Loop through all the columns of the board
                for (int j = 0; j < COLS; j++)
                {
                    // Check if the value in the board at position [i, j] is equal to the given value
                    // And also if the next three values in the same column are equal to the given value
                    if (board[i, j] == value && board[i + 1, j] == value && board[i + 2, j] == value && board[i + 3, j] == value)
                    {
                        return true;
                    }
                }
            }

            // Diagonal check

            // Loop through all the rows from 0 to ROWS - 3
            // This is because a diagonal line of four cannot start after the ROWS - 3-th row
            for (int i = 0; i < ROWS - 3; i++)
            {
                // Loop through the columns from 0 to COLS - 3
                // This is because a diagonal line of four cannot start after the COLS - 3-th column
                for (int j = 0; j < COLS - 3; j++)
                {
                    // Check if the value in the board at position [i, j] is equal to the given value
                    // And also if the next three values in the same diagonal direction are equal to the given value
                    // This means that a diagonal line of four is found from top-left to bottom-right
                    if (board[i, j] == value && board[i + 1, j + 1] == value && board[i + 2, j + 2] == value && board[i + 3, j + 3] == value)
                    {
                        return true;
                    }
                }
            }

            // Loop through all the rows from 0 to ROWS - 3
            // This is because a diagonal line of four cannot start after the ROWS - 3-th row
            for (int i = 0; i < ROWS - 3; i++)
            {
                // Loop through the columns from 3 to COLS
                // This is because a diagonal line of four cannot start before the 3-rd column
                for (int j = 3; j < COLS; j++)
                {
                    // Check if the value in the board at position [i, j] is equal to the given value
                    // And also if the next three values in the opposite diagonal direction are equal to the given value
                    // This means that a diagonal line of four is found from top-right to bottom-left
                    if (board[i, j] == value && board[i + 1, j - 1] == value && board[i + 2, j - 2] == value && board[i + 3, j - 3] == value)
                    {
                        return true;
                    }
                }
            }

            // No winner
            return false;
        }
    }
}
