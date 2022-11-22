using GeneticAlg.GeneticAlg;
using static GeneticAlg.GeneticAlg.Enums;

namespace GeneticAlg
{
    public partial class MainForm : Form
    {
        bool executeR = true;
        bool executeZ = true;

        int AmountOfGenerations = 5;

        int PopulationSize;
        string FitnessFunction; // fitness function f, objective function
        string[] Variables; // variables used in fitness function
        selectionMethods SelectionMethod;
        double CodingAccuracy;
        double UpperLimitVariable;
        double LowerLimitVariable;
        double CrossingoverProbability;

        // mutation for Z is for bit, for R is for gen
        double MutationProbabilityZ; 
        double MutationProbabilityR;

        double L; // for truncate selection, when chosen ignores T

        double T; // generation gap (if = 1 -> all new)

        int TournamentSize;

        crossingoverTypeR CrossingoverTypeR;

        double Lambda = 0.5; // parametr for arifmetically crossingover

        double Alpha = 0.5; // parametr for BLX-alpha crossingover

        double Epsilon = 0.5; // parameter for mutation (interval for delta is from - Epsilon to + Epsilon)
        
        Enums.crossingoverTypeZ CrossingoverTypeZ;

        double P0; // probability of taking bit in uniform crossingover

        double Pm; // probability of mutation of every bit in the gen
        public MainForm()
        {
            InitializeComponent();

            SelectionMethod = Enums.selectionMethods.Tournament;
            comboBoxSelectionType.SelectedIndex = (int)Enums.selectionMethods.Tournament;
            CrossingoverTypeZ = Enums.crossingoverTypeZ.TwoPointed;
            comboBoxCrossingoverTypeZ.SelectedIndex = (int)Enums.crossingoverTypeZ.TwoPointed;
            CrossingoverTypeR = Enums.crossingoverTypeR.Arifmetically;
            comboBoxCrossingoverTypeR.SelectedIndex = (int)Enums.crossingoverTypeR.Arifmetically;

            textBoxP0.Visible = false;
            labelP0.Visible = false;

        }

        private void GetVariables()
        {
            List<string> variables = new List<string>();
            variables.Clear();
            string[] vars = textBoxVariables.Text.Split(" ", GeneticAlgorithm<int>.MaxVariablesAmount + 1);
            for(int i = 0; i < Math.Min(vars.Length, GeneticAlgorithm<int>.MaxVariablesAmount); i++)
                variables.Add(vars[i]);
            Variables = variables.ToArray();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // replace dots to semicolons in text strings if needed
            textBoxLowerLimitVariables.Text = textBoxLowerLimitVariables.Text.Replace('.', ',');
            textBoxUpperLimitVariables.Text = textBoxUpperLimitVariables.Text.Replace('.', ',');
            textBoxCodingAccuracy.Text = textBoxCodingAccuracy.Text.Replace('.', ',');
            textBoxT.Text = textBoxT.Text.Replace('.', ',');
            if (SelectionMethod == Enums.selectionMethods.Truncation)
                textBoxL.Text = textBoxL.Text.Replace('.', ',');
            textBoxBitMutationProbability.Text = textBoxBitMutationProbability.Text.Replace('.', ',');
            textBoxCrossingoverProbability.Text = textBoxCrossingoverProbability.Text.Replace('.', ',');
            textBoxP0.Text = textBoxP0.Text.Replace('.', ',');
            textBoxEpsilon.Text = textBoxEpsilon.Text.Replace('.', ',');
            textBoxGenMutationProbability.Text = textBoxGenMutationProbability.Text.Replace('.', ',');
            textBoxLambda.Text = textBoxLambda.Text.Replace('.', ',');

            // read all general parameters
            try 
            {
                LowerLimitVariable = double.Parse(textBoxLowerLimitVariables.Text);
                UpperLimitVariable = double.Parse(textBoxUpperLimitVariables.Text);
                GetVariables();
                FitnessFunction = textBoxFunction.Text;
                PopulationSize = int.Parse(textBoxPopulationSize.Text);
                CodingAccuracy = double.Parse(textBoxCodingAccuracy.Text);
                AmountOfGenerations = int.Parse(textBoxAmountOfGenerations.Text);
                T = double.Parse(textBoxT.Text);

                if (SelectionMethod == selectionMethods.Tournament)
                    TournamentSize = int.Parse(textBoxL.Text);
                else if (SelectionMethod == selectionMethods.Truncation)
                    L = double.Parse(textBoxL.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Some general parametrs are wrong!", "Error occured", MessageBoxButtons.OK);
            }
            if (executeZ)
            {
                // read parameters for Z algorithm
                textBoxOutputZ.Text = "";
                try 
                {
                    MutationProbabilityZ = double.Parse(textBoxBitMutationProbability.Text);
                    CrossingoverProbability = double.Parse(textBoxCrossingoverProbability.Text);
                    P0 = double.Parse(textBoxP0.Text);
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Some parametrs for Z algorithm are wrong!", "Error occured", MessageBoxButtons.OK);
                }
                GeneticAlgorithmZ alg = new GeneticAlgorithmZ(PopulationSize, FitnessFunction,
                    Variables, SelectionMethod, LowerLimitVariable, UpperLimitVariable, CodingAccuracy,
                    MutationProbabilityZ, CrossingoverProbability, CrossingoverTypeZ, L, T, TournamentSize, P0, Pm);
                Individ<int> solutionZ = alg.Execute(AmountOfGenerations);
                double[] answer = new double[Variables.Length];
                for (int i = 0; i < solutionZ.AmountOfGens; i++)
                {
                    answer[i] = alg.FromZToR(solutionZ.Gens[i]);
                    textBoxOutputZ.AppendText(Variables[i] + "= " + answer[i] + System.Environment.NewLine);
                }
            }
            if (executeR)
            {
                textBoxOutputR.Text = "";
                // read parameters for R algorithm
                try
                {
                    Epsilon = double.Parse(textBoxEpsilon.Text);
                    MutationProbabilityR = double.Parse(textBoxGenMutationProbability.Text);

                    if (CrossingoverTypeR == crossingoverTypeR.Arifmetically)
                        Lambda = double.Parse(textBoxLambda.Text);
                    else if (CrossingoverTypeR == crossingoverTypeR.BlxAlpha)
                        Alpha = double.Parse(textBoxLambda.Text);
                }
                catch
                {
                    MessageBox.Show("Some parametrs for R algorithm are wrong!", "Error occured", MessageBoxButtons.OK);
                }
                GeneticAlgorithmR alg = new GeneticAlgorithmR(PopulationSize, FitnessFunction,
                    Variables, SelectionMethod, LowerLimitVariable, UpperLimitVariable, CodingAccuracy,
                    MutationProbabilityR, CrossingoverProbability, CrossingoverTypeR, L, T, TournamentSize, Lambda, Alpha, Epsilon);
                Individ<double> solutionR = alg.Execute(AmountOfGenerations);
                for (int i = 0; i < solutionR.AmountOfGens; i++)
                    textBoxOutputR.AppendText(Variables[i] + "= " + solutionR.Gens[i] + System.Environment.NewLine);
            }
        }

        private void comboBoxSelectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelectionType.SelectedIndex == (int)selectionMethods.Truncation)
            {
                labelL.Text = "Порог отсечения l (0 < l < 1):";
                textBoxL.Text = "0.5";
                labelL.Visible = true;
                textBoxL.Visible = true;
                SelectionMethod = selectionMethods.Truncation;
            }
            else if (comboBoxSelectionType.SelectedIndex == (int)selectionMethods.Tournament)
            {
                labelL.Text = "Размер турнира t (2 <= t <= 5):";
                textBoxL.Text = "2";
                labelL.Visible = true;
                textBoxL.Visible = true;
                SelectionMethod = selectionMethods.Tournament;

            }
            else
            {
                labelL.Visible = false;
                textBoxL.Visible = false;
                SelectionMethod = selectionMethods.Roulette;
            }
        }

        private void comboBoxCrossingoverTypeZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCrossingoverTypeZ.SelectedIndex == (int)crossingoverTypeZ.Uniform)
            {
                textBoxP0.Visible = true;
                labelP0.Visible = true;
                CrossingoverTypeZ = crossingoverTypeZ.Uniform;
            }
            else
            {
                textBoxP0.Visible = false;
                labelP0.Visible = false;
                if (comboBoxCrossingoverTypeZ.SelectedIndex == (int)crossingoverTypeZ.OnePointed)
                    CrossingoverTypeZ = crossingoverTypeZ.OnePointed;
                else
                    CrossingoverTypeZ = crossingoverTypeZ.TwoPointed;
            }
        }

        private void comboBoxCrossingoverTypeR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCrossingoverTypeR.SelectedIndex == (int)crossingoverTypeR.Arifmetically)
            {
                labelLambda.Text = "Множитель λ (0 <= λ <= 1):";
                textBoxLambda.Visible = true;
                labelLambda.Visible = true;
                CrossingoverTypeR = crossingoverTypeR.Arifmetically;
            }
            else if (comboBoxCrossingoverTypeR.SelectedIndex == (int)crossingoverTypeR.BlxAlpha)
            {
                labelLambda.Text = "Множитель α:";
                textBoxLambda.Visible = true;
                labelLambda.Visible = true;
                CrossingoverTypeR = crossingoverTypeR.BlxAlpha;
            }
            else
            {
                textBoxLambda.Visible = false;
                labelLambda.Visible = false;
                CrossingoverTypeR = crossingoverTypeR.TwoPointed;
            }
        }

        private void checkBoxZCoding_CheckedChanged(object sender, EventArgs e)
        {
            executeZ = checkBoxZCoding.Checked;
        }

        private void checkBoxRCoding_CheckedChanged(object sender, EventArgs e)
        {
            executeR = checkBoxRCoding.Checked;
        }

    }
}