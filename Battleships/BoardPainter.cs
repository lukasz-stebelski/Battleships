using Battleships.BL;
using Battleships.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.UI
{
    public class BoardPainter : IBoardPainter
    {
        private Board _board;
        public BoardPainter(Board board)
        {
            _board = board;
        }

        public void Draw()
        {
            Console.WriteLine();
            Console.Write("  ");
            for (int i = 0; i < _board.Size; i++)
            {
                Console.Write($"{i + 1} ");
            }
            Console.WriteLine();
            for (int i = 0; i < _board.Size; i++)
            {
                Console.Write($"{((char)(65 + i))} ");
                for (int j = 0; j < _board.Size; j++)
                {

                    var selectedField = _board.Fields[i * _board.Size + j];
                    switch (selectedField.State)
                    {
                        case FieldState.Hidden: Console.Write($"{(char)9632} "); break;
                        case FieldState.Hit:
                            {
                                Console.ForegroundColor = selectedField.ShipReference.IsDestroyed ? ConsoleColor.Red :  ConsoleColor.Yellow;
                                Console.Write($"{(char)9642} "); 
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            }
                        case FieldState.Unhidden: Console.Write($"{(char)9633} "); break;
                    }

                    if (j == _board.Size - 1)
                    {
                        Console.WriteLine();
                    }

                }
            }
            Console.WriteLine();
        }

        public void DrawPositions()
        {
            Console.Write("  ");
            for (int i = 0; i < _board.Size; i++)
            {
                Console.Write($"{i + 1} ");
            }
            Console.WriteLine();
            for (int i = 0; i < _board.Size; i++)
            {
                Console.Write($"{((char)(65 + i))} ");
                for (int j = 0; j < _board.Size; j++)
                {


                    if (_board.Fields[i * _board.Size + j].ShipReference != null)
                    {
                        var prev = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{(char)9642} ");
                        Console.ForegroundColor = prev;
                    }
                    else
                    {
                        Console.Write($"{(char)9632} ");
                    }

                    if (j == _board.Size - 1)
                    {
                        Console.WriteLine();
                    }

                }
            }
            Console.WriteLine();
        }
    }
}
