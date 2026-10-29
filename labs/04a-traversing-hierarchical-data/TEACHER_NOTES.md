# Teacher Notes - Lab 4A

## Intended starter state

- 10 supplied tests total.
- 2 pass: node construction / child order.
- 8 fail because traversal methods throw `NotImplementedException`.

## Core teaching target

Students should leave able to explain a tree as recursive structure:

```text
node
+ zero or more child subtrees
```

Do not turn this into a binary-search-tree lesson. The useful preparation for Thursday is vocabulary, depth/height, recursive traversal, and the difference between a general linked hierarchy and the compact array representation used by a heap.

## Expected reference behavior

For the supplied skill tree:

```text
CountNodes = 7
Contains("Bow") = true
Contains("Magic") = false
DepthFirstPreOrder = Survival, Movement, Dash, Climb, Combat, Sword, Bow
MaxDepth = 2
```

## Common misconceptions

- "A tree must be binary." No: this lab uses a general rooted tree.
- "A leaf needs a separate recursive base-case branch." Not necessarily; zero children naturally ends the loop.
- "Recursive traversal is O(log n)." Only balanced-tree height is logarithmic; visiting every node is O(n).
- "Recursion and `Stack<T>` are the same thing." They are different mechanisms, but recursive calls are tracked on the call stack.

## Suggested live-code boundary

Live-code only `CountNodes` or trace it on the board. Let students implement `Contains`, traversal, and depth themselves.
