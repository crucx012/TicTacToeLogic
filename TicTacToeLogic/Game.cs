namespace TicTacToeLogic
{
    public enum Piece { E = 0, O = 1, X = 2 }

    public class Game
    {
        private Cell ClaimedCell { get; set; }
        public Piece Winner { get; set; }
        private int Turn { get; set; }
        readonly int[] _score = new[] { 0, 0, 0 };
        readonly Player _player1 = new Player();
        readonly Player _player2 = new Player();
        readonly Grid _grid;
        readonly Cell[,] _cells;

        public Game(int sideSize, Piece firstPlayer, int numberOfNonCpus)
        {
            _cells = new Cell[sideSize, sideSize];
            _grid = new Grid(_cells) { Side = sideSize };

            SetCollectionToValue(sideSize);
            SetPlayerPieces(firstPlayer);
            SetPlayerCpuFlags(numberOfNonCpus);
        }

        private void SetPlayerPieces(Piece firstPlayer)
        {
            _player1.Piece = firstPlayer;
            _player2.Piece = firstPlayer == Piece.X ? Piece.O : Piece.X;
        }

        private void SetCollectionToValue(int side)
        {
            for (var i = 0; i < side; i++)
                for (var j = 0; j < side; j++)
                    _cells[i, j] = new Cell { CurrentValue = Piece.E, X = i, Y = j };
        }

        private void SetPlayerCpuFlags(int players)
        {
            if (players == 1)
                _player2.IsCpu = true;
            if (players == 0)
                _player1.IsCpu = true;
        }

        public void TakeTurn(int index)
        {
            if (IsCpuTurn())
                CpuChooseCell();
            else
                ConvertIndexToCell(index);

            if (IsCellClaimed()) return;
            ClaimCell();
            Turn++;
        }

        private bool IsCpuTurn()
        {
            return IsFirstPlayersTurn()
                   && _player1.IsCpu
                   || !IsFirstPlayersTurn()
                   && _player2.IsCpu;
        }

        private bool IsFirstPlayersTurn()
        {
            return Turn % 2 == 0;
        }

        private void CpuChooseCell()
        {
            Cell chosenCell = IsFirstPlayersTurn() ? _player1.AI(_grid, _player1.Piece) : _player2.AI(_grid, _player2.Piece);
            ClaimedCell = _grid.Cells[chosenCell.X, chosenCell.Y];
        }

        private void ConvertIndexToCell(int index)
        {
            var row = 0;

            for (; index > _grid.Side; index -= _grid.Side)
                row++;

            var column = index - 1;

            ClaimedCell = _cells[row, column];
        }

        private bool IsCellClaimed()
        {
            return ClaimedCell.CurrentValue != Piece.E;
        }

        private void ClaimCell()
        {
            if (IsFirstPlayersTurn())
                _player1.SetPiece(ClaimedCell);
            else
                _player2.SetPiece(ClaimedCell);
        }

        public Piece GetWinner()
        {
            var winner = _grid.GetWinner();
            _score[(int)winner] += 1;
            return winner;
        }

        public int GetScore(Piece playerPiece)
        {
            return _score[(int)_player1.Piece];
        }

        public Piece GetCellValue(int i)
        {
            ConvertIndexToCell(i);
            return ClaimedCell.CurrentValue;
        }

        public void ManuallyPopulateCells(params int[] index)
        {
            foreach (int i in index)
            {
                ConvertIndexToCell(i);
                ClaimCell();
                Turn++;
            }
        }
    }
}
