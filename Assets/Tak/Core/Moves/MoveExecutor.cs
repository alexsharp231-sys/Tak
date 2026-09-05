using System;

namespace Tak.Core.Moves
{
    public sealed class MoveExecutor
    {
        public void ExecuteValidated(GameState state, Move move)
        {
            if (!(move is PlacementMove placement))
            {
                throw new NotSupportedException("This move type is not implemented yet.");
            }

            ExecutePlacement(state, placement);
            state.PlyCount++;
            state.ActivePlayer = state.ActivePlayer.Opponent();
        }

        private static void ExecutePlacement(GameState state, PlacementMove move)
        {
            var pieceOwner = state.IsOpeningSwap ? state.ActivePlayer.Opponent() : state.ActivePlayer;
            var reserve = state.GetPlayer(pieceOwner);

            if (move.PieceType == PieceType.Capstone)
            {
                reserve.RemoveCapstone();
            }
            else
            {
                reserve.RemoveOrdinaryStone();
            }

            state.Board.GetStack(move.Coordinate).AddTop(new Piece(pieceOwner, move.PieceType));
        }
    }
}
