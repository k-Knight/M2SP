using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace m2sp {
    static class Magick {
        public const int AbuseAScroll = 0;
        public const int Concussion = 1;
        public const int Dispel = 2;
        public const int Disruptor = 3;
        public const int DragonStrike = 4;
        public const int EmergencyTeleport = 5;
        public const int FuriousFowl = 6;
        public const int Guardian = 7;
        public const int Haste = 8;
        public const int HigherlandBreeze = 9;
        public const int IceTornado = 10;
        public const int Push = 11;
        public const int Revive = 12;
        public const int Sacrifice = 13;
        public const int SpikeQuake = 14;
        public const int SummonLivingDeadPeople = 15;
        public const int Teleport = 16;
        public const int Thunderbolt = 17;
        public const int Thunderhead = 18;
        public const int Unknown = -1;

        public static readonly Dictionary<int, List<int>> magicks;
        public static readonly Dictionary<int, string> names;
        private static int currentMagick = -1;
        private static Random randGen = new Random();

        public static int GetNextMagick() {
            uint minCasts = Statistics.GetStatistics(AbuseAScroll).correctCount;
            List<int> minSuccMagicks = new List<int>() { 0 };
            // Find all magicks with min successful casts
            for (int i = 1; i < 19; i++) {
                if (Statistics.GetStatistics(i).correctCount == minCasts)
                    minSuccMagicks.Add(i);
                else if (Statistics.GetStatistics(i).correctCount < minCasts) {
                    minCasts = Statistics.GetStatistics(i).correctCount;
                    minSuccMagicks.Clear();
                    minSuccMagicks.Add(i);
                }
            }

            currentMagick = minSuccMagicks[randGen.Next(minSuccMagicks.Count)];
            return currentMagick;
        }

        public static bool AttemptMagick(List<int> spell, int castingSequenceLength, long castingTimeMS) {
            // Spell check
            bool correctSpell = true;
            if (spell.Count != magicks[currentMagick].Count)
                correctSpell = false;
            else
                for (int i = 0; i < spell.Count; i++)
                    if (spell[i] != magicks[currentMagick][i])
                        correctSpell = false;
            // Calculate statistics
            int spellComplexity = 0;
            for (int i = 0; i < spell.Count; i++)
                spellComplexity += Element.ElementCastingCost(spell[i]);
            double redundancy;
            if (spellComplexity > 0)
                redundancy = ((double)castingSequenceLength) / ((double)spellComplexity) - 1.0;
            else
                redundancy = -1;
            // Add to statistics
            Statistics.Add(currentMagick, correctSpell, redundancy, castingTimeMS);

            return correctSpell;
        }

        static Magick() {
            magicks = new Dictionary<int, List<int>>();
            names = new Dictionary<int, string>();
            // AbuseAScroll
            magicks.Add(AbuseAScroll, new List<int>() {
                Element.Fire, Element.Lightning, Element.Life
            });
            names.Add(AbuseAScroll, "Abuse a Scroll");
            // Concussion
            magicks.Add(Concussion, new List<int>() {
                Element.Water, Element.Shield, Element.Water, Element.Water
            });
            names.Add(Concussion, "Concussion");
            // Dispel
            magicks.Add(Dispel, new List<int>() {
                Element.Death, Element.Shield
            });
            names.Add(Dispel, "Dispel");
            // Disruptor
            magicks.Add(Disruptor, new List<int>() {
                Element.Death, Element.Earth, Element.Shield
            });
            names.Add(Disruptor, "Disruptor");
            // DragonStrike
            magicks.Add(DragonStrike, new List<int>() {
                Element.Fire, Element.Fire, Element.Earth, Element.Fire, Element.Fire
            });
            names.Add(DragonStrike, "Dragon Strike");
            // EmergencyTeleport
            magicks.Add(EmergencyTeleport, new List<int>() {
                Element.Lightning, Element.Death, Element.Lightning
            });
            names.Add(EmergencyTeleport, "Emergency\n   Teleport");
            // FuriousFowl
            magicks.Add(FuriousFowl, new List<int>() {
                Element.Death, Element.Earth, Element.Death, Element.Earth
            });
            names.Add(FuriousFowl, "Furious Fowl");
            // Guardian
            magicks.Add(Guardian, new List<int>() {
                Element.Life, Element.Life, Element.Lightning, Element.Shield
            });
            names.Add(Guardian, "Guardian");
            // Haste
            magicks.Add(Haste, new List<int>() {
                Element.Lightning, Element.Death, Element.Fire
            });
            names.Add(Haste, "Haste");
            // HigherlandBreeze
            magicks.Add(HigherlandBreeze, new List<int>() {
                Element.Ice, Element.Ice, Element.Ice, Element.Ice
            });
            names.Add(HigherlandBreeze, "Higherland\n   Breeze");
            // IceTornado
            magicks.Add(IceTornado, new List<int>() {
                Element.Ice, Element.Ice, Element.Earth, Element.Frost, Element.Frost
            });
            names.Add(IceTornado, "Ice Tornado");
            // Push
            magicks.Add(Push, new List<int>() {
                Element.Water, Element.Shield
            });
            names.Add(Push, "Push");
            // Revive
            magicks.Add(Revive, new List<int>() {
                Element.Life, Element.Lightning
            });
            names.Add(Revive, "Revive");
            // Sacrifice
            magicks.Add(Sacrifice, new List<int>() {
                Element.Death, Element.Death, Element.Death, Element.Death, Element.Lightning,
            });
            names.Add(Sacrifice, "Sacrifice");
            // SpikeQuake
            magicks.Add(SpikeQuake, new List<int>() {
                Element.Death, Element.Death, Element.Earth, Element.Death, Element.Death,
            });
            names.Add(SpikeQuake, "Spike Quake");
            // SummonLivingDeadPeople
            magicks.Add(SummonLivingDeadPeople, new List<int>() {
                Element.Ice, Element.Earth, Element.Death, Element.Frost
            });
            names.Add(SummonLivingDeadPeople, "Summon Living\n   Dead People");
            // Teleport
            magicks.Add(Teleport, new List<int>() {
                Element.Lightning, Element.Death, Element.Death
            });
            names.Add(Teleport, "Teleport");
            // Thunderbolt
            magicks.Add(Thunderbolt, new List<int>() {
                Element.Steam, Element.Lightning, Element.Death, Element.Lightning
            });
            names.Add(Thunderbolt, "Thunderbolt");
            // Thunderhead
            magicks.Add(Thunderhead, new List<int>() {
                Element.Fire, Element.Fire, Element.Death, Element.Lightning, Element.Lightning
            });
            names.Add(Thunderhead, "Thunderhead");
        }
    }
}
