# Lab 0 — Problem Solving and Course Workflow

## Goal

This lab is intentionally small.

The goal is to establish the workflow we will use throughout the course:

**Understand → Predict → Implement → Test → Inspect → Commit**

You will work with a small collection of players and a few simple lookup/query operations.

## Before coding

Read `Player.cs` and `PlayerCollection.cs`.

Look at `FindById`.

Before running it, answer:

- What is the method doing?
- In the worst case, how many players might it inspect?
- What happens when the ID does not exist?

## Run the baseline

```bash
dotnet restore
dotnet build
dotnet run --project src/DSA.Lab00.App
dotnet test tests/DSA.Lab00.Tests
```

In the **starter version**, the project should build and the app should run. Two tests are expected to fail because two methods are unfinished.

If the project does not build at all, ask for setup help before assuming the TODO code is responsible.

## Tasks

### 1. Inspect `FindById`
Do not change it yet.

Be able to explain how it finds a player.

### 2. Implement `FindHighestScore`
Requirements:
- return the player with the highest score;
- return `null` for an empty collection.

Run the tests after the change.

### 3. Implement `ContainsName`
Requirements:
- return `true` when a player with exactly the supplied name exists;
- use case-sensitive comparison for this lab;
- return `false` otherwise.

Run the tests again.

### 4. Add one meaningful test
Choose an edge case or behavior you think deserves verification.

Examples are intentionally not prescribed. Decide what would increase your confidence in the implementation.

### 5. Commit at a coherent checkpoint
Do not aim for a particular number of commits.

Make a commit when you have reached a meaningful, working stage.

## Checkpoint questions

Write short answers in your own notes or discuss them during the lab.

1. Which of the three operations may need to inspect every player?
2. If the number of players becomes 100 times larger, which operation(s) do you expect to become noticeably more expensive?
3. What information could we organize differently if finding players by ID became extremely common?
4. What edge case did you choose to test, and why?
5. At what point did you make a Git commit? What made that a sensible checkpoint?

## Working together

You are encouraged to discuss predictions, bugs and approaches with classmates.

Pair programming is welcome.

Working independently is equally valid; use the same checkpoints.

## Using the reference implementation

The completed teacher repository contains a reference implementation.

Try the tasks yourself first.

If you use the reference to get unstuck, compare it against your own code and make sure you can explain:
- what changed;
- why it works;
- what condition or assumption the implementation depends on.

The checkpoint-question answers are not supplied as a model answer sheet.
