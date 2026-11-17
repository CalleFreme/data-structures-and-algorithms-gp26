using System;
using System.Collections.Generic;

namespace DSA.Lab07
{
    public sealed class ThreatScanner
    {
        public ScanResult Scan(IReadOnlyList<Enemy> enemies, IReadOnlyList<int> activeEnemyIds, int repetitions)
        {
            if (enemies == null) throw new ArgumentNullException(nameof(enemies));
            if (activeEnemyIds == null) throw new ArgumentNullException(nameof(activeEnemyIds));
            if (repetitions < 0) throw new ArgumentOutOfRangeException(nameof(repetitions));

            var active = new HashSet<int>();
            for (int i = 0; i < activeEnemyIds.Count; i++)
            {
                active.Add(activeEnemyIds[i]);
            }

            long visited = 0;
            long membershipChecks = 0;
            long totalThreat = 0;

            for (int r = 0; r < repetitions; r++)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    visited++;
                    membershipChecks++;
                    Enemy e = enemies[i];
                    if (active.Contains(e.Id)) totalThreat += e.Threat;
                }
            }

            return new ScanResult(totalThreat, visited, membershipChecks);
        }
    }
}
