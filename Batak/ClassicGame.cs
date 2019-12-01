using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class ClassicGame
    {
        public static ClassicGame instance;

        public List<Player> players;

        private Deck deck;
        private Table table;
        private TurnManager turnManager;
        private BidManager bidManager;

        private int maxGameCount = 11;
        private int currentGameCount = 0;

        private int cardCount = 13;

        private bool isBidDone;
        private bool isTurnDone;

        public bool isGameDone;

        public void Start()
        {
            instance = this;

            players = new List<Player>();

            for (int i = 0; i < 4; i++)
            {
                Player player = new Bot();
                player.name = i + 1 + ".ci Oyuncu";
                players.Add(player);
            }

            deck = new Deck();

            turnManager = new TurnManager(players);
            bidManager = new BidManager(players);


            DealDeck();
        }

        public void Move()
        {
            if (!isBidDone) isBidDone = bidManager.IsBidDone();

            if (!isGameDone)
            {
                if (isBidDone)
                {
                    if (!isTurnDone) isTurnDone = turnManager.IsTurnDone(bidManager.bider);

                    if (isTurnDone)
                    {
                        isTurnDone = false;
                        GameAnimation.GetInstance().TurnWin(turnManager);
                    }
                }
            }
        }

        public void EndMove()
        {
            cardCount--;
            if (cardCount == 0)
            {
                EndRound();
            }
            else if (cardCount >= 1)
                Move();
        }

        void EndRound()
        {
            currentGameCount++;
            CalculateTotalScore();

            turnManager.Reset();

            if (currentGameCount == maxGameCount)
            {
                FinGame();
            }
            else
            {
                NextRound();
            }
        }

        void NextRound()
        {
            cardCount = 13;
            bidManager.Reset();

            isBidDone = false;
            isTurnDone = false;

            DealDeck();
        }

        public void DealDeck()
        {
            deck.NewDeck();
            deck.Shuffle();

            foreach (Player player in players)
            {
                player.hand.ClearCards();
                deck.Deal(player.hand, 13);
                player.hand.SortCard();
            }

            GameAnimation.GetInstance().DealAnimation();
        }

        private void FinGame()
        {
            Player winner = players[0];

            foreach (Player player in players)
            {
                if (player.TotalScore > winner.TotalScore)
                    winner = player;
            }

            Console.WriteLine(winner.name + " Oyunu kazandı");

            isGameDone = true;
        }


        void CalculateTotalScore()
        {
            foreach (var VARIABLE in players)
            {
                VARIABLE.CalculateTotalScore(bidManager.bider.bid, bidManager.bider);
                Console.WriteLine(VARIABLE.name + " toplam skoru " + VARIABLE.TotalScore);
            }
        }

        void DisplayScore()
        {
            foreach (var VARIABLE in players)
            {
                Console.WriteLine(VARIABLE.name + " Su anki skoru " + VARIABLE.CurrentScore);
            }
        }
    }
}
