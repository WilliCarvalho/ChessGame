using System;
using System.Collections.Generic;
using ChessGame.BoardData;
using ChessGame.ChessData;

namespace ChessGame
{
    class Screen
    {
        public static void PrintMatch (ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            Console.WriteLine("Waiting move of: " + match.CurrentPlayer);
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintHashSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintHashSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintHashSet(HashSet<Piece> hashSet)
        {
            Console.Write("[");
            foreach (Piece piece in hashSet)
            {
                Console.Write(piece + " ");
            }
            Console.WriteLine("]");
        }

        public static void PrintBoard(Board board)
        {
            for(int i = 0; i<board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j<board.Columns; j++)
                {                   
                    PrintPiece(board.Piece(i, j));                  
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char columm = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(columm, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }            
        }
    }
}
