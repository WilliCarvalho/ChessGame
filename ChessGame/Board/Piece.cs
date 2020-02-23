    using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int QtMovement { get; set; }
        public Board Board { get; set; }

        public Piece(Position position, Board board, Color color)
        {
            Position = position;
            Board = board;
            Color = color;
            QtMovement = 0;
        }



    }
}
