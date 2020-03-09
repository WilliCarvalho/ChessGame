using System;
using ChessGame.BoardData;
using ChessGame.ChessData;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessMatch match = new ChessMatch();

            while (!match.Finished)
            {
                try
                {

                    Console.Clear();
                    Screen.PrintMatch(match);
                    Screen.PrintCapturedPieces(match);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    match.ValidateOriginPosition(origin);

                    bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();
                    match.ValidateDestinyPosition(origin, destiny);

                    match.PerformMove(origin, destiny);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Screen.PrintBoard(match.Board);



            Console.ReadLine();
        }
    }
}
