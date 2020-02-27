using System;
using ChessGame.BoardData;
using ChessGame.ChessData;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition chess = new ChessPosition('c', 7);

            Console.WriteLine(chess);
            Console.WriteLine(chess.ToPosition());

            Console.ReadLine();
        }
    }
}
