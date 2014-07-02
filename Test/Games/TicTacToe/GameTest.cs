using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace Test
{
    [TestClass]
    public class GameTest
    {
        private TTTGame _g;

        private void SetupGame(int sideLength, int numberOfNonCpus)
        {
            _g = new TTTGame(sideLength, Piece.X, numberOfNonCpus);
        }

        private void TakeManyTurns(params int[] indexs)
        {
            foreach (int index in indexs)
                _g.TakeTurn(index);
        }

        [TestMethod]
        public void TestP1WinReverseDiagonal()
        {
            SetupGame(3,2);
            TakeManyTurns(1, 2, 3, 4, 5, 6, 7);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinDiagonal()
        {
            SetupGame(3, 2);
            TakeManyTurns(3, 5, 2, 1, 6, 9);
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinTopRow()
        {
            SetupGame(3, 2);
            TakeManyTurns(1, 4, 2, 5, 3);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinBottomRow()
        {
            SetupGame(3, 2);
            TakeManyTurns(7, 4, 8, 5, 9);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinCenterRow()
        {
            SetupGame(3, 2);
            TakeManyTurns(4, 1, 5, 2, 6);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinLeftColumn()
        {
            SetupGame(3, 2);
            TakeManyTurns(1, 2, 4, 5, 7);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinRightColumn()
        {
            SetupGame(3, 2);
            TakeManyTurns(3, 2, 6, 5, 9);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1WinCenterColumn()
        {
            SetupGame(3, 2);
            TakeManyTurns(2, 3, 5, 6, 8);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinReverseDiagonal4X4()
        {
            SetupGame(4, 2);
            TakeManyTurns(1, 2, 3, 4, 5, 7, 9, 13, 6, 10);
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinRightColumn4X4()
        {
            SetupGame(4, 2);
            TakeManyTurns(4, 3, 8, 7, 12, 11, 16);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP2WinLowerCenterRow4X4()
        {
            SetupGame(4, 2);
            TakeManyTurns(9, 5, 10, 6, 11, 7, 12);
            Assert.AreEqual(Piece.X, _g.GetWinner());
        }

        [TestMethod]
        public void TestP1Win_AcummulateScore()
        {
            SetupGame(3, 2);
            TakeManyTurns(2, 3, 5, 6, 8);
            _g.GetWinner();
            Assert.AreEqual(1, _g.GetScore(Piece.X));
        }

        [TestMethod]
        public void TestCpuAIClaim6_GameIsDraw()
        {
            SetupGame(3, 0);
            _g.ManuallyPopulateCells(false,1, 2, 3, 7, 8, 9, 4, 5);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.X, _g.GetCellValue(6));
            Assert.AreEqual(Piece.E, _g.GetWinner());
        }

        [TestMethod]
        public void TestCpuAIClaim5_GameIsWin()
        {
            SetupGame(3, 1);
            _g.ManuallyPopulateCells(false,1, 2, 3, 8, 7, 4, 9);
            Assert.AreEqual(Piece.X, _g.GetCellValue(1));
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(5));
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestCpuAIClaim9_GameIsWin()
        {
             SetupGame(3, 1);
             _g.ManuallyPopulateCells(false,1, 3, 5, 6, 4, 7, 2);
            _g.TakeTurn(1);
            Assert.AreEqual(Piece.O, _g.GetCellValue(9));
            Assert.AreEqual(Piece.O, _g.GetWinner());
        }

        [TestMethod]
        public void TestCpuAIResponses()
        {
            SetupGame(3, 1);
            _g.TakeTurn(1);
            _g.TakeTurn(0);
            Assert.AreEqual(Piece.O, _g.GetCellValue(5));
            _g.TakeTurn(1);//already claimed cell
            _g.TakeTurn(6);
            _g.TakeTurn(0);
            Assert.AreEqual(Piece.O, _g.GetCellValue(2));
            _g.TakeTurn(8);
            _g.TakeTurn(0);
            Assert.AreEqual(Piece.O, _g.GetCellValue(7));
            _g.TakeTurn(3);
            _g.TakeTurn(0);
            Assert.AreEqual(Piece.O, _g.GetCellValue(9));
            _g.TakeTurn(4);
            Assert.AreEqual(Piece.E, _g.GetWinner());
        }

        [TestMethod]
        public void TestStartNewGame()
        {
            SetupGame(3, 2);
            TakeManyTurns(1,2,3,7,8,9,4,5,6);
            Assert.AreEqual(Piece.E, _g.GetWinner());
            _g.NewGame();

            foreach (Cell c in _g.Cells)
                Assert.AreEqual(Piece.E, c.CurrentValue);

            Assert.AreEqual(1, _g.GetScore(Piece.E));
        }
    }
}
