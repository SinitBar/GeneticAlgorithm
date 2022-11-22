using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    internal class Individ<T>
    {
        public int AmountOfGens 
        {
            get { return Gens.Length; }            
            private set { }
        }

        public T[] Gens;

        public Individ(int amountOfGens)
        {
            AmountOfGens = amountOfGens;
            Gens = new T[amountOfGens];
        }
        public Individ(T[] gens)
        {
            AmountOfGens = gens.Length;
            Gens = gens;
        }

    }
}
