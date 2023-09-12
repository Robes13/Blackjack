using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Model
{
    /// <summary>
    /// This class just holds the cards, we get a card hand first when the game is initiated, and we draw one card when we hit (These two things aply to the dealer as well).
    /// </summary>
    public struct Cards
    {
        #region Fields

        byte _cardOne;
        byte _cardTwo;
        byte _cardDrawn;

        #endregion Fields

        #region Properties

        public byte CardOne 
        { 
            get { return _cardOne; } 
            set { _cardOne = value; }
        }
        public byte CardTwo 
        {
            get { return _cardTwo; }
            set { _cardTwo = value; }
        }
        public byte CardDrawn
        {
            get { return _cardDrawn; }
            set { _cardDrawn = value; }
        }
        #endregion Properties

        #region Methods

        public List<byte> cardHand()
        {
            Random rndCard = new Random();
            _cardOne = Convert.ToByte(rndCard.Next(1,11));
            _cardTwo = Convert.ToByte(rndCard.Next(1, 11));
            List<byte> cards = new List<byte>();
            cards.Add(CardOne);
            cards.Add(CardTwo);
            return cards;
        }

        public byte drawCard()
        {
            Random rndCard = new Random();
            _cardDrawn = Convert.ToByte(rndCard.Next(1, 11));
            return _cardDrawn;
        }

        #endregion Methods
    }
}
