namespace Tak.Core
{
    public sealed class GameState
    {
        public GameState(int boardSize)
        {
            Board = new BoardState(boardSize);
            var reserve = TakRulesConfig.GetInitialReserve(boardSize);
            Player1 = new PlayerState(PieceOwner.Player1, reserve);
            Player2 = new PlayerState(PieceOwner.Player2, reserve);
            ActivePlayer = PieceOwner.Player1;
            Result = GameResult.Ongoing;
        }

        public BoardState Board { get; }
        public PlayerState Player1 { get; }
        public PlayerState Player2 { get; }
        public PieceOwner ActivePlayer { get; internal set; }
        public int PlyCount { get; internal set; }
        public GameResult Result { get; internal set; }
        public bool IsOpeningSwap => PlyCount < 2;

        public PlayerState GetPlayer(PieceOwner owner)
        {
            return owner == PieceOwner.Player1 ? Player1 : Player2;
        }
    }
}
