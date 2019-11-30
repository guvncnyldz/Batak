using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class BidManager
    {
        public Player bider;

        private List<Player> players;
        private int firstTalk;
        private int currentTalk;
        private int totalTalk;

        public BidManager(List<Player> players)
        {
            this.players = players;

            firstTalk = 0;
            currentTalk = firstTalk;
            totalTalk = 0;
        }

        public void Reset()
        {
            GameUtils.NextPlayer(ref firstTalk);

            currentTalk = firstTalk;
            totalTalk = 0;

            bider = null;
        }

        public bool IsBidDone()
        {
            if (totalTalk == 4)
            {
                FindBider();
                return true;
            }

            GetBid();
            GameUtils.NextPlayer(ref currentTalk);
            totalTalk++;
            return false;
        }

        private void GetBid()
        {
            players[currentTalk].EnterBid();

        }

        private void FindBider()
        {
            Player bestBider = players[firstTalk];

            foreach (var player in players)
            {
                if (player.bid > bestBider.bid)
                    bestBider = player;
            }

            if (bestBider.bid >= 5)
            {
                bider = bestBider;
            }
            else
            {
                bider = players[firstTalk];
                bider.bid = 4;
            }

            bider.EnterTrump();
        }
    }
}
