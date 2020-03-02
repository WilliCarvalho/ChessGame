    using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardData
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMovement { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            QtMovement = 0;
        }

        public void IncrementQtMovements()
        {
            QtMovement++;
        }

    }
}
