using Blackjack.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Starting the game
            Game game = new Game();
            game.StartGame();
        }
    }
}
