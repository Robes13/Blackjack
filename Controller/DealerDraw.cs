using Blackjack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Controller
{
    internal class DealerDraw
    {
        public List<byte> DealerDrawnCards(List<byte> _dealerCards, List<byte> playerCards)
        {
            int playerScore = 0;
            foreach(byte playerCard in playerCards)
            {
                playerScore += playerCard;
            }
            List<byte> dealerCards = new List<byte>();
            dealerCards.Add(_dealerCards[0]);
            dealerCards.Add(_dealerCards[1]);
            int dealerScore = 0;
            foreach(byte card in dealerCards)
            {
                dealerScore += card;
            }
            while (dealerScore != 21 && dealerScore < 21)
            {
                Cards drawnCards = new Cards();
                byte drawnCard = drawnCards.drawCard();
                dealerCards.Add(drawnCard);
                dealerScore += drawnCard;
                if(dealerScore > playerScore)
                {
                    break;
                }
            }
            return dealerCards; 
        }
    }
}
