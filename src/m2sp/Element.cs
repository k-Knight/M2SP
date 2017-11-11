using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m2sp {
    public static class Element {
        public const int Water = 0;
        public const int Life = 1;
        public const int Shield = 2;
        public const int Frost = 3;
        public const int Lightning = 4;
        public const int Death = 5;
        public const int Earth = 6;
        public const int Fire = 7;

        public const int Steam = 8;
        public const int Ice = 9;
        public const int Poison = 10;

        public const int Void = -1;

        static public bool Cancels(int elem1, int elem2) {
            switch (elem1) {
                case Water: {
                    if (elem2 == Lightning)
                        return true;
                } break;
                case Life: {
                    if (elem2 == Death)
                        return true;
                    if (elem2 == Poison)
                        return true;
                } break;
                case Shield: {
                    if (elem2 == Shield)
                        return true;
                } break;
                case Frost: {
                    if (elem2 == Fire)
                        return true;
                    if (elem2 == Steam)
                        return true;
                } break;
                case Lightning: {
                    if (elem2 == Water)
                        return true;
                    if (elem2 == Earth)
                        return true;
                } break;
                case Death: {
                    if (elem2 == Life)
                        return true;
                } break;
                case Earth: {
                    if (elem2 == Lightning)
                        return true;
                } break;
                case Fire: {
                    if (elem2 == Frost)
                        return true;
                    if (elem2 == Ice)
                        return true;
                } break;
                case Steam: {
                    if (elem2 == Frost)
                        return true;
                } break;
                case Ice: {
                    if (elem2 == Fire)
                        return true;
                } break;
                case Poison: {
                    if (elem2 == Life)
                        return true;
                } break;
            }

            return false;
        }

        static public int Cancel(int elem1, int elem2) {
            switch (elem1) {
                case Water: {
                    if (elem2 == Lightning)
                        return Void;
                } break;
                case Life: {
                    if (elem2 == Death)
                        return Void;
                    if (elem2 == Poison)
                        return Water;
                } break;
                case Shield: {
                    if (elem2 == Shield)
                        return Void;
                } break;
                case Frost: {
                    if (elem2 == Fire)
                        return Void;
                    if (elem2 == Steam)
                        return Water;
                } break;
                case Lightning: {
                    if (elem2 == Water)
                        return Void;
                    if (elem2 == Earth)
                        return Void;
                } break;
                case Death: {
                    if (elem2 == Life)
                        return Void;
                } break;
                case Earth: {
                    if (elem2 == Lightning)
                        return Void;
                } break;
                case Fire: {
                    if (elem2 == Frost)
                        return Void;
                    if (elem2 == Ice)
                        return Water;
                } break;
                case Steam: {
                    if (elem2 == Frost)
                        return Water;
                } break;
                case Ice: {
                    if (elem2 == Fire)
                        return Water;
                } break;
                case Poison: {
                    if (elem2 == Life)
                        return Water;
                } break;
            }

            return Void;
        }

        static public bool Combines(int elem1, int elem2) {
            switch (elem1) {
                case Water: {
                    if (elem2 == Death)
                        return true;
                    if (elem2 == Frost)
                        return true;
                    if (elem2 == Fire)
                        return true;
                } break;
                case Death: {
                    if (elem2 == Water)
                        return true;
                } break;
                case Frost: {
                    if (elem2 == Water)
                        return true;
                } break;
                case Fire: {
                    if (elem2 == Water)
                        return true;
                } break;
            }

            return false;
        }

        static public int Combine(int elem1, int elem2) {
            switch (elem1) {
                case Water: {
                    if (elem2 == Death)
                        return Poison;
                    if (elem2 == Frost)
                        return Ice;
                    if (elem2 == Fire)
                        return Steam;
                } break;
                case Death: {
                    if (elem2 == Water)
                        return Poison;
                } break;
                case Frost: {
                    if (elem2 == Water)
                        return Ice;
                } break;
                case Fire: {
                    if (elem2 == Water)
                        return Steam;
                } break;
            }

            return Void;
        }

        static public int ElementCastingCost(int element) {
            switch (element) {
                case Water: return 1;
                case Life: return 1;
                case Shield: return 1;
                case Frost: return 1;
                case Lightning: return 1;
                case Death: return 1;
                case Earth: return 1;
                case Fire: return 1;
                case Steam: return 2;
                case Ice: return 2;
                case Poison: return 2;
            }
            return 0;
        }

        public static int toElement(char ch) {
            switch (ch) {
                case 'Q': return Element.Water;
                case 'W': return Element.Life;
                case 'E': return Element.Shield;
                case 'R': return Element.Frost;
                case 'A': return Element.Lightning;
                case 'S': return Element.Death;
                case 'D': return Element.Earth;
                case 'F': return Element.Fire;
            }

            return Element.Void;
        }
    }
}
