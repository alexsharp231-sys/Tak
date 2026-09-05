namespace Tak.Core.Moves
{
    public sealed class MoveValidator
    {
        public MoveValidationResult Validate(GameState state, Move move)
        {
            if (state.Result.IsFinished)
            {
                return MoveValidationResult.Invalid(MoveValidationFailure.GameAlreadyFinished, "The game has already finished.");
            }

            if (move.Player != state.ActivePlayer)
            {
                return MoveValidationResult.Invalid(MoveValidationFailure.WrongPlayer, "The move was not submitted by the active player.");
            }

            if (move is PlacementMove placement)
            {
                return ValidatePlacement(state, placement);
            }

            return MoveValidationResult.Invalid(MoveValidationFailure.UnsupportedMoveType, "This move type is not implemented yet.");
        }

        private static MoveValidationResult ValidatePlacement(GameState state, PlacementMove move)
        {
            if (!state.Board.Contains(move.Coordinate))
            {
                return MoveValidationResult.Invalid(MoveValidationFailure.CoordinateOutOfBounds, "The placement coordinate is outside the board.");
            }

            if (!state.Board.GetStack(move.Coordinate).IsEmpty)
            {
                return MoveValidationResult.Invalid(MoveValidationFailure.OccupiedPlacementSquare, "Pieces may only be placed on an empty square.");
            }

            if (state.IsOpeningSwap && move.PieceType != PieceType.Flat)
            {
                return MoveValidationResult.Invalid(MoveValidationFailure.OpeningPlacementMustBeFlat, "The first two turns must place the opponent's ordinary stone flat.");
            }

            var pieceOwner = state.IsOpeningSwap ? state.ActivePlayer.Opponent() : state.ActivePlayer;
            var reserve = state.GetPlayer(pieceOwner);

            if (move.PieceType == PieceType.Capstone)
            {
                return reserve.CapstonesRemaining > 0
                    ? MoveValidationResult.Valid()
                    : MoveValidationResult.Invalid(MoveValidationFailure.CapstoneReserveExhausted, "No capstones remain in the relevant reserve.");
            }

            return reserve.OrdinaryStonesRemaining > 0
                ? MoveValidationResult.Valid()
                : MoveValidationResult.Invalid(MoveValidationFailure.OrdinaryReserveExhausted, "No ordinary stones remain in the relevant reserve.");
        }
    }
}
