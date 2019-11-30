using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class Table : CardPlace
    {
        public CardType currentType;
        public CardType trumpType;

        public override void PushCard(Card card)
        {
            if (currentType == 0)
            {
                currentType = card.Type;
            }

            base.PushCard(card);
        }

        public override void ClearCards()
        {
            base.ClearCards();
            currentType = 0;
        }

        public Card GetBiggestCard()
        {
            Card biggestCard = new Card(0, currentType);

            foreach (Card card in cards)
            {
                if (card.Compare(trumpType))
                {
                    if (!biggestCard.Compare(trumpType))
                    {
                        biggestCard = card;
                    }
                    else if (biggestCard.Value < card.Value)
                    {
                        biggestCard = card;
                    }
                }
                else if (!card.Compare(currentType))
                    continue;
                else
                {
                    if (biggestCard.Value < card.Value && !(biggestCard.Compare(trumpType)))
                    {
                        biggestCard = card;
                    }
                }
            }

            return biggestCard;
        }
    }
}
