using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class Hand : CardPlace
    {
        public void SetPushable(Card biggestCard, CardType trumpType, CardType currentType, bool trumpActive)
        {
            bool haveICurrentType = HaveICurrentType(currentType);
            bool haveITrumType = HaveITrumType(trumpType);

            SetPushableAll(false);

            if ((!haveICurrentType && !haveITrumType) || currentType == 0)
                SetPushableAll(trumpActive, trumpType);
            else if (haveICurrentType && biggestCard.Compare(currentType))
                SetPushableByType(currentType, biggestCard);
            else if (haveICurrentType && biggestCard.Compare(trumpType))
                SetPushableByType(currentType);
            else if (!haveICurrentType && biggestCard.Compare(currentType))
                SetPushableByType(trumpType);
            else if (!haveICurrentType && biggestCard.Compare(trumpType))
                SetPushableByType(trumpType, biggestCard);
        }

        void SetPushableAll(bool pushable)
        {
            foreach (Card card in cards)
            {
                card.Pushable(pushable);
            }
        }

        void SetPushableAll(bool trumpActive, CardType trump)
        {
            foreach (Card card in cards)
            {
                if (trumpActive)
                    card.Pushable(true);
                else
                {
                    if (card.Compare(trump))
                        continue;

                    card.Pushable(true);
                }
            }
        }

        void SetPushableByType(CardType type, Card biggestCard)
        {
            bool atLeastOne = false;

            foreach (Card card in cards)
            {
                if (card.Compare(type) && card.Value > biggestCard.Value)
                {
                    card.Pushable(true);
                    atLeastOne = true;
                }
            }

            if (!atLeastOne)
                SetPushableByType(type);
        }

        void SetPushableByType(CardType type)
        {
            foreach (Card card in cards)
            {
                if (card.Compare(type))
                    card.Pushable(true);
            }
        }

        bool HaveICurrentType(CardType currentType)
        {
            foreach (Card card in cards)
            {
                if (card.Compare(currentType))
                    return true;
            }

            return false;
        }

        bool HaveITrumType(CardType trumpType)
        {
            foreach (Card card in cards)
            {
                if (card.Compare(trumpType))
                    return true;
            }

            return false;
        }

        public void SortCard()
        {
            List<Card> sortedCard = new List<Card>();
            for (int type = 1; type < 5; type++)
            {
                List<Card> monoTypeCard = new List<Card>();

                foreach (Card card in cards)
                {
                    if (card.Type == (CardType)type)
                        monoTypeCard.Add(card);
                }

                GameUtils.BubbleSort(ref monoTypeCard);

                for (int i = 0; i < monoTypeCard.Count; i++)
                    sortedCard.Add(monoTypeCard[i]);
            }

            cards = sortedCard;
        }
    }
}
