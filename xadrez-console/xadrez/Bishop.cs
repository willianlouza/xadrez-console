using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Bishop : Piece
    {
        public Bishop(Table tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "B";
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


            //North West
            pos.SetValue(position.linha - 1, position.coluna -1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.SetValue(pos.linha -1, pos.coluna -1);
            }
            //Noth East
            pos.SetValue(position.linha - 1, position.coluna + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.SetValue(pos.linha - 1, pos.coluna + 1);
            }
            //South East
            pos.SetValue(position.linha + 1, position.coluna + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.SetValue(pos.linha + 1, pos.coluna + 1);
            }
            //South West
            pos.SetValue(position.linha + 1, position.coluna - 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.GetPiece(pos) != null && tab.GetPiece(pos).cor != this.cor)
                {
                    break;
                }
                pos.SetValue(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}
