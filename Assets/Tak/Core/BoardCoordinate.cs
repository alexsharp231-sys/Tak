using System;

namespace Tak.Core
{
    public readonly struct BoardCoordinate : IEquatable<BoardCoordinate>
    {
        public BoardCoordinate(int file, int rank)
        {
            File = file;
            Rank = rank;
        }

        public int File { get; }
        public int Rank { get; }

        public bool Equals(BoardCoordinate other) => File == other.File && Rank == other.Rank;
        public override bool Equals(object obj) => obj is BoardCoordinate other && Equals(other);
        public override int GetHashCode() => (File * 397) ^ Rank;
        public override string ToString() => $"({File},{Rank})";
    }
}
