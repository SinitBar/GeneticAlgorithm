using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    internal class Population<T>
    {
        public Individ<T>[] Individs { get; private set; }
        public double LowerLimitVariable { get; private set; } // from what value
        public double UpperLimitVariable { get; private set; } // to what value could be every individ's gen

        public Population(int size, double lowerLimitVariable, double upperLimitVariable)
        {
            Individs = new Individ<T>[size];
            UpperLimitVariable = upperLimitVariable;
            LowerLimitVariable = lowerLimitVariable;
        }

        public Population(List<Individ<T>> individs, double lowerLimitVariable, double upperLimitVariable)
        {
            Individs = individs.ToArray();
            UpperLimitVariable = upperLimitVariable;
            LowerLimitVariable = lowerLimitVariable;
        }
        /**
         * function SortIndividsByFitnessDesc sorts individs from good-fitness to bad-fitness
         */
        public void SortIndividsByFitnessDesc(double[] fitnesses)
        {
            if (fitnesses.Length != Individs.Length)
                throw new ArgumentException("amount of fitness estimates should be equal to population size");
            Array.Sort(fitnesses, Individs);
        }

        public List<Individ<T>> ChooseRandomIndivids(int amountOfIndividsToChoose)
        {
            int[] indexes = new int[Individs.Length];
            for (int i = 0; i < Individs.Length; i++)
                indexes[i] = i;
            RandomAndProbabilityFunctions.Shuffle(indexes);
            List<Individ<T>> randomlyChosenIndivids = new List<Individ<T>>(amountOfIndividsToChoose);
            for (int i = 0; i < amountOfIndividsToChoose; i++)
                randomlyChosenIndivids.Add(Individs[indexes[i]]);
            return randomlyChosenIndivids;
        }
    }
}
