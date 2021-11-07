using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx]
        {
            get
            {
                return cards[idx];
            }
        }
        //public int Count => cards.Count;

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var item in cards)
                {
                    count++;
                }
                return count;
            }
        }



        #endregion

        #region ToString() related
        public override string ToString()
        {
            string clubs = "\u2663";
            string diamonds = "\u2666";
            string hearts = "\u2665";
            string spades = "\u2660";

            string sRet = "";
            for (int i = 0; i < Count; i++)
            {

                if (cards[i].Color == PlayingCardColor.Clubs)
                {
                    sRet += $"{clubs}: {cards[i].Value,-6}";
                    if ((i + 1) % 13 == 0)
                        sRet += "\n";
                }
                if (cards[i].Color == PlayingCardColor.Diamonds)
                {
                    sRet += $"{diamonds}: {cards[i].Value,-6}";
                    if ((i + 1) % 13 == 0)
                        sRet += "\n";
                }
                if (cards[i].Color == PlayingCardColor.Hearts)
                {
                    sRet += $"{hearts}: {cards[i].Value,-6}";
                    if ((i + 1) % 13 == 0)
                        sRet += "\n";
                }
                if (cards[i].Color == PlayingCardColor.Spades)
                {
                    sRet += $"{spades}: {cards[i].Value,-6}";
                    if ((i + 1) % 13 == 0)
                        sRet += "\n";
                }
            }

            return sRet;
        }


        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            var rnd = new Random(); //rnd is now a random generator - see .NET documentation

            for (int i = 0; i < 1000; i++)
            {
                int randomCard = rnd.Next(0, 52);
                int randomCard2 = rnd.Next(0, 52);
                PlayingCard tmp = cards[randomCard];
                cards[randomCard] = cards[randomCard2];
                cards[randomCard2] = tmp;

            }
        }
        public void Sort()
        {
            for (int unsortedStart = 0; unsortedStart < Count - 1; unsortedStart++)
            {

                int minIndex = unsortedStart;

                for (int i = unsortedStart + 1; i < Count; i++)
                {
                    if (cards[i] != null && cards[i].CompareTo(cards[minIndex]) < 0) minIndex = i;

                }

                PlayingCard tmp = cards[unsortedStart];
                cards[unsortedStart] = cards[minIndex];
                cards[minIndex] = tmp;

            }

        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear();
        }
        public void CreateFreshDeck()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    cards.Add(new PlayingCard() { Color = (PlayingCardColor)i, Value = (PlayingCardValue)j });

                }
            }
        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard topCard = cards[Count - 1];
            cards.Remove(cards[Count - 1]);
            return topCard;
        }
        #endregion
    }
}
