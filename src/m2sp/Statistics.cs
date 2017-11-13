using System;
using System.Collections.Generic;

namespace m2sp {
    struct SpellStats {
        public double redundancySum;
        public UInt64 timeSum;
        public uint attemptCount;
        public uint correctCount;
        public uint redundancyDiv;
        public uint timeDiv;

        public SpellStats(double redundancySum, UInt64 timeSum, uint attemptCount, uint correctCount, uint redundancyDiv, uint timeDiv) {
            this.redundancySum = redundancySum;
            this.timeSum = timeSum;
            this.attemptCount = attemptCount;
            this.correctCount = correctCount;
            this.redundancyDiv = redundancyDiv;
            this.timeDiv = timeDiv;
        }
    }

    static class Statistics {
        private static SpellStats overallStats;
        private static Dictionary<int, SpellStats> spellStatistics;

        static Statistics() {
            initStatistics();
        }

        private static void initStatistics() {
            spellStatistics = new Dictionary<int, SpellStats>();

            spellStatistics.Add(Magick.AbuseAScroll, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Concussion, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Dispel, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Disruptor, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.DragonStrike, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.EmergencyTeleport, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.FuriousFowl, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Guardian, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Haste, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.HigherlandBreeze, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.IceTornado, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Push, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Revive, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Sacrifice, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.SpikeQuake, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.SummonLivingDeadPeople, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Teleport, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Thunderbolt, new SpellStats(0.0, 0, 0, 0, 0, 0));
            spellStatistics.Add(Magick.Thunderhead, new SpellStats(0.0, 0, 0, 0, 0, 0));

            overallStats = new SpellStats(0.0, 0, 0, 0, 0, 0);
        }

        public static void Clear() {
            initStatistics();
        }

        public static void Add(int magick, bool isCorrect, double redundancy, long castingTimeMS) {
            // Specific magick stats
            var spellStats = spellStatistics[magick];
            spellStats.attemptCount++;
            spellStats.correctCount += isCorrect ? (uint)1 : (uint)0;
            if (isCorrect) {
                spellStats.redundancySum += redundancy;
                spellStats.redundancyDiv++;
                spellStats.timeSum += (UInt64)castingTimeMS;
                spellStats.timeDiv++;
            }

            spellStatistics[magick] = spellStats;
            // Overal stats
            overallStats.attemptCount++;
            overallStats.correctCount += isCorrect ? (uint)1 : (uint)0;
            if (redundancy >= 0) {
                overallStats.redundancySum += redundancy;
                overallStats.redundancyDiv++;
            }
            overallStats.timeSum += (UInt64)castingTimeMS;
            overallStats.timeDiv++;

        }

        public static SpellStats GetStatistics(int magick) {
            if ((magick >= 0) && (magick <= 19))
                return spellStatistics[magick];

            return new SpellStats(0.0, 0, 0, 0, 0, 0);
        }

        public static SpellStats GetOverallStatistics() {
            return overallStats;
        }
    }
}
