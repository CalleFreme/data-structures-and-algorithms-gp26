# Preparation for Tuesday: Recursion and Trees

**Estimated time: 20–25 minutes**

On Tuesday we will work with **recursion**, **trees**, and **hierarchical data**, then apply those ideas in **Lab 4A — Traversing Hierarchical Data**.

You do **not** need to understand recursion or tree algorithms before the lecture.

> **Important:** Make your predictions before searching for definitions or solutions. The purpose is to arrive with a mental model we can test and refine together.

## 1. Recognize hierarchical data

Consider this simplified game data:

```text
World
├── Town
│   ├── Blacksmith
│   └── Inn
└── Forest
    ├── Cave
    └── Ruins
```

Without looking up terminology, answer:

1. Which item appears to be the single starting point of the hierarchy?
2. Which items have things below them?
3. Which items have nothing below them?
4. Is `Town` itself the start of a smaller hierarchy contained inside `World`?
5. If `Cave` is removed, which other entries need to disappear with it?

Write down your answers in ordinary language.

## 2. Name the relationships

Now use these terms:

- **root** — the top node;
- **parent** — a node directly above another node;
- **child** — a node directly below another node;
- **leaf** — a node with no children;
- **subtree** — one node together with everything below it.

For the hierarchy above:

1. What is the root?
2. What is the parent of `Blacksmith`?
3. What are the children of `Forest`?
4. Which nodes are leaves?
5. Write the subtree rooted at `Town`.

You are not expected to memorize the words yet. We will use them repeatedly on Tuesday.

## 3. A repeated problem inside itself

Suppose we want to count every node in the hierarchy.

One way to describe the problem is:

> Count the current node, then count every node below each child.

Consider this C# method:

```csharp
static int CountNodes(Node node)
{
    int count = 1;

    foreach (Node child in node.Children)
    {
        count += CountNodes(child);
    }

    return count;
}
```

Do **not** run the code yet.

Using this smaller hierarchy:

```text
A
├── B
│   ├── D
│   └── E
└── C
```

predict:

| Call | Result |
| --- | ---: |
| `CountNodes(D)` | ? |
| `CountNodes(B)` | ? |
| `CountNodes(C)` | ? |
| `CountNodes(A)` | ? |

Then answer:

1. Why can `CountNodes` call `CountNodes` again?
2. What eventually stops the calls from continuing forever?
3. For a leaf such as `D`, what does the `foreach` loop do?

## 4. Trace the call structure

For:

```text
A
├── B
│   ├── D
│   └── E
└── C
```

try to sketch the calls made by:

```csharp
CountNodes(A)
```

For example:

```text
CountNodes(A)
├── CountNodes(B)
│   ├── ...
│   └── ...
└── ...
```

Do not worry about perfect notation. The goal is to see that the call structure resembles the data structure.

## 5. Predict a traversal order

Suppose an algorithm:

1. processes the current node;
2. then completely processes each child from left to right.

For:

```text
A
├── B
│   ├── D
│   └── E
└── C
```

what order do you predict the nodes will be visited?

Write:

```text
A, ...
```

This is one form of **depth-first traversal**. We will give it a precise name and compare alternatives during the lecture.

## 6. Why not just use one flat List?

Imagine the world hierarchy contains 100,000 nodes.

Think briefly about these questions:

1. If we want to process **everything below `Town`**, what information does the hierarchy make explicit?
2. If all nodes were stored only in one flat `List<Node>`, what extra relationship information might we need?
3. What game systems naturally contain hierarchy?

Possible examples include Unity Transform hierarchies, UI trees, dialogue/quest structures, behaviour trees, skill trees, and file/folder-like content.

You only need one example you can explain.

## 7. Optional refresher

If recursion feels unfamiliar, review only these ideas:

- a method can call itself;
- each call has its own local variables;
- the problem must eventually reach a case that does not make another recursive call;
- recursive code is often useful when the data itself is recursively structured.

> **Stop here.** Do not implement Lab 4A in advance unless you want to. On Tuesday we will build the vocabulary, trace recursive calls carefully, discuss the call stack, and implement tree traversal together.
