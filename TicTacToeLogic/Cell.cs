namespace TicTacToeLogic
{
    class Cell
    {
        public Piece CurrentValue { get; set; }

        public void SetCellToPlayerMarker(Piece playerPiece)
        {
            CurrentValue = playerPiece;
        }
    }
}
