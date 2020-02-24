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
    }
}
