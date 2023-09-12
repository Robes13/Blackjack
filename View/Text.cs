using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blackjack.View
{
    /// <summary>
    /// This class is used to write everything, and to call on a clear method.
    /// </summary>
    internal class Text
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void ReadKey()
        {
            Console.ReadKey();
        }
        public void GuiStart()
        {
            Console.WriteLine("Welcome to BlackJack Game, press any key to start");
        }
        public void CardsStart(byte firstCard, byte secondCard, byte dealerCard)
        {
            if (firstCard == 1)
            {
                Console.WriteLine($"You got {firstCard} / 11 & {secondCard}, and the dealer got {dealerCard} & X");
            }
            else if (secondCard == 1)
            {
                Console.WriteLine($"You got {firstCard} & {secondCard} / 11, and the dealer got {dealerCard} & X");
            }
            else if (firstCard != 1 && secondCard != 1)
            {
                Console.WriteLine($"You got {firstCard} & {secondCard}, and the dealer got {dealerCard} & X");
            }
        }
        public void DoUserHit()
        {
            Console.WriteLine("Press y to to hit, or press n to stand!");
        }
        public void CardsHit(byte cardHit)
        {
            Console.WriteLine($"You hit a {cardHit}!");
        }
        public void Stand(List<byte> playerCardsList, byte dealerFirstCard)
        {
            string[] playerCards = ConvertListToString(playerCardsList);
            int lastIndex = playerCards.GetUpperBound(0);
            Console.Write("You chose to stand with ");
            foreach (string playerCard in playerCards)
            {
                if (playerCard == "1")
                {
                    Console.Write("11");
                    continue;
                }
                if (playerCard == playerCards[lastIndex])
                {
                    Console.Write(playerCard);
                    break;
                }
                Console.Write(playerCard + " & ");
            }
            Console.Write($".\nThe dealer has {dealerFirstCard} & X.\n");
        }
        public void DealerDrawing(List<byte> playerCardsList, List<byte> dealerCardsList)
        {
            Console.Clear();
            string[] playerCards = ConvertListToString(playerCardsList);
            int lastIndex = playerCards.GetUpperBound(0);
            Console.Write("You chose to stand with ");
            int count = 0;
            foreach (string playerCard in playerCards)
            {
                if (count == lastIndex)
                {
                    Console.Write(playerCard);
                    break;
                }
                Console.Write(playerCard + " & ");
                count++;
            }
            string[] dealerCards = ConvertListToString(dealerCardsList);
            int lastIndexDealer = dealerCards.GetUpperBound(0);
            Console.Write(".\nThe dealer is drawing now!\n");
            count = 0;
            foreach (string dealerCard in dealerCards)
            {
                if (count == lastIndexDealer)
                {
                    Console.Write(dealerCard);
                    break;
                }
                Console.Write($"{dealerCard} & ");
                Thread.Sleep(1000);
                count++;
            }
        }
        public void Blackjack(byte firstCard, byte secondCard, byte dealerFirstCard, byte dealerSecondCard)
        {
            if (firstCard == 1)
            {
                Console.WriteLine($"Congratulations you hit a BLACKJACK! {firstCard * 11} & {secondCard}.\nThe dealer had {dealerFirstCard} & {dealerSecondCard}.");
            }
            else
            {
                Console.WriteLine($"Congratulations you hit a BLACKJACK! {firstCard} & {secondCard * 11}.\nThe dealer had {dealerFirstCard} & {dealerSecondCard}.");
            }
        }
        public void Bust(string[] playerCards, byte dealerFirstCard, byte dealerSecondCard)
        {
            int lastIndex = playerCards.GetUpperBound(0);
            Console.Write("You busted with ");
            foreach (string playerCard in playerCards)
            {
                if (playerCard == playerCards[lastIndex])
                {
                    Console.Write(playerCard);
                    break;
                }
                Console.Write(playerCard + " & ");
            }
            Console.Write($".\nThe dealer had {dealerFirstCard} & {dealerSecondCard}.\n");
        }
        public void DisplayWinner(List<byte> playerCardsList, List<byte> dealerCardsList)
        {
            string[] playerCards = ConvertListToString(playerCardsList);
            string[] dealerCards = ConvertListToString(dealerCardsList);
            int lastIndex = playerCards.GetUpperBound(0);
            int lastIndexDealer = dealerCards.GetUpperBound(0);
            byte playerCardScore = 0;
            foreach (string playerCard in playerCards)
            {
                if (playerCard == "1")
                {
                    continue;
                }
                playerCardScore += Convert.ToByte(playerCard);
            }
            for (int i = 0; i < playerCards.Length; i++)
            {
                if (playerCards[i] == "1")
                {
                    if (playerCardScore + 11 > 21)
                    {
                        playerCardScore += 1;
                    }
                    else
                    {
                        playerCardScore += 11;
                    }
                }
            }
            byte dealerCardScore = 0;
            foreach (string dealerCard in dealerCards)
            {
                dealerCardScore += Convert.ToByte(dealerCard);
            }
            if (playerCardScore > dealerCardScore)
            {
                Console.WriteLine("Congratulations! You won with ");
                foreach (string playerCard in playerCards)
                {
                    if (playerCard == playerCards[lastIndex])
                    {
                        Console.Write(playerCard);
                        break;
                    }
                    Console.Write(playerCard + " & ");
                }
                Console.Write("!\nThe dealer lost with ");
                foreach (string dealerCard in dealerCards)
                {
                    if (dealerCard == dealerCards[lastIndexDealer])
                    {
                        Console.Write(dealerCard);
                        break;
                    }
                    Console.Write(dealerCard + " & ");
                }
                Console.Write("\nPress any key to play again, or press ESC to exit.");
            }
            else
            {
                Console.Write("Damn it! You lost with ");
                foreach (string playerCard in playerCards)
                {
                    if (playerCard == playerCards[lastIndex])
                    {
                        Console.Write(playerCard);
                        break;
                    }
                    Console.Write(playerCard + " & ");
                }
                Console.Write("!\nThe dealer won with ");
                foreach (string dealerCard in dealerCards)
                {
                    if (dealerCard == dealerCards[lastIndexDealer])
                    {
                        Console.Write(dealerCard);
                        break;
                    }
                    Console.Write(dealerCard + " & ");
                }
                Console.Write("\nPress any key to play again, or press ESC to exit.");
            }
        }

        public string[] ConvertListToString(List<byte> Cards)
        {
            int listLength = Cards.Count();
            string[] cards = new string[listLength];
            int count = 0;
            foreach (byte card in Cards)
            {
                cards[count] = Convert.ToString(card);
                count++;
            }
            return cards;
        }
    }
}
