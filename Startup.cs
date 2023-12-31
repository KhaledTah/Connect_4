using Connect_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    // A Startup class to start the application and initiate the Controller
    class Startup
    {
        // A method to start the game
        public void StartGame()
        {
            // Create an instance of the Controller class
            Controller controller = new Controller();

            // Start the game loop
            controller.StartGameLoop();


        }
    }

}