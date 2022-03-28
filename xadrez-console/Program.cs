
using tabuleiro;

using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();


                while (!match.finished)
                {
                    try
                    {
                        Console.Clear(); 
                        Display.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Display.GetChessPosition().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] paths = match.tab.GetPiece(origin).ValidMoves();

                        Console.Clear();
                        Display.PrintTable(match.tab, paths);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Display.GetChessPosition().ToPosition();
                        match.ValidateDestinyPosition(origin, destiny);

                        match.MakePlay(origin, destiny);
                    }
                    catch (TableException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }



            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
            }




            Console.ReadLine();
        }
    }
}