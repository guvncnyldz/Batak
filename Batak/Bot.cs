using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class Bot : Player
    {
        public async override void PushCard(Table table, PushHandler callBack)
        {
            Card card = CalculatePush(table);

            await GameAnimation.GetInstance().PushCard(this, card);
            //Animasyon

            callBack(card);
            ClassicGame.instance.Move();
        }

        public async override void EnterBid()
        {
            CalculateBid();

            await GameAnimation.GetInstance().BidAnimation(this);

            ClassicGame.instance.Move();
            //Animasyon
        }

        public async override void EnterTrump()
        {
            await GameAnimation.GetInstance().TrumpAnimation(this);

            ClassicGame.instance.Move();
            //Animasyon
        }

        public Card CalculatePush(Table table)
        {
            List<Card> pushableCards = new List<Card>();

            foreach (Card card in hand.cards)
            {
                if (card.IsPushable)
                    pushableCards.Add(card);
            }

            if (table.currentType == 0)
            {
                Random random = new Random();
                return pushableCards[random.Next(0, pushableCards.Count)];
            }
            if (pushableCards[0].Value == 13)
            {
                return pushableCards[0];
            }
            else
            {
                return pushableCards[pushableCards.Count - 1];
            }
        }

        public void CalculateBid()
        {
            int aceCount = 0;
            int faceCount = 0;

            int[] typeCount = { 0, 0, 0, 0 };

            foreach (Card card in hand.cards)
            {
                if (card.Value > 5)
                    typeCount[((int)card.Type) - 1]++;

                if (card.Value == 11 && card.Value == 12)
                    faceCount++;
                else if (card.Value == 13)
                    aceCount++;
            }

            bid = aceCount + (faceCount / 2);

            int trumpCount = typeCount[0];
            trumpType = (CardType)1;

            for (int i = 0; i < 4; i++)
            {
                if (typeCount[i] > trumpCount)
                {
                    trumpCount = typeCount[i];
                    trumpType = (CardType)i + 1;
                }
            }

            bid += trumpCount - 2;

            if (bid < 5)
                bid = 0;
        }
    }
}
