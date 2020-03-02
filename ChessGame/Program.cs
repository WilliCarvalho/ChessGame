using System;
using ChessGame.BoardData;
using ChessGame.ChessData;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                ChessMatch match = new ChessMatch();

                Screen.PrintBoard(match.Board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }            

            Console.ReadLine();
        }
    }
}
