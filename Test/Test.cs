using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace Test
{
    [TestClass]
    public class Test
    {
        private Game _g;

        private void SetupGame(int side)
        {
            _g = new Game(side, Piece.X);
        }

        private void TakeManyTurns(params int[] indexs)
        {
            foreach (int index in indexs)
                _g.PlayerTakeTurn(index);
        }

        [TestMethod]
        public void TestPlayer1WinReverseDiagonal()
        {
            SetupGame(3);
            TakeManyTurns(1, 2, 3, 4, 5, 6, 7);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer2WinDiagonal()
        {
            SetupGame(3);
            TakeManyTurns(3, 5, 2, 1, 6, 9);
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer1WinTopRow()
        {
            SetupGame(3);
            TakeManyTurns(1, 4, 2, 5, 3);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer1WinBottomRow()
        {
            SetupGame(3);
            TakeManyTurns(7, 4, 8, 5, 9);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer1WinCenterRow()
        {
            SetupGame(3);
            TakeManyTurns(4, 1, 5, 2, 6);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer1WinLeftColumn()
        {
            SetupGame(3);
            TakeManyTurns(1, 2, 4, 5, 7);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer1WinRightColumn()
        {
            SetupGame(3);
            TakeManyTurns(3, 2, 6, 5, 9);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer1WinCenterColumn()
        {
            SetupGame(3);
            TakeManyTurns(2, 3, 5, 6, 8);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer2WinReverseDiagonal4X4()
        {
            _g = new Game(4, Piece.X);
            TakeManyTurns(1, 2, 3, 4, 5, 7, 9, 13, 6, 10);
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer2WinRightColumn4X4()
        {
            _g = new Game(4, Piece.X);
            TakeManyTurns(4, 3, 8, 7, 12, 11, 16);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestPlayer2WinLowerCenterRow4X4()
        {
            _g = new Game(4, Piece.X);
            TakeManyTurns(9, 5, 10, 6, 11, 7, 12);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }
    }
}
