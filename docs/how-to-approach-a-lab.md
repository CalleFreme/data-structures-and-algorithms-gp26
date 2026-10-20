# When a Lab Feels Overwhelming

You are not expected to understand an unfamiliar project all at once.

## Find only these four things first

1. **The lab README** — what are you actually being asked to do?
2. **The Core project** — where is the behavior/algorithm you will change?
3. **The App** — where can you run a small example?
4. **The Tests** — what behavior is already being checked?

For Lab 1 these are:

```text
labs/01-search-sort-scaling/
├── README.md
├── src/
│   ├── DSA.Lab01.Core/      <- algorithms
│   └── DSA.Lab01.App/       <- runnable examples / timings
└── tests/
    └── DSA.Lab01.Tests/     <- automated tests
```

## Then use this loop

**Read one task → predict → make one small change → build/test → inspect the result.**

Do not try to understand every file before starting.

## When to ask for help

Ask early when the blocker is tooling rather than the course concept.

Examples:

- you cannot find the file being discussed;
- the solution will not open;
- `dotnet` is not available;
- Git will not let you commit/push;
- the project fails before you have changed anything;
- you do not understand what a test failure is telling you.

A useful help request is:

> “I am on Task 2. I expected X. I ran Y. I got Z. I have checked A and B. I do not understand C.”

That gives a classmate or teacher something concrete to investigate with you.

## Git is support infrastructure, not the learning objective

Use Git carefully, but do not spend an hour silently fighting Git during a DSA lab. Run `git status`, read what it says, and ask for help if you are unsure.

## You are allowed to learn from other people

Discussing, tracing, debugging, and explaining with classmates is encouraged. Explaining an idea to someone else is useful practice for both people.

## AI should make the problem smaller, not take ownership of it

Good examples:

- “Explain this failing test without writing the solution.”
- “Ask me questions that help me trace binary search.”
- “Check my reasoning about why this is O(n).”
- “Suggest edge cases, but do not implement them.”

The goal is to leave the lab more able to solve the next problem yourself.
