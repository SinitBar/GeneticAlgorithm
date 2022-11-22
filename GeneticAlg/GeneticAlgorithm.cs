using NoStringEvaluating.Models.Values;
using NoStringEvaluating;
using GeneticAlg.GeneticAlg;

namespace GeneticAlg
{
    internal abstract class GeneticAlgorithm<Type>
    {
        public Population<Type> CurrentPopulation;

        public static readonly int MaxVariablesAmount = 10;
        public int PopulationSize { get; private set; }
        public string FitnessFunction { get; private set; } // fitness function f, objective function
        public string[] Variables { get; private set; } // variables used in fitness function
        public Enums.selectionMethods SelectionMethod { get; private set; }
        public double CodingAccuracy { get; private set; }
        public double UpperLimitVariable { get; private set; }
        public double LowerLimitVariable { get; private set; }
        public double CrossingoverProbability { get; private set; }
        public double MutationProbability { get; private set; } // for Z is for bit, for R is for gen

        double L; // for truncate selection, when chosen ignores T

        public double T; // generation gap (if = 1 -> all new)

        int TournamentSize; 

        public GeneticAlgorithm(int populationSize, string fitness,
    string[] variables, Enums.selectionMethods selectionMethod,
    double lowerLimitVariable, double upperLimitVariable, 
    double codingAccuracy, double crossingoverProbability, double mutationProbability, 
    double l, double t, int tournamentSize)
        {
            FitnessFunction = fitness;
            Variables = variables;
            PopulationSize = populationSize;
            SelectionMethod = selectionMethod;
            LowerLimitVariable = lowerLimitVariable;
            UpperLimitVariable = upperLimitVariable;
            CodingAccuracy = codingAccuracy;
            CrossingoverProbability = crossingoverProbability;
            MutationProbability = mutationProbability;
            L = l;
            T = t;
            TournamentSize = tournamentSize;
        }

        public abstract double[] GetFitnesses();

        public void SortPopulationByFitness(Population<Type> population, double[] fitnesses)
        {
            population.SortIndividsByFitnessDesc(fitnesses);
        }

        // Norma returns the sum of squares of coordinates of the vector
        double Norma(double[] vector)
        {
            double norma = 0;
            for (int i = 0; i < vector.Length; i++)
                norma += vector[i] * vector[i];
            return norma;
        }
 
        public List<Individ<Type>> RouletteSelection(Population<Type> population, double[] fitnesses) 
        {
            double sumFitness = Norma(fitnesses); // avoid zero and negative numbers
            double[] p_i = new double[fitnesses.Length];
            List<Individ<Type>> chosenIndivids = new List<Individ<Type>>();

            for (int i = 0; i < fitnesses.Length; i++)
                p_i[i] = 1 - fitnesses[i] * fitnesses[i] / sumFitness; // the less value should be more probable, so take 1 - value, not  just value
                // sum of p_i = 1 in the end

            int[] individIndexes = RandomAndProbabilityFunctions.rouletteChosenIndexes(p_i);

            for (int i = 0; i < fitnesses.Length; i++)
                chosenIndivids.Add(population.Individs[individIndexes[i]]);

            return chosenIndivids;
        }

        public List<Individ<Type>> TruncateSelection(Population<Type> population, double[] fitnesses)
        {
            SortPopulationByFitness(population, fitnesses);

            int newSize = (int)Math.Round(fitnesses.Length * L);

            return population.Individs.Take(newSize).ToList();
        }

        public void RenewPopulation()
        {
            List<Individ<Type>> population = new List<Individ<Type>>();
            var children = FormChildren(); // takes into account T
            population.AddRange(children);
            population.AddRange(CurrentPopulation.Individs.Take(PopulationSize - children.Count));
            CurrentPopulation = new Population<Type>(population, LowerLimitVariable, UpperLimitVariable);
        }

        public List<Individ<Type>> FormChildren()
        {
            int amountOfChildren = (int)(PopulationSize * T);
            int amountOfParents = (int)(PopulationSize * (1 - T));

            if (amountOfChildren + amountOfParents != PopulationSize)
                amountOfChildren++;

            List<Individ<Type>> parents = SelectIndividsToCross(CurrentPopulation);

            List<Individ<Type>> children = new List<Individ<Type>>();

            // cross individs from selection while childrens amount != needed amount of childrens
            while (children.Count < amountOfChildren)
            {
                int i = RandomAndProbabilityFunctions.ChooseRandomIndex(parents.Count);
                int j = RandomAndProbabilityFunctions.ChooseRandomIndex(parents.Count);
                var rand = new Random();
                if (CrossingoverProbability > rand.NextDouble())
                {
                    if (typeof(Type) == typeof(int))
                    {
                        Individ<int> child1;
                        Individ<int> child2;
                        (this as GeneticAlgorithmZ).Crossingover(
                            (parents[i] as Individ<int>),
                            (parents[j] as Individ<int>), 
                            out child1, out child2);

                        children.Add(child1 as Individ<Type>);
                        if (children.Count < amountOfChildren)
                            children.Add(child2 as Individ<Type>);
                    }
                    else
                    {
                        Individ<double> child1;
                        Individ<double> child2;
                        (this as GeneticAlgorithmR).Crossingover(
                            (parents[i] as Individ<double>),
                            (parents[j] as Individ<double>),
                            out child1, out child2);

                        children.Add(child1 as Individ<Type>);
                        if (children.Count < amountOfChildren)
                            children.Add(child2 as Individ<Type>);
                    }
                }
                else
                {
                    children.Add(parents[i]);
                    if (children.Count < amountOfChildren)
                        children.Add(parents[j]);
                }
            }

            return children;
        }

        public List<Individ<Type>> SelectIndividsToCross(Population<Type> population)
        {

            List<Individ<Type>> newGeneration = new List<Individ<Type>>();

            switch ((int)SelectionMethod) {

                case (int)Enums.selectionMethods.Roulette:
                    newGeneration.AddRange(RouletteSelection(
                        population, GetFitnesses()));
                    break;

                case (int)Enums.selectionMethods.Truncation:
                    newGeneration.AddRange(TruncateSelection(population, GetFitnesses()));
                    break;

                default: // tournament
                    newGeneration.AddRange(TournamentSelection(population));
                    break;
            }
            return newGeneration;
        }

        // takes CurrentPopulation and mutate individs with mutation probability
        public void Mutation()
        {
            foreach(var individ in CurrentPopulation.Individs)
            {
                if (typeof(Type) == typeof(int))
                    (this as GeneticAlgorithmZ).Mutate(individ as Individ<int>);
                else
                    (this as GeneticAlgorithmR).Mutate(individ as Individ<double>);
            }
        }

        public Individ<Type> PickBestFitnessedIndivid(List<Individ<Type>> individs)
        {
            int index = 0;
            double bestFitness = 0;
            Individ<Type> bestIndivid = individs[0];
            var vars = new Dictionary<string, EvaluatorValue>();
            NoStringEvaluator evaluator = NoStringEvaluator.CreateFacade().Evaluator;
            do
            {
                vars.Clear();
                for (int i = 0; i < Variables.Length; i++)
                {
                    double value = 0;
                    if (typeof(Type) == typeof(int))
                        value = (this as GeneticAlgorithmZ).FromZToR((individs[index] as Individ<int>).Gens[i]);
                    else if (typeof(Type) == typeof(double))
                        value = (individs[index] as Individ<double>).Gens[i];
                    vars.Add(Variables[i], value);
                }
                double currentFitness = evaluator.CalcNumber(FitnessFunction, vars);
                if (index == 0 || currentFitness < bestFitness)
                {
                    bestFitness = currentFitness;
                    bestIndivid = individs[index];
                }
                index++;
            } while (index < individs.Count);
            return bestIndivid;
        }

        public List<Individ<Type>> TournamentSelection(Population<Type> population)
        {
            int size = (T == 0) ? PopulationSize : (int)(T * PopulationSize);
            List<Individ<Type>> chosenIndivids = new List<Individ<Type>>(size);
            for (int i = 0; i < size; i++)
            {
                List<Individ<Type>> participants =
                    population.ChooseRandomIndivids(TournamentSize);
                chosenIndivids.Add(PickBestFitnessedIndivid(participants));
            }
            return chosenIndivids;
        }

        public Individ<Type> Execute(int amountOfGenerations)
        {
            for (int i = 0; i < amountOfGenerations; i++)
            {
                RenewPopulation(); // includes selection and crossingover
                Mutation();
            }
            // here current population includes best solution
            return PickBestFitnessedIndivid(CurrentPopulation.Individs.ToList());
        }
    }
}
