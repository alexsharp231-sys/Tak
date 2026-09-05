using NUnit.Framework;
using Tak.Core;
using Tak.Core.Moves;

namespace Tak.Tests
{
    public sealed class OpeningAndPlacementTests
    {
        [TestCase(3, 10, 0)]
        [TestCase(4, 15, 0)]
        [TestCase(5, 21, 1)]
        [TestCase(6, 30, 1)]
        [TestCase(7, 40, 2)]
        [TestCase(8, 50, 2)]
        public void NewGame_UsesAuthoritativeReserves(int size, int ordinary, int caps)
        {
            var state = new GameState(size);

            Assert.That(state.Player1.OrdinaryStonesRemaining, Is.EqualTo(ordinary));
            Assert.That(state.Player1.CapstonesRemaining, Is.EqualTo(caps));
            Assert.That(state.Player2.OrdinaryStonesRemaining, Is.EqualTo(ordinary));
            Assert.That(state.Player2.CapstonesRemaining, Is.EqualTo(caps));
        }

        [Test]
        public void FirstOpeningTurn_PlacesPlayer2FlatAndConsumesPlayer2Reserve()
        {
            var state = new GameState(5);
            var engine = new MatchEngine();
            var target = new BoardCoordinate(0, 0);

            var result = engine.TryApply(state, new PlacementMove(PieceOwner.Player1, target, PieceType.Flat));

            Assert.That(result.Applied, Is.True);
            Assert.That(state.Board.GetStack(target).Top, Is.EqualTo(new Piece(PieceOwner.Player2, PieceType.Flat)));
            Assert.That(state.Player2.OrdinaryStonesRemaining, Is.EqualTo(20));
            Assert.That(state.Player1.OrdinaryStonesRemaining, Is.EqualTo(21));
            Assert.That(state.ActivePlayer, Is.EqualTo(PieceOwner.Player2));
            Assert.That(state.IsOpeningSwap, Is.True);
        }

        [Test]
        public void SecondOpeningTurn_PlacesPlayer1FlatThenReturnsTurnToPlayer1()
        {
            var state = new GameState(5);
            var engine = new MatchEngine();
            engine.TryApply(state, new PlacementMove(PieceOwner.Player1, new BoardCoordinate(0, 0), PieceType.Flat));

            var result = engine.TryApply(state, new PlacementMove(PieceOwner.Player2, new BoardCoordinate(1, 0), PieceType.Flat));

            Assert.That(result.Applied, Is.True);
            Assert.That(state.Board.GetStack(new BoardCoordinate(1, 0)).Top, Is.EqualTo(new Piece(PieceOwner.Player1, PieceType.Flat)));
            Assert.That(state.Player1.OrdinaryStonesRemaining, Is.EqualTo(20));
            Assert.That(state.ActivePlayer, Is.EqualTo(PieceOwner.Player1));
            Assert.That(state.IsOpeningSwap, Is.False);
        }

        [TestCase(PieceType.Standing)]
        [TestCase(PieceType.Capstone)]
        public void OpeningTurn_RejectsNonFlatPlacement(PieceType type)
        {
            var state = new GameState(5);
            var result = new MatchEngine().TryApply(state, new PlacementMove(PieceOwner.Player1, new BoardCoordinate(0, 0), type));

            Assert.That(result.Applied, Is.False);
            Assert.That(result.Validation.Failure, Is.EqualTo(MoveValidationFailure.OpeningPlacementMustBeFlat));
        }

        [Test]
        public void NormalTurn_AllowsStandingStoneAndConsumesOrdinaryReserve()
        {
            var state = AfterOpening();
            var target = new BoardCoordinate(2, 2);

            var result = new MatchEngine().TryApply(state, new PlacementMove(PieceOwner.Player1, target, PieceType.Standing));

            Assert.That(result.Applied, Is.True);
            Assert.That(state.Board.GetStack(target).Top, Is.EqualTo(new Piece(PieceOwner.Player1, PieceType.Standing)));
            Assert.That(state.Player1.OrdinaryStonesRemaining, Is.EqualTo(19));
        }

        [Test]
        public void NormalTurn_AllowsCapstoneAndConsumesCapstoneReserve()
        {
            var state = AfterOpening();
            var target = new BoardCoordinate(2, 2);

            var result = new MatchEngine().TryApply(state, new PlacementMove(PieceOwner.Player1, target, PieceType.Capstone));

            Assert.That(result.Applied, Is.True);
            Assert.That(state.Board.GetStack(target).Top, Is.EqualTo(new Piece(PieceOwner.Player1, PieceType.Capstone)));
            Assert.That(state.Player1.CapstonesRemaining, Is.EqualTo(0));
        }

        [Test]
        public void Placement_RejectsOccupiedSquareWithoutMutatingState()
        {
            var state = AfterOpening();
            var target = new BoardCoordinate(0, 0);
            var beforeReserve = state.Player1.OrdinaryStonesRemaining;

            var result = new MatchEngine().TryApply(state, new PlacementMove(PieceOwner.Player1, target, PieceType.Flat));

            Assert.That(result.Applied, Is.False);
            Assert.That(result.Validation.Failure, Is.EqualTo(MoveValidationFailure.OccupiedPlacementSquare));
            Assert.That(state.Player1.OrdinaryStonesRemaining, Is.EqualTo(beforeReserve));
            Assert.That(state.ActivePlayer, Is.EqualTo(PieceOwner.Player1));
        }

        [Test]
        public void Placement_RejectsWrongPlayer()
        {
            var state = new GameState(5);
            var result = new MatchEngine().TryApply(state, new PlacementMove(PieceOwner.Player2, new BoardCoordinate(0, 0), PieceType.Flat));

            Assert.That(result.Applied, Is.False);
            Assert.That(result.Validation.Failure, Is.EqualTo(MoveValidationFailure.WrongPlayer));
        }

        private static GameState AfterOpening()
        {
            var state = new GameState(5);
            var engine = new MatchEngine();
            Assert.That(engine.TryApply(state, new PlacementMove(PieceOwner.Player1, new BoardCoordinate(0, 0), PieceType.Flat)).Applied, Is.True);
            Assert.That(engine.TryApply(state, new PlacementMove(PieceOwner.Player2, new BoardCoordinate(1, 0), PieceType.Flat)).Applied, Is.True);
            return state;
        }
    }
}
