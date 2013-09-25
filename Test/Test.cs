using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace Test
{
    [TestClass]
    public class Test
    {
        private Game _g;

        private void Setup2PlayerGame()
        {
            _g = new Game(3, Piece.X, 2);
        }

        private void Setup4X4Game()
        {
            _g = new Game(4, Piece.X, 2);
        }

        private void Setup1PlayerGame()
        {
            _g = new Game(3, Piece.X, 1);
        }

        private void Setup0PlayerGame()
        {
            _g = new Game(3, Piece.X, 0);
        }

        private void TakeManyTurns(params int[] indexs)
        {
            foreach (int index in indexs)
                _g.TakeTurn(index);
        }

        [TestMethod]
        public void TestP1WinReverseDiagonal()
        {
            Setup2PlayerGame();
            TakeManyTurns(1, 2, 3, 4, 5, 6, 7);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinDiagonal()
        {
            Setup2PlayerGame();
            TakeManyTurns(3, 5, 2, 1, 6, 9);
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinTopRow()
        {
            Setup2PlayerGame();
            TakeManyTurns(1, 4, 2, 5, 3);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinBottomRow()
        {
            Setup2PlayerGame();
            TakeManyTurns(7, 4, 8, 5, 9);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinCenterRow()
        {
            Setup2PlayerGame();
            TakeManyTurns(4, 1, 5, 2, 6);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinLeftColumn()
        {
            Setup2PlayerGame();
            TakeManyTurns(1, 2, 4, 5, 7);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinRightColumn()
        {
            Setup2PlayerGame();
            TakeManyTurns(3, 2, 6, 5, 9);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinCenterColumn()
        {
            Setup2PlayerGame();
            TakeManyTurns(2, 3, 5, 6, 8);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinReverseDiagonal4X4()
        {
            Setup4X4Game();
            TakeManyTurns(1, 2, 3, 4, 5, 7, 9, 13, 6, 10);
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinRightColumn4X4()
        {
            Setup4X4Game();
            TakeManyTurns(4, 3, 8, 7, 12, 11, 16);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinLowerCenterRow4X4()
        {
            Setup4X4Game();
            TakeManyTurns(9, 5, 10, 6, 11, 7, 12);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1Win_AcummulateScore()
        {
            Setup2PlayerGame();
            TakeManyTurns(2, 3, 5, 6, 8);
            _g.GetWinner();
            Assert.AreEqual(1, _g.GetScore(Piece.X));
        }

        [TestMethod]
        public void TestCpuAIResponse6_Draw()
        {
            Setup0PlayerGame();
            _g.ManuallyPopulateCells(1, 2, 3, 7, 8, 9, 4, 5);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.X, _g.GetCellValue(6));
            Assert.AreEqual(Piece.E, _g.GetWinner());
        }

        [TestMethod]
        public void TestCpuAIResponse5_Win()
        {
            Setup1PlayerGame();
            _g.ManuallyPopulateCells(1, 2, 3, 8, 7, 4, 9);
            Assert.AreEqual(Piece.X, _g.GetCellValue(1));
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(5));
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestCpuAIResponse9_Win()
        {
            Setup1PlayerGame();
            _g.ManuallyPopulateCells(1, 3, 5, 6, 4, 7, 2);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(9));
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestCpuAIResponses()
        {
            Setup1PlayerGame();
            _g.TakeTurn(1);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(5));
            _g.TakeTurn(6);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(2));
            _g.TakeTurn(8);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(7));
            _g.TakeTurn(3);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(9));
            _g.TakeTurn(4);
            Assert.AreEqual(Piece.E, _g.GetWinner());
        }
    }
}
