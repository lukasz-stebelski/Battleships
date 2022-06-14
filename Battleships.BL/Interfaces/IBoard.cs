using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BL.Interfaces
{
    public interface IBoard
    {
        Field GetFieldFromPosition(string position);

        Field[] Reset(int size);

        Field FlipField(Field field);

        bool AddShip(Ship ship);

    }
}
