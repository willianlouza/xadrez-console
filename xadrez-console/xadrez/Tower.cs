using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Tower : Piece
    {
        public Tower(Table tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
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
            while(tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }
            //South
            pos.SetValue(position.linha + 1, position.coluna);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }
            //East
            pos.SetValue(position.linha, position.coluna + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }
            //West
            pos.SetValue(position.linha, position.coluna - 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }
    }
}
