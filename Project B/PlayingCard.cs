using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard other)
		{
			if (Color != other.Color)
				return Color.CompareTo(other.Color);
			else
				return Value.CompareTo(other.Value);
		}
		#endregion

		#region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
			get
			{
				return "Short Description of the card";
			}
		}

		public override string ToString()
		{
			string clubs = "\u2663";
			string diamonds = "\u2666";
			string hearts = "\u2665";
			string spades = "\u2660";

			if (Color == PlayingCardColor.Clubs)
			{
				return $"{clubs}: {Value}";
			}
			if (Color == PlayingCardColor.Diamonds)
			{
				return $"{diamonds}: {Value}";
			}
			if (Color == PlayingCardColor.Hearts)
			{
				return $"{hearts}: {Value}";
			}
			if (Color == PlayingCardColor.Spades)
			{
				return $"{spades}: {Value}";
			}
			else
			{
				return $"{Color}: {Value}";
			}

		}
		#endregion
	}
}
