using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    public class GameAnimation
    {
        private static GameAnimation instance;

        int delay = 1000;

        private GameAnimation()
        {
        }

        public static GameAnimation GetInstance()
        {
            if (instance == null)
            {
                instance = new GameAnimation();
            }

            return instance;
        }

        public async void DealAnimation()
        {
            Console.WriteLine("Kart dağıtılıyor");

            await Task.Delay(delay);

            ClassicGame.instance.Move();
        }

        public async Task BidAnimation(Player player)
        {
            Console.WriteLine(player.name + " Konuştu: " + player.bid);

            await Task.Delay(delay);
        }

        public async Task TrumpAnimation(Player player)
        {
            Console.WriteLine(player.name + " " + player.bid + " girdi, " + "Koz söyledi: " + player.trumpType);

            await Task.Delay(delay);
        }

        public async Task PushCard(Player player, Card card)
        {
            Console.WriteLine(player.name + " Attı " + card.Value + " " + card.Type);

            await Task.Delay(delay);
        }

        public async void TurnWin(TurnManager turnManager)
        {
            Console.WriteLine(turnManager.turnWinner.name + " Yeri aldı ");

            await Task.Delay(delay);

            ClassicGame.instance.EndMove();
        }
    }
}
