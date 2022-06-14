using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BL.Interfaces
{
    public interface IRandomizer
    {
        int GetRandomPosition(int boardSize);
        int GetRandomDirection();

    }
}
