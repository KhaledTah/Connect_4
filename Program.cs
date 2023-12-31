// See https://aka.ms/new-console-template for more information

using Connect_4;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
namespace Connect_4
{

    class Program
    {


        static void Main(string[] args)
        {
            {
                // Create an instance of the Startup class
                Startup startup = new Startup();
                // Startup startup2 = new Startup();

                // Start the game
                startup.StartGame();
                // startup2.StartGame();

            }
        }

    }
}