namespace Tak.Core.Moves
{
    public sealed class PlacementMove : Move
    {
        public PlacementMove(PieceOwner player, BoardCoordinate coordinate, PieceType pieceType)
            : base(player)
        {
            Coordinate = coordinate;
            PieceType = pieceType;
        }

        public BoardCoordinate Coordinate { get; }
        public PieceType PieceType { get; }
    }
}
