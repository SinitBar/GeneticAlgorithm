using NoStringEvaluating.Models.Values;
using NoStringEvaluating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeneticAlg.GeneticAlg.Enums;
using GeneticAlg.GeneticAlg;
using System.Drawing;

namespace GeneticAlg
{
    internal class GeneticAlgorithmR : GeneticAlgorithm<double>
    {

        Enums.crossingoverTypeR CrossingoverType;

       // public Population<double> CurrentPopulation { get; private set; }

        double Lambda; // parametr for arifmetically crossingover

        double Alpha; // parametr for BLX-alpha crossingover

        double Epsilon; // parameter for mutation (interval for delta is from - Epsilon to + Epsilon)

        public GeneticAlgorithmR(int populationSize, string fitness,
            string[] variables, Enums.selectionMethods selectionMethod,
            double lowerLimitVariable, double upperLimitVariable, double codingAccuracy, 
            double mutationProbability, double crossingoverProbability, 
            Enums.crossingoverTypeR crossingoverType, double l = 1, double t = 1, 
            int tournamentSize = 2, double lambda = 0.5, double alpha = 0.5, double epsilon = 0.5) : 
            base(populationSize, fitness,
                variables, selectionMethod, lowerLimitVariable, upperLimitVariable, 
                codingAccuracy, crossingoverProbability, mutationProbability,  l, t, tournamentSize)
        {
            Lambda = lambda;
            Alpha = alpha;
            Epsilon = epsilon;
            CurrentPopulation = new Population<double>(populationSize, lowerLimitVariable, upperLimitVariable);
            for (int i = 0; i < PopulationSize; i++)
                CurrentPopulation.Individs[i] = new Individ<double>(Variables.Length);
            CrossingoverType = crossingoverType;
            CreatePopulationByRandom();
        }

        public void CreatePopulationByRandom()
        {
            for (int k = 0; k < PopulationSize; k++)
            {
                var random = new Random();
                for (int j = 0; j < CurrentPopulation.Individs[0].AmountOfGens; j++)
                {
                    CurrentPopulation.Individs[k].Gens[j] = random.NextDouble() * 
                        (UpperLimitVariable - LowerLimitVariable) + LowerLimitVariable;
                }
            }
        }

        public void Mutate(Individ<double> individ)
        {
            var rand = new Random();
            for (int i = 0; i < individ.Gens.Length; i++)
            {
                double p = rand.NextDouble() * (2 * Epsilon) - Epsilon;
                individ.Gens[i] += p;
            }
        }

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
                    var value = CurrentPopulation.Individs[j].Gens[i];
                    vars.Add(Variables[i], value);
                }
                fitnesses[j] = evaluator.CalcNumber(FitnessFunction, vars);
            }
            return fitnesses;
        }

        public void Crossingover(Individ<double> parent1, Individ<double> parent2,
out Individ<double> child1, out Individ<double> child2)
        {
            switch (CrossingoverType)
            {
                case Enums.crossingoverTypeR.BlxAlpha:
                    BlxAlphaCrossingover(parent1, parent2, out child1, out child2);
                    break;
                case Enums.crossingoverTypeR.TwoPointed:
                    TwoPointedCrossingover(parent1, parent2, out child1, out child2);
                    break;
                default:
                    ArifmeticalyCrossingover(parent1, parent2, out child1, out child2);
                    break;
            }
        }

        // CROSSINGOVERS
        public void TwoPointedCrossingover(Individ<double> parent1, Individ<double> parent2,
  out Individ<double> child1, out Individ<double> child2)
        {
            int gensLength = CurrentPopulation.Individs[0].Gens.Length;
            var rand = new Random();
            int pointToCutFrom = rand.Next(gensLength - 1);
            int pointToCutTo = rand.Next(gensLength - 1);
            if (pointToCutTo < pointToCutFrom)
                (pointToCutTo, pointToCutFrom) = (pointToCutFrom, pointToCutTo); // swap
            double[] gensChild1 = new double[gensLength];
            double[] gensChild2 = new double[gensLength];
            for (int i = 0; i < gensLength; i++)
            {
                if (i > pointToCutFrom && i <= pointToCutTo)
                {
                    gensChild1[i] = parent1.Gens[i];
                    gensChild2[i] = parent2.Gens[i];
                }
                else
                {
                    if (pointToCutFrom == pointToCutTo)
                    {
                        if (i <= pointToCutFrom)
                        {
                            gensChild1[i] = parent1.Gens[i];
                            gensChild2[i] = parent2.Gens[i];
                        }
                        else
                        {
                            gensChild1[i] = parent2.Gens[i];
                            gensChild2[i] = parent1.Gens[i];
                        }
                    }
                    else
                    {
                        gensChild1[i] = parent2.Gens[i];
                        gensChild2[i] = parent1.Gens[i];
                    }
                }
            }
            child1 = new Individ<double>(gensChild1);
            child2 = new Individ<double>(gensChild2);
        }

        public void ArifmeticalyCrossingover(Individ<double> parent1, Individ<double> parent2,
   out Individ<double> child1, out Individ<double> child2)
        {
            int gensLength = CurrentPopulation.Individs[0].Gens.Length;
            double[] gensChild1 = new double[gensLength];
            double[] gensChild2 = new double[gensLength];

            for (int i = 0; i < gensLength; i++)
            {
                gensChild1[i] = Lambda * parent1.Gens[i] + (1 - Lambda) * parent2.Gens[i];
                gensChild2[i] = Lambda * parent2.Gens[i] + (1 - Lambda) * parent1.Gens[i];
            }
            child1 = new Individ<double>(gensChild1);
            child2 = new Individ<double>(gensChild2);
        }

        public void BlxAlphaCrossingover(Individ<double> parent1, Individ<double> parent2,
out Individ<double> child1, out Individ<double> child2)
        {
            int gensLength = CurrentPopulation.Individs[0].Gens.Length;
            double[] gensChild1 = new double[gensLength];
            double[] gensChild2 = new double[gensLength];

            var rand = new Random();

            for (int i = 0; i < gensLength; i++)
            {
                double min = parent1.Gens[i];
                double max = parent2.Gens[i];

                if (max < min)
                    (min, max) = (max, min); // swap

                double length = max - min;

                min -= Alpha * length;
                max += Alpha * length;

                gensChild1[i] = rand.NextDouble() * (max - min) + min;
                gensChild2[i] = rand.NextDouble() * (max - min) + min;
            }

            child1 = new Individ<double>(gensChild1);
            child2 = new Individ<double>(gensChild2);
        }
        // END CROSSINGOVERS

        //public override void RenewPopulation()
        //{
        //    int amountOfChildren = (int)(PopulationSize * T);
        //    int amountOfParents = (int)(PopulationSize * (1 - T));
        //    if (amountOfChildren + amountOfParents != PopulationSize)
        //        amountOfChildren++;
        //    // TODO: change generation
        //}
    }
}
