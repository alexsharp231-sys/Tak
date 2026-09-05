namespace Tak.Core.Moves
{
    public abstract class Move
    {
        protected Move(PieceOwner player)
        {
            Player = player;
        }

        public PieceOwner Player { get; }
    }
}
