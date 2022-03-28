using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal abstract class Piece
    {
        public Position position { get; set; }
        public Cor cor { get; protected set; }
        public int moves { get; protected set; }
        public Table tab { get; protected set; }

        public Piece(Table tab, Cor cor)
        {
            this.position = null;
            this.tab = tab;
            this.cor = cor;
            this.moves = 0;
        }
        
        public void AddMove()
        {
            this.moves++;
        }

        public void RemoveMove()
        {
            this.moves--;
        }
        public bool HasValidMoves()
        {
            bool[,] mat = ValidMoves();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        Console.WriteLine(mat[i, j]);
                        return true;
                    }
                }
            }

            Console.WriteLine(mat.ToString());
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return ValidMoves()[pos.linha, pos.coluna];
        }
        public abstract bool[,] ValidMoves();

    }
}
