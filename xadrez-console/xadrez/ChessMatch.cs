using System;
using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    internal class ChessMatch
    {
        public Table tab { get; private set; }
        public int turno { get; private set; }
        public Cor currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces = new HashSet<Piece>();
        private HashSet<Piece> earnedPieces = new HashSet<Piece>();
        public bool xeque { get; private set; }
        public ChessMatch()
        {
            tab = new Table(8, 8);
            turno = 1;
            currentPlayer = Cor.Branca;
            this.xeque = false;
            InsertPieces();
        }
        public Piece MakeMove(Position origin, Position destiny)
        {
            Piece p = tab.RemovePiece(origin);
            p.AddMove();
            Piece removida = tab.RemovePiece(destiny);
            tab.InsertPiece(p, destiny);
            if (removida != null)
            {
                earnedPieces.Add(removida);
            }

            return removida;
        }
        public void UnMove(Position origin, Position destiny, Piece removed)
        {
            Piece p = tab.RemovePiece(destiny);
            p.RemoveMove();
            if(removed != null)
            {
                tab.InsertPiece(removed, destiny);
                earnedPieces.Remove(removed);
            }
            tab.InsertPiece(p, origin);
        }
        public void MakePlay(Position origin, Position destiny)
        {
            Piece removida = MakeMove(origin, destiny);
            if (IsInCheck(currentPlayer))
            {
                UnMove(origin, destiny, removida);
                throw new TableException("Você não pode se colocar em xeque!");
            }

            if (IsInCheck(Adversaria(currentPlayer)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (TestCheck(Adversaria(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turno++;
                ChangePlayer();
            }
        }
        private void ChangePlayer()
        {
            if (currentPlayer == Cor.Branca)
            {
                currentPlayer = Cor.Preta;
            }
            else
            {
                currentPlayer = Cor.Branca;
            }
        }
        public HashSet<Piece> EarnedPieces(Cor cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in earnedPieces)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }
        public HashSet<Piece> InGamePieces(Cor cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(EarnedPieces(cor));
            return aux;
        }
        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Piece King(Cor cor)
        {
            foreach(Piece x in InGamePieces(cor))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public bool IsInCheck(Cor cor)
        {
            Piece r = King(cor);
            if(r == null)
            {
                throw new TableException("Não existe rei da cor " + cor);
            }
            foreach(Piece x in InGamePieces(Adversaria(cor)))
            {
                bool[,] mat = x.ValidMoves();

                if(mat[r.position.linha, r.position.coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool TestCheck(Cor cor)
        {
            if (!IsInCheck(cor))
            {
                return false;
            }

            foreach(Piece x in InGamePieces(cor))
            {
                bool[,] mat = x.ValidMoves();

                for(int i = 0; i < tab.linhas; i++)
                {
                    for(int j = 0; j < tab.colunas; j++)
                    {
                        if(mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece removed = MakeMove(origin, destiny);
                            bool testCheck = IsInCheck(cor);
                            UnMove(origin, destiny, removed);
                            if (!testCheck)
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }
        public void ValidateOriginPosition(Position pos)
        {
            if (tab.GetPiece(pos) == null)
            {
                throw new TableException("Não existe peça!");
            }
            if (currentPlayer != tab.GetPiece(pos).cor)
            {
                throw new TableException("Peça não é sua!");
            }
            if (!tab.GetPiece(pos).HasValidMoves())
            {
                throw new TableException("Não há movimentos para essa peça!");
            }
        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!tab.GetPiece(origin).CanMoveTo(destiny))
            {
                throw new TableException("Posição de destino inválida!");
            }
        }
        private void InsertNewPiece(char coluna, int linha, Piece piece)
        {
            tab.InsertPiece(piece, new ChessPosition(coluna, linha).ToPosition());
            pieces.Add(piece);
        }
        private void InsertPieces()
        {
            InsertNewPiece('a', 1, new Tower(tab, Cor.Branca));
            InsertNewPiece('b', 1, new Horse(tab, Cor.Branca));
            InsertNewPiece('c', 1, new Bishop(tab, Cor.Branca));
            InsertNewPiece('d', 1, new Queen(tab, Cor.Branca));
            InsertNewPiece('e', 1, new King(tab, Cor.Branca));
            InsertNewPiece('f', 1, new Bishop(tab, Cor.Branca));
            InsertNewPiece('g', 1, new Horse(tab, Cor.Branca));
            InsertNewPiece('h', 1, new Tower(tab, Cor.Branca));
            InsertNewPiece('a', 2, new Pawn(tab, Cor.Branca));
            InsertNewPiece('b', 2, new Pawn(tab, Cor.Branca));
            InsertNewPiece('c', 2, new Pawn(tab, Cor.Branca));
            InsertNewPiece('d', 2, new Pawn(tab, Cor.Branca));
            InsertNewPiece('e', 2, new Pawn(tab, Cor.Branca));
            InsertNewPiece('f', 2, new Pawn(tab, Cor.Branca));
            InsertNewPiece('g', 2, new Pawn(tab, Cor.Branca));
            InsertNewPiece('h', 2, new Pawn(tab, Cor.Branca));

            InsertNewPiece('a', 8, new Tower(tab, Cor.Preta));
            InsertNewPiece('b', 8, new Horse(tab, Cor.Preta));
            InsertNewPiece('c', 8, new Bishop(tab, Cor.Preta));
            InsertNewPiece('d', 8, new Queen(tab, Cor.Preta));
            InsertNewPiece('e', 8, new King(tab, Cor.Preta));
            InsertNewPiece('f', 8, new Bishop(tab, Cor.Preta));
            InsertNewPiece('g', 8, new Horse(tab, Cor.Preta));
            InsertNewPiece('h', 8, new Tower(tab, Cor.Preta));
            InsertNewPiece('a', 7, new Pawn(tab, Cor.Preta));
            InsertNewPiece('b', 7, new Pawn(tab, Cor.Preta));
            InsertNewPiece('c', 7, new Pawn(tab, Cor.Preta));
            InsertNewPiece('d', 7, new Pawn(tab, Cor.Preta));
            InsertNewPiece('e', 7, new Pawn(tab, Cor.Preta));
            InsertNewPiece('f', 7, new Pawn(tab, Cor.Preta));
            InsertNewPiece('g', 7, new Pawn(tab, Cor.Preta));
            InsertNewPiece('h', 7, new Pawn(tab, Cor.Preta));



        }
    }
}
