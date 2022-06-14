
using Battleships.BL;
using Battleships.UI;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Board mainBoard = new Board(new Randomizer());

mainBoard.Reset(10);
BoardPainter bp = new BoardPainter(mainBoard);

mainBoard.AddShip(new Ship() { Size = 4 });
mainBoard.AddShip(new Ship() { Size = 4 });
mainBoard.AddShip(new Ship() { Size = 5 });

Console.WriteLine("Hint of positions /this will disappear/: ");
Console.WriteLine();
bp.DrawPositions();

while (true)
{
    Console.Write("Choose field: ");
    string fieldName = Console.ReadLine();
    Field selectedField = mainBoard.GetFieldFromPosition(fieldName);
    if (selectedField == null)
    { 
        Console.WriteLine("Wrong field: " + fieldName);
        continue;
    }

    mainBoard.FlipField(selectedField);

    Console.Clear();
    Console.WriteLine();
    Console.WriteLine($"Selected field: {fieldName} - result ->  "+ selectedField.State);
    Console.WriteLine();
    if (selectedField.ShipReference != null)
    {
        Console.WriteLine($"Found ship - status ->  " + (selectedField.ShipReference.IsDestroyed ? "destroyed" : "not destroyed"));
    }
    else
    {
        Console.WriteLine();
    }

    bp.Draw();


    if (mainBoard.IsBoardSolved)
        break;

}

Console.WriteLine();
Console.WriteLine("Game Completed");
Console.WriteLine("Ships destroyed: "+mainBoard.Ships.Count);
Console.ReadLine();