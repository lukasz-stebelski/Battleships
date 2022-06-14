using Battleships.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.BL
{
    public class Board : IBoard
    {
        private IRandomizer _randomizer;
        public Board(IRandomizer randomizer)
        {
            Ships = new List<Ship>();
            _randomizer = randomizer;
        }
        public Field[] Fields { get; set; }
        public List<Ship> Ships { get; set; }
        public int Size { get; set; }

        public bool IsBoardSolved { get { return Ships.All(s => s.IsDestroyed); } }

        public Field GetFieldFromPosition(string position)
        {
            return Fields.FirstOrDefault(f => f.Position == position.ToUpper());
        }

        public Field[] Reset(int size)
        {
            Size = size;
            Fields = new Field[size * size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Fields[i * size + j] = new Field(j, i);
                    Fields[i * size + j].Position = (char)(65 + i) + (j + 1).ToString();
                }
            }
            return Fields;
        }

        public Field FlipField(Field field)
        {
            if (field.ShipReference != null)
                field.State = FieldState.Hit;
            else
                field.State = FieldState.Unhidden;

            return field;
        }

        public bool AddShip(Ship ship)
        {
            int attempts = 0;
            bool positionFound = false;
            while (attempts < 100 && !positionFound)
            {
                int pos =_randomizer.GetRandomPosition(Size);
                ship.Direction = _randomizer.GetRandomDirection();

                List<Field> selectedFields = new List<Field>();
                bool allFieldsInBoard = true;
                switch (ship.Direction)
                {
                    case 0: //horizontal
                        selectedFields.Clear();

                        for (int i = 0; i < ship.Size; i++)
                        {
                            int selectedPos = pos + i;
                            if (selectedPos < Fields.Length)
                                selectedFields.Add(Fields[selectedPos]);
                            else
                            {
                                allFieldsInBoard = false;
                                break;
                            }
                        }

                        if (!allFieldsInBoard)
                        {
                            positionFound = false;
                            break;

                        }

                        int yPos = selectedFields[0].Y;
                        if (selectedFields.All(sf => sf.Y == yPos) && selectedFields.All(sf => sf.ShipReference == null))
                        {
                            selectedFields.ForEach(sf => sf.ShipReference = ship);
                            ship.Fields = selectedFields;
                            Ships.Add(ship);
                            positionFound = true;
                        }
                        break;
                    case 1: //vertical
                        selectedFields.Clear();
                        for (int i = 0; i < ship.Size; i++)
                        {
                            int selectedPos = pos + i * Size;
                            if (selectedPos < Fields.Length)
                                selectedFields.Add(Fields[selectedPos]);
                            else
                            {
                                allFieldsInBoard = false;
                                break;
                            }
                        }

                        if (!allFieldsInBoard)
                        {
                            positionFound = false;
                            break;
                        }

                        int xPos = selectedFields[0].X;
                        if (selectedFields.All(sf => sf.X == xPos) && selectedFields.All(sf => sf.ShipReference == null))
                        {
                            selectedFields.ForEach(sf => sf.ShipReference = ship);
                            ship.Fields = selectedFields;
                            Ships.Add(ship);
                            positionFound = true;
                        }
                        break;
                }
                attempts++;
            }

            if (attempts == 100 && !positionFound)
                return false;
            else
                return true;

        }
    }
}
