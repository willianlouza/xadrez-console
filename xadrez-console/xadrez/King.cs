using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class King : Piece
    {
        public King(Table tab, Cor cor) : base(tab,cor)
        {
            
        }

        public override string ToString()
        {
            return "K";
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

            //North
            pos.SetValue(position.linha - 1, position.coluna);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //North East
            pos.SetValue(position.linha - 1, position.coluna + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //East
            pos.SetValue(position.linha, position.coluna + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //South East
            pos.SetValue(position.linha + 1, position.coluna + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //South
            pos.SetValue(position.linha + 1, position.coluna);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //South West
            pos.SetValue(position.linha + 1, position.coluna - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //West
            pos.SetValue(position.linha, position.coluna - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //North West
            pos.SetValue(position.linha - 1, position.coluna - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
