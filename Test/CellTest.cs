using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace Test
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void TestCreateCell()
        {
            var c = new Cell();
            Assert.AreEqual(Piece.E, c.CurrentValue);
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
