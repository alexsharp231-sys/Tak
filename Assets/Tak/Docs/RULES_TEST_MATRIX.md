# Rules Test Matrix

| Rule area | Coverage | Automated evidence |
| --- | --- | --- |
| Board sizes 3x3–8x8 | Covered | `NewGame_UsesAuthoritativeReserves` |
| Opening turn 1 uses opponent flat | Covered | `FirstOpeningTurn_PlacesPlayer2FlatAndConsumesPlayer2Reserve` |
| Opening turn 2 uses opponent flat | Covered | `SecondOpeningTurn_PlacesPlayer1FlatThenReturnsTurnToPlayer1` |
| Opening forbids wall/capstone | Covered | `OpeningTurn_RejectsNonFlatPlacement` |
| Normal standing placement | Covered | `NormalTurn_AllowsStandingStoneAndConsumesOrdinaryReserve` |
| Normal capstone placement | Covered | `NormalTurn_AllowsCapstoneAndConsumesCapstoneReserve` |
| Placement requires empty square | Covered | `Placement_RejectsOccupiedSquareWithoutMutatingState` |
| Wrong player rejected | Covered | `Placement_RejectsWrongPlayer` |
| Reserve exhausted placement | Pending | Add targeted tests when test-state construction helpers exist |
| Stack ownership/carry/direction/drop rules | Pending | Next rules slice |
| Wall/capstone obstacles and crush | Pending | Next rules slice |
| Road victory and simultaneous roads | Pending | Later Phase 1 slice |
| Flat victory and road priority | Pending | Later Phase 1 slice |
| Legal move generation | Pending | Later Phase 1 slice |
| Perft | Pending | Later Phase 1 slice |
