using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batak
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassicGame game = new ClassicGame();
            game.Start();
            Console.Read();
        }
    }
}
