using System;
using ChessGame.BoardData;
using ChessGame.ChessData;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.PutPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.PutPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);

            Console.ReadLine();
        }
    }
}
