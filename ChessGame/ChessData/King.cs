using System;
using System.Collections.Generic;
using System.Text;
using ChessGame.BoardData;

namespace ChessGame.ChessData
{
    class King : Piece
    {

        public King(Board board, Color color) : base(board, color)
        {
        }
        
        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Verify top
            pos.SetValues(Position.Row - 1, Position.Column);
            if(Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Verify top-right
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Verify right
            pos.SetValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Verify down-right
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Verify down
            pos.SetValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Verify down-left
            pos.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Verify left
            pos.SetValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Verify top-left
            pos.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos) == true)
            {
                mat[pos.Row, pos.Column] = true;
            }
            return mat;
        }
    }
}
