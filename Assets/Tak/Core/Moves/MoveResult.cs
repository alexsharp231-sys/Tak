namespace Tak.Core.Moves
{
    public readonly struct MoveResult
    {
        public MoveResult(bool applied, MoveValidationResult validation)
        {
            Applied = applied;
            Validation = validation;
        }

        public bool Applied { get; }
        public MoveValidationResult Validation { get; }
    }
}
