using System;
using tabuleiro;

namespace xadrez
{
    internal class ChessPosition
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public ChessPosition(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Position ToPosition()
        {
            return new Position(8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
