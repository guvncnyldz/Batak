using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public abstract class Player
    {
        public delegate void PushHandler(Card card);

        public string name;
        public int CurrentScore;
        public int TotalScore;

        public int bid;
        public CardType trumpType;

        public Hand hand;

        public Player()
        {
            hand = new Hand();

            CurrentScore = 0;
            TotalScore = 0;
        }

        public void CalculateTotalScore(int maxBidInGame, Player bider)
        {
            if (CurrentScore < bid && bider == this)
                TotalScore -= maxBidInGame;
            else if (CurrentScore == 0)
                TotalScore -= maxBidInGame;
            else
                TotalScore += CurrentScore;

            CurrentScore = 0;
        }

        public void AddScore(int score)
        {
            CurrentScore += score;
        }

        public void SetBid(int bid)
        {
            this.bid = bid;
        }

        public abstract void PushCard(Table table, PushHandler callBack);
        public abstract void EnterBid();
        public abstract void EnterTrump();
    }
}
