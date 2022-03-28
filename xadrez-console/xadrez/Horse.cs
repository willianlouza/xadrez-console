using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Horse : Piece
    {
        public Horse(Table tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "H";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = tab.GetPiece(pos)
;
            return piece == null || piece.cor != this.cor;
        }
        public override bool[,] ValidMoves()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            pos.SetValue(position.linha - 1, position.coluna - 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha - 2, position.coluna - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha - 2, position.coluna + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha - 1, position.coluna + 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha + 1, position.coluna +2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha + 1, position.coluna - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha + 2, position.coluna + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha + 2, position.coluna - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.SetValue(position.linha + 1, position.coluna - 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
