using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class Deck
    {
        private List<Card> cards;

        public void NewDeck()
        {
            cards = new List<Card>();

            DeckCreator deckCreator = new DeckCreator();
            cards = deckCreator.CreateDeck();
        }
        public void Shuffle()
        {
            Random random = new Random();

            int length = cards.Count;
            for (int i = 0; i < length; i++)
            {
                int r = random.Next(i, length);
                Card temp = cards[r];
                cards[r] = cards[i];
                cards[i] = temp;
            }
        }

        public virtual void Deal(CardPlace place, int count)
        {
            for (int i = 0; i < count; i++)
            {
                place.PushCard(cards[0]);
                cards.Remove(cards[0]);
            }
        }
    }
}
