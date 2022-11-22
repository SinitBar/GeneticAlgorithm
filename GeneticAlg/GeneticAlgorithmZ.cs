using GeneticAlg.GeneticAlg;
using NoStringEvaluating;
using NoStringEvaluating.Models.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    internal class GeneticAlgorithmZ: GeneticAlgorithm<int>
    {
        Enums.crossingoverTypeZ CrossingoverType;

        double P0; // probability of taking bit in uniform crossingover

        double Pm; // probability of mutation of every bit in the gen

        public int BitsPerGen 
        { 
            get { return CountBitsPerGen(); }
            private set { }
        }
        
        public GeneticAlgorithmZ(int populationSize, string fitness, 
            string[] variables, Enums.selectionMethods selectionMethod,
            double lowerLimitVariable, double upperLimitVariable, double codingAccuracy,
            double mutationProbability, double crossingoverProbability, Enums.crossingoverTypeZ crossingoverType,
            double l = 1, double t = 1, int tournamentSize = 2, double p0 = 0.5, double pm = 0.5) : base(populationSize, fitness, 
                variables, selectionMethod, lowerLimitVariable, upperLimitVariable, 
                codingAccuracy, crossingoverProbability, mutationProbability, l, t, tournamentSize)
        {
            P0 = p0;
            Pm = pm;
            CurrentPopulation = new Population<int>(PopulationSize, LowerLimitVariable, UpperLimitVariable);
            for (int i = 0; i < PopulationSize; i++)
                CurrentPopulation.Individs[i] = new Individ<int>(Variables.Length);
            CrossingoverType = crossingoverType;
            CreatePopulationByRandom();
        }

        // needed only in int individ
        int CountBitsPerGen()
        {
            double searchAreaLength = UpperLimitVariable - LowerLimitVariable;
            int amountOfBitsToCode = (int)(searchAreaLength / CodingAccuracy) + 1;
            return (int)Math.Ceiling(Math.Log2(amountOfBitsToCode));
        }

        public double FromZToR(int zNumber) // code function
        {
            return (zNumber * (UpperLimitVariable - LowerLimitVariable) / ((1 << BitsPerGen) - 1))
                + LowerLimitVariable;
        }

        public int FromRToZ(double rNumber) // decode function 
        {
            return (int)((rNumber - LowerLimitVariable) * ((1 << BitsPerGen) - 1) /
                (UpperLimitVariable - LowerLimitVariable));
        }

        // changes bitChromosome bit on position bitPosition to value newValue
        public void ChangeBitTo(int bitPosition, int newValue, int[] bitChromosome)
        {
            if (bitPosition < 0 || bitPosition >= bitChromosome.Length)
                throw new ArgumentOutOfRangeException("bit position should be >= 0 and <= " + bitChromosome.Length);
            if (newValue != 0 && newValue != 1)
                throw new ArgumentOutOfRangeException("value of bit can be only 0 or 1");
            bitChromosome[bitPosition] = newValue;
        }

        int[] ToBitArray(int number)
        {
            int[] array = new int[BitsPerGen];
            for (int i = BitsPerGen - 1; i >= 0; i--)
            {
                array[i] = number % 2;
                number /= 2;
                if (number == 0)
                    break;
            }
            return array;
        }

        int[] ToBitChromosome(Individ<int> individ)
        {
            int[] bitChromosome = ToBitArray(individ.Gens[0]);
            for (int i = 1; i < individ.Gens.Length; i++)
                bitChromosome = bitChromosome.Concat(ToBitArray(individ.Gens[i])).ToArray();
            return bitChromosome;
        }

        int[] ToGens(int[] bitChromosome)
        {
            int gensLength = CurrentPopulation.Individs[0].Gens.Length;
            int[] gensArray = new int[gensLength];
            for (int i = 0; i < gensLength; i++)
            {
                for (int j = 0; j < BitsPerGen; j++)
                {
                    int currentBitIndex = i * BitsPerGen - j + BitsPerGen - 1; // go from last bit of gen to first
                    gensArray[i] += bitChromosome[currentBitIndex] << j; // add 2 in j degree if bit = 1 or add 0
                }
            }
            return gensArray;
        }

        // fills every gen of every individ in population by random numbers in data interval
        public void CreatePopulationByRandom()
        {
            for (int k = 0; k < PopulationSize; k++)
            {
                var random = new Random();
                for (int j = 0; j < CurrentPopulation.Individs[0].AmountOfGens; j++)
                {
                    CurrentPopulation.Individs[k].Gens[j] = FromRToZ(random.NextDouble() * 
                        (UpperLimitVariable - LowerLimitVariable)
                    + LowerLimitVariable);
                }
            }
        }

        public void Mutate(Individ<int> individ)
        {
            int[] bitChromosome = ToBitChromosome(individ);
            for (int i = 0; i < bitChromosome.Length; i++)
                if (RandomAndProbabilityFunctions.isChosenWithProbability(Pm))
                    bitChromosome[i] = (bitChromosome[i] + 1) % 2;
            individ.Gens = ToGens(bitChromosome);
        }

        public void Crossingover(Individ<int> parent1, Individ<int> parent2,
out Individ<int> child1, out Individ<int> child2)
        {
            switch(CrossingoverType)
            {
                case Enums.crossingoverTypeZ.Uniform:
                    UniformCrossingover(parent1, parent2, out child1, out child2);
                    break;
                case Enums.crossingoverTypeZ.OnePointed:
                    OnePointedCrossingover(parent1, parent2, out child1, out child2);
                    break;
                default:
                    TwoPointedCrossingover(parent1, parent2, out child1, out child2);
                    break;
            }
        }

        // CROSSINGOVERS
        public void UniformCrossingover(Individ<int> parent1, Individ<int> parent2,
out Individ<int> child1, out Individ<int> child2)
        {
            int[] bitChromosomeParent1 = ToBitChromosome(parent1);
            int[] bitChromosomeParent2 = ToBitChromosome(parent2);
            int[] bitChromosomeChild1 = new int[bitChromosomeParent1.Length];
            int[] bitChromosomeChild2 = new int[bitChromosomeParent2.Length];
            for (int i = 0; i < bitChromosomeParent1.Length; i++)
            {
                if (RandomAndProbabilityFunctions.isChosenWithProbability(P0))
                {
                    bitChromosomeChild1[i] = bitChromosomeParent1[i];
                    bitChromosomeChild2[i] = bitChromosomeParent2[i];
                }
                else
                {
                    bitChromosomeChild1[i] = bitChromosomeParent2[i];
                    bitChromosomeChild2[i] = bitChromosomeParent1[i];
                }
            }
            
            child1 = new Individ<int>(ToGens(bitChromosomeChild1));
            child2 = new Individ<int>(ToGens(bitChromosomeChild2));
        }

        public void OnePointedCrossingover(Individ<int> parent1, Individ<int> parent2,
            out Individ<int> child1, out Individ<int> child2, int pointToCut = -1)
        {
            int[] bitChromosomeParent1 = ToBitChromosome(parent1);
            int[] bitChromosomeParent2 = ToBitChromosome(parent2);
            var rand = new Random();
            if (pointToCut == -1)
                pointToCut = rand.Next(bitChromosomeParent1.Length - 1);
            int[] bitChromosomeChild1 = new int[bitChromosomeParent1.Length];
            int[] bitChromosomeChild2 = new int[bitChromosomeParent2.Length];
            for (int i = 0; i < bitChromosomeParent1.Length; i++)
            {
                if (i <= pointToCut)
                {
                    bitChromosomeChild1[i] = bitChromosomeParent1[i];
                    bitChromosomeChild2[i] = bitChromosomeParent2[i];
                }
                else
                {
                    bitChromosomeChild1[i] = bitChromosomeParent2[i];
                    bitChromosomeChild2[i] = bitChromosomeParent1[i];
                }
            }
            child1 = new Individ<int>(ToGens(bitChromosomeChild1));
            child2 = new Individ<int>(ToGens(bitChromosomeChild2));
        }

        public void TwoPointedCrossingover(Individ<int> parent1, Individ<int> parent2,
out Individ<int> child1, out Individ<int> child2)
        {
            int[] bitChromosomeParent1 = ToBitChromosome(parent1);
            int[] bitChromosomeParent2 = ToBitChromosome(parent2);
            var rand = new Random();
            int pointToCutFrom = rand.Next(bitChromosomeParent1.Length - 1);
            int pointToCutTo = rand.Next(bitChromosomeParent1.Length - 1);
            if (pointToCutTo == pointToCutFrom)
            {
                OnePointedCrossingover(parent1, parent2, out child1, out child2, pointToCutTo);
                return;
            }
            if (pointToCutTo < pointToCutFrom)
                (pointToCutTo, pointToCutFrom) = (pointToCutFrom, pointToCutTo); // swap
            int[] bitChromosomeChild1 = new int[bitChromosomeParent1.Length];
            int[] bitChromosomeChild2 = new int[bitChromosomeParent2.Length];
            for (int i = 0; i < bitChromosomeParent1.Length; i++)
            {
                if (i > pointToCutFrom && i <= pointToCutTo)
                {
                    bitChromosomeChild1[i] = bitChromosomeParent1[i];
                    bitChromosomeChild2[i] = bitChromosomeParent2[i];
                }
                else
                {
                    bitChromosomeChild1[i] = bitChromosomeParent2[i];
                    bitChromosomeChild2[i] = bitChromosomeParent1[i];
                }
            }
            child1 = new Individ<int>(ToGens(bitChromosomeChild1));
            child2 = new Individ<int>(ToGens(bitChromosomeChild2));
        }

        // END CROSSINGOVERS

        public override double[] GetFitnesses()
        {
            double[] fitnesses = new double[PopulationSize];
            var vars = new Dictionary<string, EvaluatorValue>();
            NoStringEvaluator evaluator = NoStringEvaluator.CreateFacade().Evaluator;
            for (int j = 0; j < PopulationSize; j++)
            {
                vars.Clear();
                for (int i = 0; i < Variables.Length; i++)
                {
                    var value = FromZToR(CurrentPopulation.Individs[j].Gens[i]);
                    vars.Add(Variables[i], value);
                }
                fitnesses[j] = evaluator.CalcNumber(FitnessFunction, vars);
            }
            return fitnesses;
        }
    }
}
