using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class DeckCreator
    {
        public List<Card> CreateDeck()
        {
            List<Card> deck = new List<Card>();

            for (int type = 1; type < 5; type++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    deck.Add(CreateCard(value, type));
                }
            }

            return deck;
        }

        Card CreateCard(int value, int type)
        {
            Card card = new Card(value, (CardType)type);

            return card;
        }
    }
}
