using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace Test
{
    [TestClass]
    public class PlayerTest
    {
        private Player _p;

        private void CreatePlayer(Piece p, bool isCpu)
        {
            _p = new Player { Piece = p, IsCpu = isCpu };
        }

        [TestMethod]
        public void TestCreatePlayer()
        {
            CreatePlayer(Piece.X, false);
            Assert.AreEqual(Piece.X, _p.Piece);
        }

        [TestMethod]
        public void TestClaimCell()
        {
            CreatePlayer(Piece.X, false);
            var c = new Cell();
            _p.SetPiece(c);
            Assert.AreEqual(Piece.X, c.CurrentValue);
        }

        [TestMethod]
        public void TestPlayerAI()
        {
            CreatePlayer(Piece.O, true);
            var cells = new Cell[3,3];

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    cells[i, j] = new Cell { X = i, Y = j };

            var g = new Grid(cells) {Side = 3};
            g.Cells[0, 0].CurrentValue = Piece.X;
            var claimedCell = _p.AI(g, _p.Piece);
            _p.SetPiece(g.Cells[claimedCell.X, claimedCell.Y]);
            Assert.AreEqual(Piece.O, g.Cells[1,1].CurrentValue);
        }
    }
}
