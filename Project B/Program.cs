using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);
            Console.WriteLine();


            Console.WriteLine("Do you wanna play a game of cards? Press any key to continue!");
            Console.ReadKey();
            Console.Clear();



            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();
            int nrOfCards = 0;
            int nrOfRounds = 0;


            Console.WriteLine("Let's play a game of highest card with two players.");
            Console.WriteLine();
            bool validNrOfCards = false;
            while (validNrOfCards == false)
            {
                validNrOfCards = TryReadNrOfCards(out nrOfCards);
            }
            Console.WriteLine();
            bool validNrOfRounds = false;
            while (validNrOfRounds == false)
            {
                validNrOfRounds = TryReadNrOfRounds(out nrOfRounds);
            }

            Console.Clear();

            int roundNumber = 1;

            while (roundNumber <= nrOfRounds)
            {

                Console.WriteLine("------------------");
                Console.WriteLine($"Playing round nr {roundNumber}");
                Console.WriteLine("------------------");
                Deal(myDeck, nrOfCards, player1, player2);
                Console.WriteLine($"Gave {nrOfCards} cards to each player from the top of the deck. The deck now has {myDeck.Count} cards");
                Console.WriteLine();
                Console.WriteLine($"Player1 hand with {nrOfCards} cards:");
                Console.WriteLine($"Lovest card in hand is {player1.Lowest} and highest is {player1.Highest}:");
                Console.WriteLine(player1);
                Console.WriteLine();
                Console.WriteLine($"Player2 hand with {nrOfCards} cards:");
                Console.WriteLine($"Lovest card in hand is {player2.Lowest} and highest is {player2.Highest}:");
                Console.WriteLine(player2);
                Console.WriteLine();
                DetermineWinner(player1, player2);
                Console.WriteLine();
                roundNumber++;
                player1.Clear();
                player2.Clear();
            }


        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {


            Console.WriteLine("How many cards to deal to each player (1-5 or Q to quit)?");
            string input = Console.ReadLine();
            bool readable = Int32.TryParse(input, out NrOfCards);
            int validNumber = NrOfCards;
            if (validNumber > 0 && validNumber < 6)
            {
                return true;
            }
            else if (input == "q" || input == "Q")
            {
                Environment.Exit(1);
                return false;
            }
            else if (readable == false)
            {
                Console.WriteLine("Wrong input, pls try again");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine("Not a valid number of cards, pls try again!");
                Console.WriteLine();
                return false;
            }

        }



        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {


            Console.WriteLine("How many rounds should we play (1-5 or Q to quit)?");
            string input = Console.ReadLine();
            bool readable = Int32.TryParse(input, out NrOfRounds);
            if (NrOfRounds > 0 && NrOfRounds < 6)
            {
                return true;
            }
            else if (input == "q" || input == "Q")
            {
                Environment.Exit(1);
                return false;
            }
            else if (readable == false)
            {
                Console.WriteLine("Wrong input, pls try again");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine("Not a valid number of rounds, pls try again!");
                Console.WriteLine();
                return false;
            }

        }


        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            int rounds = 1;
            while (rounds <= nrCardsToPlayer)
            {

                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
                rounds++;

            }

        }

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
            int winner = player1.Highest.CompareTo(player2.Highest);
            if (winner == 0)
            {
                Console.WriteLine("Player 1 wins!");
            }
            if (winner == 1)
            {
                Console.WriteLine("Player 2 wins!");
            }
            if (winner == 0)
            {
                Console.WriteLine("It's a tie");
            }
        }
    }
}

