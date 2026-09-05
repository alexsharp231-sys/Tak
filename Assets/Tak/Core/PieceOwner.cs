namespace Tak.Core
{
    public enum PieceOwner
    {
        Player1 = 1,
        Player2 = 2
    }

    public static class PieceOwnerExtensions
    {
        public static PieceOwner Opponent(this PieceOwner owner)
        {
            return owner == PieceOwner.Player1 ? PieceOwner.Player2 : PieceOwner.Player1;
        }
    }
}
