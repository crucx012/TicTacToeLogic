namespace TicTacToeLogic
{
    public enum Piece { N = 0, O = 1, X = 2 }

    public class Game
    {
        readonly Player _player1 = new Player();
        readonly Player _player2 = new Player();
        readonly Grid _grid;
        readonly Cell[,] _cells;

        private int _row;
        private int _column;
        private int _turn;

        public Game(int side, Piece firstPlayer)
        {
            _cells = new Cell[side,side];
            _grid = new Grid(_cells) {Side = side};

            SetCollectionToValue(side);
            SetPlayerMarkers(firstPlayer);
        }

        private void SetPlayerMarkers(Piece firstPlayer)
        {
            _player1.Piece = firstPlayer;
            _player2.Piece = firstPlayer == Piece.X ? Piece.O : Piece.X;
        }

        private void SetCollectionToValue(int side)
        {
            for (var i = 0; i < side; i++)
                for (var j = 0; j < side; j++)
                    _cells[i, j] = new Cell {CurrentValue = Piece.N};
        }

        public void PlayerTakeTurn(int index)
        {
            ConvertIndexToRowAndColumn(index);

            if (IsCellClaimed()) return;

            if (_turn%2 == 0)
                _player1.Turn(_cells[_row, _column]);
            else
                _player2.Turn(_cells[_row, _column]);
            _turn++;
        }

        private bool IsCellClaimed()
        {
            return _cells[_row, _column].CurrentValue != Piece.N;
        }

        private void ConvertIndexToRowAndColumn(int index)
        {
            _row = 0;

            for (; index > _grid.Side; index -= _grid.Side)
                _row++;

            _column = index - 1;
        }

        public Piece GetWinner()
        {
            return _grid.GetWinner();
        }
    }
}
