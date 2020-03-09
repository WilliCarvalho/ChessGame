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
        public bool Check { get; private set; }

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

        public Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Board.TakeOutPiece(origin);
            p.IncrementQtMovements();
            Piece capturedPiece = Board.TakeOutPiece(destiny);
            Board.PutPiece(p, destiny);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.TakeOutPiece(destiny);
            p.DecrementQtMovements();
            if(capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.PutPiece(p, origin);
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(origin, destiny); 

            if (IsInCHeck(CurrentPlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in Check!");
            }

            if (IsInCHeck(OponnentColor(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (Checkmate(OponnentColor(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
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
            foreach(Piece x in Pieces)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color OponnentColor(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in InGamePieces(color))
            {
                if(piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCHeck(Color color)
        {
            Piece k = King(color);
            if(k == null)
            {
                throw new BoardException($"The king with the color {color} doesn't exist!");
            }

            foreach (Piece piece in InGamePieces(OponnentColor(color)))
            {
                bool[,] mat = piece.PossibleMoves();
                if(mat[k.Position.Row, k.Position.Column] == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Checkmate (Color color)
        {
            if (!IsInCHeck(color))
            {
                return false;
            }

            foreach (Piece piece in InGamePieces(color))
            {
                bool[,] mat = piece.PossibleMoves();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool testCheck = IsInCHeck(color);
                            UndoMovement(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            PutNewPiece('d', 1, new King(Board, Color.White));
            PutNewPiece('h', 7, new Tower(Board, Color.White));
                     
            PutNewPiece('a', 8, new King(Board, Color.Black));
            PutNewPiece('b', 8, new Tower(Board, Color.Black));               
        }
    }
}
