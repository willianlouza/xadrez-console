using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Pawn : Piece
    {
        public Pawn(Table tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = tab.GetPiece(pos)
;
            return piece == null || piece.cor != this.cor;
        }
        private bool HasEnemy(Position pos)
        {
            Piece p = tab.GetPiece(pos);
            return p != null && p.cor != cor;
        }
        private bool IsEmpty(Position pos)
        {
            return tab.GetPiece(pos) == null;
        }
        public override bool[,] ValidMoves()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Position pos = new Position(0, 0);
            if (cor == Cor.Branca)
            {
                pos.SetValue(position.linha - 1, position.coluna);
                if (tab.ValidPosition(pos) && IsEmpty(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.SetValue(position.linha - 2, position.coluna);
                Position p2 = new Position(position.linha -1, position.coluna);
                if (tab.ValidPosition(p2) && IsEmpty(p2) && tab.ValidPosition(pos) && IsEmpty(pos) && moves == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.SetValue(position.linha - 1, position.coluna - 1);
                if (tab.ValidPosition(pos) && HasEnemy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.SetValue(position.linha - 1, position.coluna + 1);
                if (tab.ValidPosition(pos) && HasEnemy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.SetValue(position.linha + 1, position.coluna);
                if (tab.ValidPosition(pos) && IsEmpty(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.SetValue(position.linha + 2, position.coluna);
                Position p2 = new Position(position.linha + 1, position.coluna);
                if (tab.ValidPosition(p2) && IsEmpty(p2) && tab.ValidPosition(pos) && IsEmpty(pos) && moves == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.SetValue(position.linha + 1, position.coluna - 1);
                if (tab.ValidPosition(pos) && HasEnemy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.SetValue(position.linha + 1, position.coluna + 1);
                if (tab.ValidPosition(pos) && HasEnemy(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            return mat;
        }
    }
}
