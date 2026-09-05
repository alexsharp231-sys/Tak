# Tak Architecture

## Current layer boundary

`Tak.Core` is a plain C# assembly with no UnityEngine reference. It is the sole authority for board contents, reserves, turn state and rules validation.

Presentation, input, UI, AI, notation and networking layers will consume immutable move descriptions and read logical state; they must never infer rules from GameObjects or transforms.

## Stack convention

All logical stacks are stored **bottom to top**. Index `0` is the bottom piece and index `Count - 1` is the top piece. This convention must remain consistent in rules, notation, replay, AI and persistence.

## Move pipeline

The current pipeline is:

1. Construct a `Move` data object.
2. `MoveValidator` checks authoritative legality and returns a structured `MoveValidationResult`.
3. `MoveExecutor` mutates logical state only after validation succeeds.
4. `MatchEngine` centralises validation + execution.

Only placement moves are implemented in the first slice. Stack movement, victory evaluation, history and notation will extend this pipeline rather than bypass it.

## Opening model

`Player1` denotes the player who acts first in the current game. The caller is responsible for assigning real participants to Player1/Player2 according to random-first-game / alternating-subsequent-game policy. Core opening turns then deterministically implement the swap:

- ply 0: Player1 places a Player2 ordinary flat;
- ply 1: Player2 places a Player1 ordinary flat;
- ply 2+: normal play, beginning with Player1.
