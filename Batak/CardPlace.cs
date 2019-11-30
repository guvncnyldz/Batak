using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public abstract class CardPlace
    {
        public List<Card> cards;

        public virtual void PushCard(Card card)
        {
            if (cards == null)
                cards = new List<Card>();

            cards.Add(card);
        }

        public virtual void PullCard(Card card)
        {
            cards.Remove(card);
        }

        public virtual Card PullCard(int index)
        {
            Card card = cards[index];
            cards.Remove(card);

            return card;
        }

        public virtual void ClearCards()
        {
            cards?.Clear();
        }
    }
}
