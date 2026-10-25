# Wednesday preparation - From scanning to buckets

**Estimated time: 15-20 minutes**

You have 10,000 game entities. Each entity has a unique non-negative integer ID. The game repeatedly asks:

> Give me the entity whose ID is 734.

## 1. Baseline

If all entities are in one `List<Entity>`, one straightforward lookup is to scan until the matching ID is found.

Think:

- What is the best case?
- What is the worst case?
- What happens to the worst-case work as the list grows?

## 2. Let the key guide us

Suppose we have five buckets and use:

```text
bucket = id % 5
```

Predict the bucket for each ID:

| ID | Bucket |
| ---: | ---: |
| 101 | ? |
| 205 | ? |
| 734 | ? |
| 206 | ? |
| 999 | ? |

Now answer:

1. Which IDs end up in the same bucket?
2. Is that necessarily a problem?
3. If you are looking for ID 734, which data can you avoid inspecting?

Stop there. On Thursday we will name this idea, deal with collisions properly, and connect it to `Dictionary` and `HashSet`.
