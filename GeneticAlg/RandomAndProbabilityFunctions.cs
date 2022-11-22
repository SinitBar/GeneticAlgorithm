using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    internal class RandomAndProbabilityFunctions
    {
        public static bool isChosenWithProbability(double probability)
        {
            if (probability < 0 || probability > 1)
                throw new ArgumentException("probability should be a number in interval (0; 1)");
            if (probability == 0)
                return false;
            if (probability == 1)
                return true;
            var rand = new Random();
            double prob = rand.NextDouble();
            if (prob < probability)
                return true;
            else
                return false;
        }

        /**
         * function rouletteChosen returns an indexes of elements that was randomly chosen 
         * by roulette of lenght equals to the part of circle = it's probability meaning
         */
        public static int[] rouletteChosenIndexes(double[] probabilities) 
        {
            double sumLength = probabilities.Sum(); // should be 1
            double[] rightBounds = new double[probabilities.Length];
            rightBounds[0] = probabilities[0];
            for (int i = 1; i < probabilities.Length; i++)
                rightBounds[i] = probabilities[i - 1] + probabilities[i];
            int[] chosenIndexes = new int[probabilities.Length];

            for (int k = 0; k < probabilities.Length; k++)
            {
                Random rand = new Random();

                double roulettePoint = rand.NextDouble();
                for (int i = 0; i < probabilities.Length; i++)
                    if (roulettePoint < rightBounds[i])
                    { // enter only once and go out
                        chosenIndexes[k] = i;
                        break;
                    }
            }
            return chosenIndexes;
        }

        public static void Shuffle(int[] arr)
        {
            Random rand = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }

        public static int ChooseRandomIndex(int indexArraySize)
        {
            var rand = new Random();
            return rand.Next(indexArraySize);
        }
        //public static Individ<Type>[] ChooseRandomIndivids(Individ<Type>[] individs, int probability, int amount = 2)
        //{
        //    List<Individ<Type>> chosenIndivids = new List<Individ<Type>>();
        //    while (individs.Count() < amount)
        //    {

        //    }
        //}
    }
}
