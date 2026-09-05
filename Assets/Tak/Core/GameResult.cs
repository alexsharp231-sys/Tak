namespace Tak.Core
{
    public enum GameResultType
    {
        Ongoing = 0,
        RoadWin = 1,
        FlatWin = 2,
        Draw = 3
    }

    public readonly struct GameResult
    {
        public GameResult(GameResultType type, PieceOwner? winner = null)
        {
            Type = type;
            Winner = winner;
        }

        public GameResultType Type { get; }
        public PieceOwner? Winner { get; }
        public bool IsFinished => Type != GameResultType.Ongoing;

        public static GameResult Ongoing => new GameResult(GameResultType.Ongoing);
    }
}
