using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    internal class Display
    {
        public static void PrintTable(Table tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    PrintPiece(tab.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintTable(Table tab, bool[,] paths)
        {
            ConsoleColor original = Console.BackgroundColor;
            ConsoleColor newColor = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (paths[i, j])
                    {
                        Console.BackgroundColor = newColor;
                    }
                    else
                    {
                        Console.BackgroundColor = original;
                    }
                    PrintPiece(tab.GetPiece(i, j));
                    Console.BackgroundColor = original;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = original;

        }

        public static void PrintMatch(ChessMatch match)
        {
            PrintTable(match.tab);
            Console.WriteLine();
            PrintEarnedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.turno);

            if (!match.finished)
            {
                Console.WriteLine("Aguardando jogada: " + match.currentPlayer);

                if (match.xeque)
                {
                    Console.WriteLine("Xeque!");
                }
            }
            else
            {
                Console.WriteLine("XEQUE-MATE");
                Console.WriteLine("Vencedor: " + match.currentPlayer);
            }
            
        }
        public static void PrintEarnedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            PrintGroup(match.EarnedPieces(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(match.EarnedPieces(Cor.Preta));
            Console.ForegroundColor= aux;
            Console.WriteLine();
        }
        public static void PrintGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach(Piece x in group)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static ChessPosition GetChessPosition()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new ChessPosition(coluna, linha);
        }
        public static void PrintPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else{
                if (piece.cor == Cor.Branca)
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
