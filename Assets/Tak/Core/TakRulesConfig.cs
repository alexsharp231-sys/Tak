using System;

namespace Tak.Core
{
    public readonly struct ReserveCounts
    {
        public ReserveCounts(int ordinaryStones, int capstones)
        {
            OrdinaryStones = ordinaryStones;
            Capstones = capstones;
        }

        public int OrdinaryStones { get; }
        public int Capstones { get; }
    }

    public static class TakRulesConfig
    {
        public static ReserveCounts GetInitialReserve(int boardSize)
        {
            switch (boardSize)
            {
                case 3: return new ReserveCounts(10, 0);
                case 4: return new ReserveCounts(15, 0);
                case 5: return new ReserveCounts(21, 1);
                case 6: return new ReserveCounts(30, 1);
                case 7: return new ReserveCounts(40, 2);
                case 8: return new ReserveCounts(50, 2);
                default: throw new ArgumentOutOfRangeException(nameof(boardSize), "Tak board size must be between 3 and 8.");
            }
        }
    }
}
