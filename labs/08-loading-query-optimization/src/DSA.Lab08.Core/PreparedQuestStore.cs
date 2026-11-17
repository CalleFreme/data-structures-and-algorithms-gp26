using System;
using System.Collections.Generic;

namespace DSA.Lab08
{
    public sealed class PreparedQuestStore
    {
        private readonly Dictionary<string, QuestRecord> byId = new Dictionary<string, QuestRecord>();
        private readonly Dictionary<string, List<QuestRecord>> byRegion = new Dictionary<string, List<QuestRecord>>();

        public PreparedQuestStore(IReadOnlyList<string> lines, QuestParser parser)
        {
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            for (int i = 0; i < lines.Count; i++)
            {
                QuestRecord q = parser.Parse(lines[i]);
                byId[q.Id] = q;
                if (!byRegion.TryGetValue(q.Region, out List<QuestRecord>? list))
                {
                    list = new List<QuestRecord>();
                    byRegion[q.Region] = list;
                }
                list.Add(q);
            }
        }

        public QuestRecord? FindById(string id)
        {
            byId.TryGetValue(id, out QuestRecord? q);
            return q;
        }

        public IReadOnlyList<QuestRecord> GetByRegion(string region)
        {
            return byRegion.TryGetValue(region, out List<QuestRecord>? xs)
                ? xs
                : Array.Empty<QuestRecord>();
        }
    }
}
