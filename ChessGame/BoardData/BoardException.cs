using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.BoardData
{
    class BoardException : Exception 
    {
        public BoardException (string message) : base(message)
        {
        }
    }
}
