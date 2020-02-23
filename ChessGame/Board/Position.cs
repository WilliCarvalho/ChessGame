using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Board
{
    class Position
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public Position(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}
