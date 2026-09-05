using System;

namespace Tak.Core
{
    public sealed class BoardState
    {
        private readonly PieceStack[,] _squares;

        public BoardState(int size)
        {
            if (size < 3 || size > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Tak board size must be between 3 and 8.");
            }

            Size = size;
            _squares = new PieceStack[size, size];
            for (var file = 0; file < size; file++)
            {
                for (var rank = 0; rank < size; rank++)
                {
                    _squares[file, rank] = new PieceStack();
                }
            }
        }

        public int Size { get; }

        public bool Contains(BoardCoordinate coordinate)
        {
            return coordinate.File >= 0 && coordinate.File < Size && coordinate.Rank >= 0 && coordinate.Rank < Size;
        }

        public PieceStack GetStack(BoardCoordinate coordinate)
        {
            if (!Contains(coordinate))
            {
                throw new ArgumentOutOfRangeException(nameof(coordinate));
            }

            return _squares[coordinate.File, coordinate.Rank];
        }
    }
}
