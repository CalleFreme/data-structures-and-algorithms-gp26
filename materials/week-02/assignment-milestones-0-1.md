# Individual Assignment - Milestones 0 and 1

These are progress targets, not separate graded submissions.

## Milestone 0 - Establish the baseline

Before redesigning or optimizing anything:

- create/clone your individual assignment repository;
- get the supplied baseline locally;
- build the standalone .NET solution **or** open the Unity project and verify the headless core;
- run the supplied tests and record the expected baseline result;
- run the supplied baseline workload/demo;
- read the root README and assignment specification;
- make a baseline commit and push it.

A perfectly good first assignment session can end here.

## Milestone 1 - Understand before changing

Inspect the current world representation and answer in `REPORT.md`:

1. How are locations stored?
2. How are connections stored?
3. How does the baseline find a location by ID?
4. How does it find outgoing connections?
5. Which operations do you expect to happen frequently?
6. Which operation(s) do you predict may scale poorly?
7. What do you want to investigate first?

Do not optimize simply because something "looks slow". First identify the operation and make a prediction you can later test.

## Unity is optional for assessed work

The assignment starter is based on the shared **Frontier Dispatch** Unity laboratory, but the assessed systems live in a headless pure-C# assembly. The same source is also compiled by a standalone .NET solution.

You may use the Unity visualization if it helps you understand or demonstrate your system, but engine-dependent work is **not required** to achieve G or VG.
