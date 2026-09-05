using System;

namespace Tak.Core
{
    public readonly struct Piece : IEquatable<Piece>
    {
        public Piece(PieceOwner owner, PieceType type)
        {
            Owner = owner;
            Type = type;
        }

        public PieceOwner Owner { get; }
        public PieceType Type { get; }

        public bool Equals(Piece other) => Owner == other.Owner && Type == other.Type;
        public override bool Equals(object obj) => obj is Piece other && Equals(other);
        public override int GetHashCode() => ((int)Owner * 397) ^ (int)Type;
        public override string ToString() => $"{Owner}:{Type}";
    }
}
