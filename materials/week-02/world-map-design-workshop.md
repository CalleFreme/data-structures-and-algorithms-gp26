# Group Exercise - Frontier Dispatch World Map Design Workshop

Work in groups of **3-4**. You are designing data for a small game world.

The baseline contains:

```text
Location
- Id
- Name
- Position
- Type

Connection
- FromLocationId
- ToLocationId
- TravelCost
```

The intentionally simple starting point is:

```csharp
List<Location> locations;
List<Connection> connections;
```

Do not begin by naming data structures. Begin by identifying the **operation** the game needs.

## Card A - Find a location by ID

The game frequently asks:

> Give me location 734.

Discuss:

1. What does the current list representation have to do?
2. What operation are we trying to make cheap?
3. What alternative representation or additional index could help?
4. What does that alternative cost us?

## Card B - Find outgoing roads

Pathfinding repeatedly asks:

> Give me every connection leaving location 734.

Discuss the same four questions.

## Card C - Have we already visited this location?

A search repeatedly asks:

> Has location 734 already been visited?

What operation matters most now?

## Card D - Give me the cheapest candidate

During route planning we repeatedly need to:

```text
add a candidate with a cost
remove the candidate with the smallest cost
```

You may not know the ideal structure yet. That is okay. Describe the required operations first.

## Twist cards

Your teacher will give your group one changed requirement. Reconsider your design:

- The world has only 20 locations.
- The world has 500,000 locations.
- World data is loaded once and queried thousands of times.
- Roads change constantly during play.
- Memory is extremely limited.

There is not always one universally best representation. Be ready to explain **why your choice fits the operations and constraints**.
