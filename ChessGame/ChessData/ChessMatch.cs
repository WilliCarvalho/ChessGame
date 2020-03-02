using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardData;

namespace ChessGame.ChessData
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            PutPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Board.TakeOutPiece(origin);
            p.IncrementQtMovements();
            Piece capturedPiece = Board.TakeOutPiece(destiny);
            Board.PutPiece(p, destiny);
        }

        private void PutPieces()
        {
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
