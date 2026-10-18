# Data Structures and Algorithms — Futuregames GP26

Teacher/reference repository for the Futuregames **Data Structures and Algorithms** course.

## Course approach

We repeatedly work through the same reasoning process:

**Understand → Predict → Plan → Implement → Test → Inspect → Improve**

The purpose is not to memorize collection APIs. We use implementation, testing and measurement to understand why data structures and algorithms behave the way they do and when they are appropriate.

## Repository model

- `main` is the completed/reference version of course code.
- Students receive starter ZIPs for labs and create their own repositories.
- Reference implementations are intentionally available. Try the problem first; use the reference to compare, recover and understand when needed.
- Checkpoint-question answers are discussed in teaching and are not supplied as a copyable answer sheet.

## Structure

- `docs/` — setup and working-process guidance
- `labs/` — completed/reference lab implementations
- `materials/` — teacher/student course material
- `starter-packages/` — generated starter archives when useful

## Toolchain

The plain-C# course projects use the **.NET 10 SDK**.

Core algorithm/data-structure libraries are kept compatible with **.NET Standard 2.1 and C# 9** where practical, so that the code style and APIs remain close to what current Unity 6 supports.

Test projects use NUnit-style tests so the testing approach also transfers naturally to Unity.
