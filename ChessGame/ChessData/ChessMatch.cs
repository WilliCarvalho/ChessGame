using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardData;

namespace ChessGame.ChessData
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Board.TakeOutPiece(origin);
            p.IncrementQtMovements();
            Piece capturedPiece = Board.TakeOutPiece(destiny);
            Board.PutPiece(p, destiny);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
        }

        public void PerformMove(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }


        public void ValidateOriginPosition(Position pos)
        {
            if(Board.Piece(pos) == null)
            {
                throw new BoardException("Doesn't have any Piece in this position!");
            }
            else if(CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The piece you choose isn't yours");
            }
            else if (!Board.Piece(pos).ExistPossibleMoves())
            {
                throw new BoardException("Doesn't have any possible moves for this piece");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Destiny position is invalid");
            }
        }

        //Change the color of the pieces you can move
        public void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
            return aux;
        }

        //Add a new piece to the board and to the pieces list
        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(Board, Color.White));
            PutNewPiece('c', 2, new Tower(Board, Color.White));
            PutNewPiece('d', 2, new Tower(Board, Color.White));
            PutNewPiece('e', 2, new Tower(Board, Color.White));
            PutNewPiece('e', 1, new Tower(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));
            
            PutNewPiece('c', 7, new Tower(Board, Color.Black));
            PutNewPiece('c', 8, new Tower(Board, Color.Black));
            PutNewPiece('d', 7, new Tower(Board, Color.Black));
            PutNewPiece('e', 7, new Tower(Board, Color.Black));
            PutNewPiece('e', 8, new Tower(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));            
        }
    }
}
