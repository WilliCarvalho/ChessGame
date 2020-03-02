﻿using System;
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

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    Console.WriteLine();

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMovement(origin, destiny);
                }
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
