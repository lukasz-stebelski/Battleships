using Battleships.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BL
{
    public class Randomizer : IRandomizer
    {
        private Random rnd = new Random();
        public int GetRandomDirection()
        {
            return (int)(rnd.NextInt64() % 2);
        }

        public int GetRandomPosition(int boardSize)
        {
           return (int)(rnd.NextInt64() % (boardSize * boardSize));
        }
    }
}
