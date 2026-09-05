namespace Tak.Core.Moves
{
    public sealed class MatchEngine
    {
        private readonly MoveValidator _validator;
        private readonly MoveExecutor _executor;

        public MatchEngine(MoveValidator validator = null, MoveExecutor executor = null)
        {
            _validator = validator ?? new MoveValidator();
            _executor = executor ?? new MoveExecutor();
        }

        public MoveResult TryApply(GameState state, Move move)
        {
            var validation = _validator.Validate(state, move);
            if (!validation.IsValid)
            {
                return new MoveResult(false, validation);
            }

            _executor.ExecuteValidated(state, move);
            return new MoveResult(true, validation);
        }
    }
}
