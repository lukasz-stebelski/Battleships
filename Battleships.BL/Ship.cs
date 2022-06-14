using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BL
{
    public class Ship
    {
        public List<Field> Fields { get; set; }
        public int Size { get; set; }
        public int Direction { get; set; }

        public bool IsDestroyed { get { return Fields.All(f => f.State == FieldState.Hit); } }
    }
}
