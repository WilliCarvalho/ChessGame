    using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardData
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMovement { get; protected set; }
        public Board Board { get; protected set; }

        public abstract bool[,] PossibleMoves();

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            QtMovement = 0;
        }

        //Verify if Exists possible moves to the Piece
        public bool ExistPossibleMoves()
        {
            bool [,] mat = PossibleMoves();
            for(int i = 0; i<Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Inform if the piece can move to the destination
        public bool CanMoveTo(Position pos)
        {
            return PossibleMoves()[pos.Row, pos.Column];
        }


        public void IncrementQtMovements()
        {
            QtMovement++;
        }

        public void DecrementQtMovements()
        {
            QtMovement--;
        }

    }
}
