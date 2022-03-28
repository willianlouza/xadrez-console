using System;

namespace tabuleiro
{
    internal class TableException : Exception
    {
        public TableException(string msg) : base(msg) { }
    }
}
