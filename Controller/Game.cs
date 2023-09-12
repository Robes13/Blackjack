using Blackjack.Model;
using Blackjack.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blackjack.Controller
{
    /// <summary>
    /// This class runs the entire game.
    /// </summary>
    internal class Game
    {
        public void StartGame()
        {
            bool startGame = true;
            while (startGame)
            {
                Text gui = new Text();
                gui.Clear();
                gui.GuiStart();
                gui.ReadKey();
                gui.Clear();
                Cards cards = new Cards();
                List<byte> playerCards = cards.cardHand();
                List<byte> dealerCards = cards.cardHand();
                gui.CardsStart(playerCards[0], playerCards[1], dealerCards[0]);
                gui.DoUserHit();
                if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    gui.Clear();
                    int numberOfCards = playerCards.Count();
                    gui.Stand(playerCards, dealerCards[0]);
                    DealerDraw dealerDraw = new DealerDraw();
                    dealerCards = dealerDraw.DealerDrawnCards(playerCards, dealerCards);
                    gui.DealerDrawing(playerCards, dealerCards);
                    Thread.Sleep(2000);
                    gui.Clear();
                    gui.DisplayWinner(playerCards, dealerCards);
                    Console.ReadLine();

                }

            }
        }
    }
}
