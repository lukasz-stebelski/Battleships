using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BL
{
    public class Field
    {
        public Field(int x, int y)
        {
            State = FieldState.Hidden;
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Position { get; set; }

        public Ship ShipReference { get; set; }
        public FieldState State { get; set; }



    }
}
