namespace Tak.Core.Moves
{
    public enum MoveValidationFailure
    {
        None = 0,
        GameAlreadyFinished,
        WrongPlayer,
        UnsupportedMoveType,
        CoordinateOutOfBounds,
        OccupiedPlacementSquare,
        OpeningPlacementMustBeFlat,
        OrdinaryReserveExhausted,
        CapstoneReserveExhausted
    }

    public readonly struct MoveValidationResult
    {
        private MoveValidationResult(bool isValid, MoveValidationFailure failure, string description)
        {
            IsValid = isValid;
            Failure = failure;
            Description = description;
        }

        public bool IsValid { get; }
        public MoveValidationFailure Failure { get; }
        public string Description { get; }

        public static MoveValidationResult Valid() => new MoveValidationResult(true, MoveValidationFailure.None, null);
        public static MoveValidationResult Invalid(MoveValidationFailure failure, string description) => new MoveValidationResult(false, failure, description);
    }
}
