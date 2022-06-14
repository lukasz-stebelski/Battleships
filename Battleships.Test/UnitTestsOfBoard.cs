using Battleships.BL;
using Battleships.BL.Interfaces;
using Moq;

namespace Battleships.Test
{
    [TestClass]
    public class UnitTestsOfBoard
    {
        [TestMethod]
        public void CanResetBoard()
        {
            Board b = new Board(null);
            b.Reset(5);
            b.Fields[0].State = FieldState.Hit;
            b.Fields[2].State = FieldState.Hit;

            b.Reset(5); //set new size

            Assert.AreEqual(true, b.Fields.Length == 5*5);
            Assert.AreEqual(true, b.Fields.All(f=>f.State == FieldState.Hidden));


        }

        [TestMethod]
        public void CanFlipAFieldToUnhidden()
        {
            Board b = new Board(null);
            b.Reset(5);
            b.Fields[2].ShipReference = null;

            b.FlipField(b.Fields[2]);  

            Assert.AreEqual(true, b.Fields[2].State == FieldState.Unhidden);

        }

        [TestMethod]
        public void CanFlipAFieldToHit()
        {
            Board b = new Board(null);
            b.Reset(5);
            b.Fields[2].ShipReference = new Ship();

            b.FlipField(b.Fields[2]);

            Assert.AreEqual(true, b.Fields[2].State == FieldState.Hit);

        }

        [TestMethod]
        public void CanAddShipToNewPosition()
        {
            int boardSize = 5;
            Mock<IRandomizer>  randomizerMock  = new Mock<IRandomizer>();

            randomizerMock.Setup(x => x.GetRandomPosition(boardSize)).Returns(2);
            randomizerMock.Setup(x => x.GetRandomDirection()).Returns(0); //horizontal

            Board board = new Board(randomizerMock.Object);
            board.Reset(boardSize);
            bool result = board.AddShip(new Ship() { Size = 3 });

            Assert.AreEqual(result, true);

        }


        [TestMethod]
        public void IsAddingShipToNewPositionBeyoundBoardBlocked()
        {
            int boardSize = 5;
            Mock<IRandomizer> randomizerMock = new Mock<IRandomizer>();

            randomizerMock.Setup(x => x.GetRandomPosition(boardSize)).Returns(2);
            randomizerMock.Setup(x => x.GetRandomDirection()).Returns(0); //horizontal

            Board board = new Board(randomizerMock.Object);
            board.Reset(boardSize);
            bool result = board.AddShip(new Ship() { Size = 10 });

            Assert.AreEqual(result, false);

        }
    }
}