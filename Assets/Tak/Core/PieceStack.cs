using System;
using System.Collections.Generic;

namespace Tak.Core
{
    /// <summary>
    /// Stores pieces in bottom-to-top order. Index 0 is the bottom piece; Count - 1 is the top.
    /// </summary>
    public sealed class PieceStack
    {
        private readonly List<Piece> _pieces = new List<Piece>();

        public int Count => _pieces.Count;
        public bool IsEmpty => _pieces.Count == 0;
        public IReadOnlyList<Piece> Pieces => _pieces;
        public Piece Top => !IsEmpty ? _pieces[_pieces.Count - 1] : throw new InvalidOperationException("The stack is empty.");

        internal void AddTop(Piece piece) => _pieces.Add(piece);
    }
}
