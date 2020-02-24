using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardData
{
    class Board
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public void PutPiece(Piece p, Position pos)
        {
            Pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }
    }
}
