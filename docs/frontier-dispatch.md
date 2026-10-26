# Frontier Dispatch — Unity Laboratory

**Frontier Dispatch** is the shared Unity laboratory used throughout the Data Structures and Algorithms course.

It gives us a small game environment in which we can apply, visualize, debug and later profile the data structures and algorithms we study.

The project grows throughout the course.

## Why we use it

Most course concepts are first studied in a small, focused form using plain C#/.NET.

Frontier Dispatch then lets us see how the same ideas can be used in a game:

**Reason → Implement → Apply**

- **Reason:** understand the problem and required operations.
- **Implement:** build and test the core data structure or algorithm in plain C#.
- **Apply:** use or visualize the same idea in Unity.

The Unity layer is there to provide game-programming context. Unless an exercise or assignment explicitly says otherwise, Unity-specific implementation is **not required** to demonstrate the assessed course outcomes.

## Project structure

The important course systems are separated from the Unity-specific presentation code:

```text
Assets/
└── DSA/
    ├── Core/       Pure C# course/game systems
    ├── Unity/      Unity-specific visualization and integration
    ├── Editor/     Course-project setup/editor utilities
    └── Scenes/     Course demonstration/application scenes

Standalone/
└── FrontierDispatch.sln
```

Code under `Assets/DSA/Core` does not depend on `UnityEngine`.

The standalone .NET solution compiles the same core source files. This means the important algorithms and data structures can be built and tested without running Unity.

## Unity version

Use:

**Unity 6000.3.26f1**

Using the same editor version as the course baseline is strongly recommended.

## Current course baseline

### Week 2 — Stack, Queue and Fast Lookup

The Week 2 baseline includes:

- the Frontier Dispatch world model;
- Stack / Undo demonstration;
- Queue / Dispatch demonstration;
- Hash / Entity Lookup demonstration;
- World Map baseline;
- standalone .NET application and tests.

**Download the Week 2 release:**  
[Frontier Dispatch — Week 2 Baseline](https://github.com/CalleFreme/frontier-dispatch-game/releases/tag/week02-baseline-v1)

**Repository:**  
[Frontier Dispatch repository](https://github.com/CalleFreme/frontier-dispatch-game)

You may either download the release source ZIP or clone the repository.

If you are not comfortable with Git yet, downloading the released ZIP is completely fine.

## Scenes

The project currently contains:

```text
Launcher
Week02_StackQueue
Week02_HashLookup
Assignment_WorldMap
```

Start with `Launcher.unity` unless an exercise tells you to open another scene directly.

## How the project will grow

The same project will be extended as the course progresses.

### Week 2
- stacks;
- queues;
- hashing;
- dictionaries and sets.

### Week 3
- hierarchical data and traversal;
- priority queues.

### Week 4
- graphs;
- BFS and DFS;
- Dijkstra;
- A*.

### Week 5
- profiling;
- memory/allocation behavior;
- repeated work;
- loading, preprocessing and caching;
- optimization.

## Course baseline vs. individual assignment

The course version of Frontier Dispatch continues to evolve.

The **individual assignment uses a separate frozen starter version** so that later course updates do not change the project underneath your assignment work.

When the individual assignment is released, use the assignment starter linked from the assignment material in Omniway. Do not assume that the latest course baseline is also the assignment baseline.

## If something does not work

First check:

1. that you are using Unity `6000.3.26f1`;
2. that you opened the repository/project root, not a folder inside `Assets`;
3. that Unity has finished importing;
4. the Unity Console for compile errors;
5. the relevant lab/README instructions.

For the standalone version you can also verify the core project from the repository root:

```bash
dotnet restore Standalone/FrontierDispatch.sln
dotnet build Standalone/FrontierDispatch.sln
dotnet test Standalone/FrontierDispatch.sln
dotnet run --project Standalone/src/FrontierDispatch.App
```

If tooling or project setup is blocking you, ask for help rather than spending a long time stuck on environment problems.