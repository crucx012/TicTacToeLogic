using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace Test
{
    [TestClass]
    public class GridTest
    {
        private Cell[,] _cells;

        [TestMethod]
        public void TestCreateGrid()
        {
            _cells = new Cell[3,3];
            var g = new Grid(_cells);
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void TestSetCell()
        {
            var c = new Cell();
            c.SetCellToPlayerPiece(Piece.X);
            Assert.AreEqual(Piece.X, c.CurrentValue);
        }
    }
}
