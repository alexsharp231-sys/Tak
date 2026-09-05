using System;

namespace Tak.Core
{
    public sealed class PlayerState
    {
        internal PlayerState(PieceOwner owner, ReserveCounts reserve)
        {
            Owner = owner;
            OrdinaryStonesRemaining = reserve.OrdinaryStones;
            CapstonesRemaining = reserve.Capstones;
        }

        public PieceOwner Owner { get; }
        public int OrdinaryStonesRemaining { get; private set; }
        public int CapstonesRemaining { get; private set; }
        public bool HasCompletePlayableReserve => OrdinaryStonesRemaining > 0 || CapstonesRemaining > 0;

        internal void RemoveOrdinaryStone()
        {
            if (OrdinaryStonesRemaining <= 0)
            {
                throw new InvalidOperationException("No ordinary stones remain.");
            }

            OrdinaryStonesRemaining--;
        }

        internal void RemoveCapstone()
        {
            if (CapstonesRemaining <= 0)
            {
                throw new InvalidOperationException("No capstones remain.");
            }

            CapstonesRemaining--;
        }
    }
}
