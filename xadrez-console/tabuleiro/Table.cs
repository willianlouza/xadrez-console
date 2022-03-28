using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Table
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Piece[,] pieces;

        public Table(int linha, int colunas)
        {
            this.linhas = linha;
            this.colunas = colunas;
            this.pieces = new Piece[linha, colunas];
        }


        public Piece GetPiece(int lihnha, int coluna)
        {
            return pieces[lihnha, coluna];
        }

        public Piece GetPiece(Position pos)
        {
            return pieces[pos.linha, pos.coluna];
        }
        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos.linha, pos.coluna) != null;
        }
        public void InsertPiece(Piece p, Position pos)
        {
            if (ExistPiece(pos))
            {
                throw new TableException("Já existe uma peça nessa posição!");
            }

            this.pieces[pos.linha, pos.coluna] = p;
            p.position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (GetPiece(pos) == null)
            {
                return null;
            }
            Piece aux = GetPiece(pos);
            aux.position = null;
            pieces[pos.linha, pos.coluna] = null;
            return aux;
        }
        public bool ValidPosition(Position pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new TableException("Posição inválida!");
            }
        }
    }
}
