using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class TurnManager
    {
        private List<Player> players;

        public Card biggestCard;
        public Player turnWinner;
        private Table table;

        private bool trumpActive = false;

        private int currentTurn;
        private int totalTurn = 0;

        public TurnManager(List<Player> players)
        {
            this.players = players;

            table = new Table();
            biggestCard = new Card(0, 0);
            turnWinner = null;

            totalTurn = 0;
            currentTurn = -1;
        }

        public bool IsTurnDone(Player bider)
        {
            if (totalTurn == 4)
            {
                FinTurn();
                return true;
            }

            if (currentTurn == -1)
            {
                currentTurn = players.IndexOf(bider);
                SetTrump(bider.trumpType);
                return false;
            }

            BeginTurn();
            return false;
        }

        void SetTrump(CardType trumpType)
        {
            table.trumpType = trumpType;
        }

        void BeginTurn()
        {
            players[currentTurn].hand.SetPushable(biggestCard, table.trumpType, table.currentType, trumpActive);
            players[currentTurn].PushCard(table, EndTurn);
        }

        public void EndTurn(Card card)
        {
            if (card.Compare(table.trumpType) && !trumpActive)
                trumpActive = true;

            players[currentTurn].hand.PullCard(card);
            table.PushCard(card);

            Card biggestTemp = table.GetBiggestCard();

            if (!biggestCard.Compare(biggestTemp))
            {
                biggestCard = biggestTemp;
                turnWinner = players[currentTurn];
            }

            GameUtils.NextPlayer(ref currentTurn);
            totalTurn++;
        }

        public void FinTurn()
        {
            totalTurn = 0;
            currentTurn = players.IndexOf(turnWinner);

            turnWinner.AddScore(1);
            biggestCard = new Card(0, 0);
            table.ClearCards();
        }

        public void Reset()
        {
            currentTurn = -1;
        }
    }
}
