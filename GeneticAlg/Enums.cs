using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    namespace GeneticAlg
    {
        public static class Enums
        {
            public enum codingStyle { Z, R }

            public enum selectionMethods { Roulette, Truncation, Tournament }

            public enum crossingoverTypeZ { OnePointed, TwoPointed, Uniform }

            public enum crossingoverTypeR { TwoPointed, Arifmetically, BlxAlpha }
        }
    }
}
