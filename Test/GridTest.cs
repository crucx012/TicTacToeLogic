using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace Test
{
    [TestClass]
    public class GridTest
    {
        private Cell[,] _cells;
        private Grid _g;

        private void CreateGrid(int sideLength)
        {
            _cells = new Cell[sideLength, sideLength];

            for (var i = 0; i < sideLength; i++)
                for (var j = 0; j < sideLength; j++)
                    _cells[i, j] = new Cell { X = i, Y = j };

            _g = new Grid(_cells) { SideLength = sideLength };
        }

        [TestMethod]
        public void TestCreateGrid()
        {
            CreateGrid(3);
            Assert.IsNotNull(_g);
        }

        [TestMethod]
        public void TestCloneGrid()
        {
            CreateGrid(3);
            var newGrid = _g.Clone();

            for (int i = 0; i < _g.SideLength; i++)
                for (int j = 0; j < _g.SideLength; j++)
                {
                    Assert.AreEqual(_g.Cells[i, j].CurrentValue, newGrid.Cells[i, j].CurrentValue);
                    Assert.AreEqual(_g.Cells[i, j].Rank, newGrid.Cells[i, j].Rank);
                    Assert.AreEqual(_g.Cells[i, j].X, newGrid.Cells[i, j].X);
                    Assert.AreEqual(_g.Cells[i, j].Y, newGrid.Cells[i, j].Y);
                }
         
            Assert.AreEqual(_g.EmptyCells.Count, newGrid.EmptyCells.Count);
            Assert.AreEqual(_g.SideLength, newGrid.SideLength);
            Assert.AreEqual(_g.Winner, newGrid.Winner);
        }
    }
}
