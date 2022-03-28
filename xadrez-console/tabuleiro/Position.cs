using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Position
    {
        public int linha { get; set; }
        public int coluna { get; set; }


        public Position(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString()
        {
            return $"[{linha}, {coluna}]";
        }

        public void SetValue(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
    }
}
