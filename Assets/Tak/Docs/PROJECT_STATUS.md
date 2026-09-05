# Project Status

## Current milestone

Phase 1 — Rules Engine.

## Completed

- Repository foundation established.
- Plain-C# `Tak.Core` assembly with no UnityEngine dependency.
- Configurable boards for 3x3 through 8x8.
- Authoritative reserve counts for all supported sizes.
- Bottom-to-top stack convention documented and implemented.
- Core piece, board, player, game-state and result types.
- Immutable placement move descriptions.
- Structured move validation results.
- Authoritative first-two-turn opening swap placement logic.
- Normal flat, standing and capstone placement validation/execution.
- EditMode tests covering reserves, opening ownership/reserve use, turn order, illegal opening pieces, occupied placement and wrong-player rejection.

## Known limitations

- Stack movement/spreads and crushing are not implemented yet.
- Road and flat victory evaluation are not implemented yet.
- Legal move generation/perft are not implemented yet.
- Move/position history, undo/redo, PTN and TPS are not implemented yet.
- Unity scene/presentation/input/UI are intentionally not started before core rules mature.
- Unity Editor tests have not yet been executed in CI; the repository does not yet include an automated Unity test workflow.

## Next priority

Implement stack movement as a complete rules slice: direction/carry/drop data, exhaustive validation, execution preserving piece order, wall/capstone obstacles, legal wall crushing, and regression tests.
