namespace TicTacToeLogic
{
    class Grid
    {
        public int Side { get; set; }

        private readonly Cell[,] _cells;

        public Grid(Cell[,] cells)
        {
            _cells = cells;
        }

        public Piece GetWinner()
        {
            for (var n = 0; n < Side; n++)
            {
                if (IsRowMatchingCells(n)
                    && IsCellClaimed(n, 0))
                    return _cells[n, 0].CurrentValue;
                if (IsColumnMatchingCells(n)
                    && IsCellClaimed(0, n))
                    return _cells[0, n].CurrentValue;
                if (IsDiagonalMatching()
                         && IsCellClaimed(n, n))
                    return _cells[n, n].CurrentValue;
                if (IsReverseDiagonalMatching()
                         && IsCellClaimed(n, Side - 1))
                    return _cells[n, Side - 1].CurrentValue;
            }

            return Piece.N;
        }

        private bool IsRowMatchingCells(int n)
        {
            var isMatching = true;

            for (int i = 1; i < Side; i++)
                if (_cells[n, 0].CurrentValue != _cells[n, i].CurrentValue)
                    isMatching = false;

            return isMatching;
        }

        private bool IsColumnMatchingCells(int n)
        {
            var isMatching = true;

            for (int i = 1; i < Side; i++)
                if (_cells[0, n].CurrentValue != _cells[i, n].CurrentValue)
                    isMatching = false;

            return isMatching;
        }

        private bool IsDiagonalMatching()
        {
            var isMatching = true;

            for (int n = 1; n < Side; n++)
                if (_cells[0, 0].CurrentValue != _cells[n, n].CurrentValue)
                    isMatching = false;

            return isMatching;
        }

        private bool IsReverseDiagonalMatching()
        {
            var isMatching = true;

            for (int n = 1; n < Side; n++)
                if (_cells[0, Side - 1].CurrentValue != _cells[n, Side - 1 - n].CurrentValue)
                    isMatching = false;

            return isMatching;
        }

        private bool IsCellClaimed(int row, int column)
        {
            return _cells[row, column].CurrentValue != Piece.N;
        }
    }
}
