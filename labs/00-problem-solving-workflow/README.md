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

## Optional Extensions — If You Finish Lab 0 Early

These extensions are **not required** and are not graded.

Do them if you finish the core Lab 0 tasks and want to investigate further before Thursday. They are designed to reinforce the course workflow and prepare you for our next topic without requiring you to start Lab 1 early.

You do not need to complete every extension. Choose one or more that seem useful.

### Extension A — Watch `FindById` with the debugger

Set a breakpoint inside `FindById`.

Run or debug several searches:

- a player near the beginning of the list;
- a player near the end;
- an ID that does not exist.

Step through the loop and observe what changes.

Think about:

- How many players are inspected in each case?
- What determines when the method stops?
- Which case makes the method do the most work?

### Extension B — Count the work

Temporarily add a counter to `FindById` so you can see how many players it inspects.

Try searches for:

- the first player;
- a middle player;
- the last player;
- a missing ID.

Record the counts.

Then add or generate more players and repeat.

For example, compare lists containing approximately:

- 10 players;
- 100 players;
- 1,000 players.

Before running each case, **predict** what you think will happen.

Do not worry about Big-O notation yet. We will connect these observations to algorithmic complexity on Thursday.

### Extension C — Add another meaningful test

Add one or two tests that are not already present.

Choose the test because it increases your confidence in the behavior, not because you want a larger test count.

Possible areas to think about:

- empty collections;
- duplicate scores;
- exact name matching;
- IDs that do not exist;
- another edge case you can justify.

Be prepared to explain:

> What failure would this test catch?

### Extension D — Practice a small Git branch

Only do this if the required Lab 0 work is already committed.

Create a short-lived branch for an experiment:

```bash
git switch -c experiment/lab0-extension
```

Make one small extension, build/test it, and commit it.

Then return to `main`:

```bash
git switch main
```

If you want to keep the experiment:

```bash
git merge experiment/lab0-extension
```

If you do not want to keep it, you can simply leave the branch unmerged for now and ask if you are unsure how to remove it safely.

The purpose is to see a branch as a **separate line of commits**, not as something every tiny task must use.

### Extension E — Inspect how the teacher repository was built

Open the course repository on GitHub and inspect its first commits.

Look for the progression from:

1. repository/toolchain;
2. core model/logic;
3. runnable application;
4. automated tests;
5. lab instructions;
6. student starter package.

Think about:

- Why might these have been separate commits?
- Which commits represent useful working checkpoints?
- How does the history make the development process easier to understand?

### When you are done

You do **not** need to start Lab 1 before Thursday.

Instead, make sure that:

- your required Lab 0 work is complete;
- your tests are in a state you understand;
- your work is committed and pushed to GitHub;
- you have answered the Lab 0 checkpoint questions;
- you complete the short Thursday preparation before class.
