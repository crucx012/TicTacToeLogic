namespace TicTacToeLogic
{
    class Player
    {
        public Piece Piece { get; set; }

        public void Turn(Cell c)
        {
            c.SetCellToPlayerMarker(Piece);
        }
    }
}
