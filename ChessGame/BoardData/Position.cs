using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardData
{
    class Position
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public Position(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public void SetValues(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Column}, {Row}";
        }
    }
}
