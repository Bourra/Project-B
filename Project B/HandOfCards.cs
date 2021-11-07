using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related

        public void Add(PlayingCard card)
        {
            cards.Add(card);
        }
        #endregion

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                Sort();
                return cards[Count - 1];
            }
        }
        public PlayingCard Lowest
        {
            get
            {
                Sort();
                return cards[0];
            }
        }
        #endregion
    }
}
