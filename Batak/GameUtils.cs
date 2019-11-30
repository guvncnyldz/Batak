using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public static class GameUtils
    {
        public static void BubbleSort(ref List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = 0; j < cards.Count - 1; j++)
                {
                    if (cards[j].Value < cards[j + 1].Value)
                    {
                        Card temp = cards[j];
                        cards[j] = cards[j + 1];
                        cards[j + 1] = temp;
                    }
                }
            }
        }

        public static void NextPlayer(ref int playerIndex)
        {
            playerIndex++;

            if (playerIndex == 4)
                playerIndex = 0;
        }
    }
}
