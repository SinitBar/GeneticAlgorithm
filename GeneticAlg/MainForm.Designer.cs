namespace GeneticAlg
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVariables = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxZCoding = new System.Windows.Forms.CheckBox();
            this.checkBoxRCoding = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLowerLimitVariables = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUpperLimitVariables = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPopulationSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCodingAccuracy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxBitMutationProbability = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxGenMutationProbability = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxCrossingoverTypeZ = new System.Windows.Forms.ComboBox();
            this.comboBoxCrossingoverTypeR = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxSelectionType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.labelL = new System.Windows.Forms.Label();
            this.textBoxL = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxP0 = new System.Windows.Forms.TextBox();
            this.labelP0 = new System.Windows.Forms.Label();
            this.textBoxLambda = new System.Windows.Forms.TextBox();
            this.labelLambda = new System.Windows.Forms.Label();
            this.textBoxCrossingoverProbability = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxEpsilon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAmountOfGenerations = new System.Windows.Forms.TextBox();
            this.textBoxOutputZ = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxOutputR = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список переменных через пробел:";
            // 
            // textBoxVariables
            // 
            this.textBoxVariables.Location = new System.Drawing.Point(340, 51);
            this.textBoxVariables.Name = "textBoxVariables";
            this.textBoxVariables.Size = new System.Drawing.Size(380, 31);
            this.textBoxVariables.TabIndex = 1;
            this.textBoxVariables.Text = "x y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Функция:";
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Location = new System.Drawing.Point(128, 92);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(592, 31);
            this.textBoxFunction.TabIndex = 3;
            this.textBoxFunction.Text = "(x - 2)^4 + (x - 2*y)^2";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(514, 550);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(164, 48);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxZCoding
            // 
            this.checkBoxZCoding.AutoSize = true;
            this.checkBoxZCoding.Checked = true;
            this.checkBoxZCoding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZCoding.Location = new System.Drawing.Point(12, 305);
            this.checkBoxZCoding.Name = "checkBoxZCoding";
            this.checkBoxZCoding.Size = new System.Drawing.Size(281, 29);
            this.checkBoxZCoding.TabIndex = 5;
            this.checkBoxZCoding.Text = "Целочисленное кодирование";
            this.checkBoxZCoding.UseVisualStyleBackColor = true;
            this.checkBoxZCoding.CheckedChanged += new System.EventHandler(this.checkBoxZCoding_CheckedChanged);
            // 
            // checkBoxRCoding
            // 
            this.checkBoxRCoding.AutoSize = true;
            this.checkBoxRCoding.Checked = true;
            this.checkBoxRCoding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRCoding.Location = new System.Drawing.Point(638, 305);
            this.checkBoxRCoding.Name = "checkBoxRCoding";
            this.checkBoxRCoding.Size = new System.Drawing.Size(270, 29);
            this.checkBoxRCoding.TabIndex = 6;
            this.checkBoxRCoding.Text = "Вещественное кодирование";
            this.checkBoxRCoding.UseVisualStyleBackColor = true;
            this.checkBoxRCoding.CheckedChanged += new System.EventHandler(this.checkBoxRCoding_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(412, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Промежуток возможных значений переменных:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "[";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(703, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "]";
            // 
            // textBoxLowerLimitVariables
            // 
            this.textBoxLowerLimitVariables.Location = new System.Drawing.Point(459, 9);
            this.textBoxLowerLimitVariables.Name = "textBoxLowerLimitVariables";
            this.textBoxLowerLimitVariables.Size = new System.Drawing.Size(105, 31);
            this.textBoxLowerLimitVariables.TabIndex = 12;
            this.textBoxLowerLimitVariables.Text = "-5,12";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(570, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = ";";
            // 
            // textBoxUpperLimitVariables
            // 
            this.textBoxUpperLimitVariables.Location = new System.Drawing.Point(592, 9);
            this.textBoxUpperLimitVariables.Name = "textBoxUpperLimitVariables";
            this.textBoxUpperLimitVariables.Size = new System.Drawing.Size(105, 31);
            this.textBoxUpperLimitVariables.TabIndex = 14;
            this.textBoxUpperLimitVariables.Text = "5,11";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Размер популяции:";
            // 
            // textBoxPopulationSize
            // 
            this.textBoxPopulationSize.Location = new System.Drawing.Point(206, 142);
            this.textBoxPopulationSize.Name = "textBoxPopulationSize";
            this.textBoxPopulationSize.Size = new System.Drawing.Size(115, 31);
            this.textBoxPopulationSize.TabIndex = 16;
            this.textBoxPopulationSize.Text = "30";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Точность кодирования параметров:";
            // 
            // textBoxCodingAccuracy
            // 
            this.textBoxCodingAccuracy.Location = new System.Drawing.Point(340, 180);
            this.textBoxCodingAccuracy.Name = "textBoxCodingAccuracy";
            this.textBoxCodingAccuracy.Size = new System.Drawing.Size(115, 31);
            this.textBoxCodingAccuracy.TabIndex = 18;
            this.textBoxCodingAccuracy.Text = "0,01";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(285, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "Разрыв поколений Т (0 < T <= 1):";
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(340, 216);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(115, 31);
            this.textBoxT.TabIndex = 20;
            this.textBoxT.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 25);
            this.label10.TabIndex = 21;
            this.label10.Text = "Вероятность мутации бита:";
            // 
            // textBoxBitMutationProbability
            // 
            this.textBoxBitMutationProbability.Location = new System.Drawing.Point(425, 351);
            this.textBoxBitMutationProbability.Name = "textBoxBitMutationProbability";
            this.textBoxBitMutationProbability.Size = new System.Drawing.Size(116, 31);
            this.textBoxBitMutationProbability.TabIndex = 22;
            this.textBoxBitMutationProbability.Text = "0,1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(635, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(408, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "ε ((-ε; ε) Диапазон изменения гена при мутации):";
            // 
            // textBoxGenMutationProbability
            // 
            this.textBoxGenMutationProbability.Location = new System.Drawing.Point(1050, 404);
            this.textBoxGenMutationProbability.Name = "textBoxGenMutationProbability";
            this.textBoxGenMutationProbability.Size = new System.Drawing.Size(116, 31);
            this.textBoxGenMutationProbability.TabIndex = 30;
            this.textBoxGenMutationProbability.Text = "0,5";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(635, 407);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(232, 25);
            this.label15.TabIndex = 29;
            this.label15.Text = "Вероятность мутации гена:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 460);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(174, 25);
            this.label16.TabIndex = 31;
            this.label16.Text = "Тип кроссинговера:";
            // 
            // comboBoxCrossingoverTypeZ
            // 
            this.comboBoxCrossingoverTypeZ.FormattingEnabled = true;
            this.comboBoxCrossingoverTypeZ.Items.AddRange(new object[] {
            "Одноточечный",
            "Двухточечный",
            "Равномерный"});
            this.comboBoxCrossingoverTypeZ.Location = new System.Drawing.Point(359, 452);
            this.comboBoxCrossingoverTypeZ.Name = "comboBoxCrossingoverTypeZ";
            this.comboBoxCrossingoverTypeZ.Size = new System.Drawing.Size(182, 33);
            this.comboBoxCrossingoverTypeZ.TabIndex = 32;
            this.comboBoxCrossingoverTypeZ.SelectedIndexChanged += new System.EventHandler(this.comboBoxCrossingoverTypeZ_SelectedIndexChanged);
            // 
            // comboBoxCrossingoverTypeR
            // 
            this.comboBoxCrossingoverTypeR.FormattingEnabled = true;
            this.comboBoxCrossingoverTypeR.Items.AddRange(new object[] {
            "Двухточечный",
            "Арифметический",
            "BLX-alpha"});
            this.comboBoxCrossingoverTypeR.Location = new System.Drawing.Point(983, 452);
            this.comboBoxCrossingoverTypeR.Name = "comboBoxCrossingoverTypeR";
            this.comboBoxCrossingoverTypeR.Size = new System.Drawing.Size(182, 33);
            this.comboBoxCrossingoverTypeR.TabIndex = 34;
            this.comboBoxCrossingoverTypeR.SelectedIndexChanged += new System.EventHandler(this.comboBoxCrossingoverTypeR_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(635, 455);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(174, 25);
            this.label17.TabIndex = 33;
            this.label17.Text = "Тип кроссинговера:";
            // 
            // comboBoxSelectionType
            // 
            this.comboBoxSelectionType.FormattingEnabled = true;
            this.comboBoxSelectionType.Items.AddRange(new object[] {
            "Рулетка",
            "Усечение",
            "Турнир"});
            this.comboBoxSelectionType.Location = new System.Drawing.Point(192, 260);
            this.comboBoxSelectionType.Name = "comboBoxSelectionType";
            this.comboBoxSelectionType.Size = new System.Drawing.Size(182, 33);
            this.comboBoxSelectionType.TabIndex = 36;
            this.comboBoxSelectionType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectionType_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 263);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(157, 25);
            this.label18.TabIndex = 35;
            this.label18.Text = "Способ селекции:";
            // 
            // labelL
            // 
            this.labelL.AutoSize = true;
            this.labelL.Location = new System.Drawing.Point(410, 263);
            this.labelL.Name = "labelL";
            this.labelL.Size = new System.Drawing.Size(268, 25);
            this.labelL.TabIndex = 37;
            this.labelL.Text = "Размер турнира t (2 <= t <= 5):";
            // 
            // textBoxL
            // 
            this.textBoxL.Location = new System.Drawing.Point(684, 262);
            this.textBoxL.Name = "textBoxL";
            this.textBoxL.Size = new System.Drawing.Size(115, 31);
            this.textBoxL.TabIndex = 38;
            this.textBoxL.Text = "2";
            // 
            // textBoxP0
            // 
            this.textBoxP0.Location = new System.Drawing.Point(425, 497);
            this.textBoxP0.Name = "textBoxP0";
            this.textBoxP0.Size = new System.Drawing.Size(115, 31);
            this.textBoxP0.TabIndex = 40;
            this.textBoxP0.Text = "0,5";
            // 
            // labelP0
            // 
            this.labelP0.AutoSize = true;
            this.labelP0.Location = new System.Drawing.Point(12, 503);
            this.labelP0.Name = "labelP0";
            this.labelP0.Size = new System.Drawing.Size(335, 25);
            this.labelP0.TabIndex = 39;
            this.labelP0.Text = "Вероятность обмена p0 (0 <= p0 <= 1):";
            // 
            // textBoxLambda
            // 
            this.textBoxLambda.Location = new System.Drawing.Point(1051, 497);
            this.textBoxLambda.Name = "textBoxLambda";
            this.textBoxLambda.Size = new System.Drawing.Size(115, 31);
            this.textBoxLambda.TabIndex = 42;
            this.textBoxLambda.Text = "0,5";
            // 
            // labelLambda
            // 
            this.labelLambda.AutoSize = true;
            this.labelLambda.Location = new System.Drawing.Point(638, 503);
            this.labelLambda.Name = "labelLambda";
            this.labelLambda.Size = new System.Drawing.Size(236, 25);
            this.labelLambda.TabIndex = 41;
            this.labelLambda.Text = "Множитель λ (0 <= λ <= 1):";
            // 
            // textBoxCrossingoverProbability
            // 
            this.textBoxCrossingoverProbability.Location = new System.Drawing.Point(426, 404);
            this.textBoxCrossingoverProbability.Name = "textBoxCrossingoverProbability";
            this.textBoxCrossingoverProbability.Size = new System.Drawing.Size(115, 31);
            this.textBoxCrossingoverProbability.TabIndex = 44;
            this.textBoxCrossingoverProbability.Text = "0,8";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 407);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(408, 25);
            this.label19.TabIndex = 43;
            this.label19.Text = "Вероятность Кроссинговера Pc: (0.6 <= Pc <= 1):";
            // 
            // textBoxEpsilon
            // 
            this.textBoxEpsilon.Location = new System.Drawing.Point(1049, 351);
            this.textBoxEpsilon.Name = "textBoxEpsilon";
            this.textBoxEpsilon.Size = new System.Drawing.Size(116, 31);
            this.textBoxEpsilon.TabIndex = 45;
            this.textBoxEpsilon.Text = "0,5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(531, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 25);
            this.label12.TabIndex = 46;
            this.label12.Text = "Количество поколений:";
            // 
            // textBoxAmountOfGenerations
            // 
            this.textBoxAmountOfGenerations.Location = new System.Drawing.Point(742, 203);
            this.textBoxAmountOfGenerations.Name = "textBoxAmountOfGenerations";
            this.textBoxAmountOfGenerations.Size = new System.Drawing.Size(115, 31);
            this.textBoxAmountOfGenerations.TabIndex = 47;
            this.textBoxAmountOfGenerations.Text = "5";
            // 
            // textBoxOutputZ
            // 
            this.textBoxOutputZ.AcceptsReturn = true;
            this.textBoxOutputZ.AcceptsTab = true;
            this.textBoxOutputZ.Location = new System.Drawing.Point(128, 632);
            this.textBoxOutputZ.Multiline = true;
            this.textBoxOutputZ.Name = "textBoxOutputZ";
            this.textBoxOutputZ.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutputZ.Size = new System.Drawing.Size(412, 100);
            this.textBoxOutputZ.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 635);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 25);
            this.label13.TabIndex = 48;
            this.label13.Text = "Минимум:";
            // 
            // textBoxOutputR
            // 
            this.textBoxOutputR.AcceptsReturn = true;
            this.textBoxOutputR.AcceptsTab = true;
            this.textBoxOutputR.Location = new System.Drawing.Point(753, 632);
            this.textBoxOutputR.Multiline = true;
            this.textBoxOutputR.Name = "textBoxOutputR";
            this.textBoxOutputR.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutputR.Size = new System.Drawing.Size(412, 100);
            this.textBoxOutputR.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(637, 635);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 25);
            this.label14.TabIndex = 50;
            this.label14.Text = "Минимум:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.textBoxOutputR);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxOutputZ);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxAmountOfGenerations);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxEpsilon);
            this.Controls.Add(this.textBoxCrossingoverProbability);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBoxLambda);
            this.Controls.Add(this.labelLambda);
            this.Controls.Add(this.textBoxP0);
            this.Controls.Add(this.labelP0);
            this.Controls.Add(this.textBoxL);
            this.Controls.Add(this.labelL);
            this.Controls.Add(this.comboBoxSelectionType);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comboBoxCrossingoverTypeR);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboBoxCrossingoverTypeZ);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxGenMutationProbability);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxBitMutationProbability);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCodingAccuracy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPopulationSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUpperLimitVariables);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxLowerLimitVariables);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxRCoding);
            this.Controls.Add(this.checkBoxZCoding);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxFunction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxVariables);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Генетический алгоритм";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxVariables;
        private Label label2;
        private TextBox textBoxFunction;
        private Button buttonStart;
        private CheckBox checkBoxZCoding;
        private CheckBox checkBoxRCoding;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxLowerLimitVariables;
        private Label label7;
        private TextBox textBoxUpperLimitVariables;
        private Label label3;
        private TextBox textBoxPopulationSize;
        private Label label8;
        private TextBox textBoxCodingAccuracy;
        private Label label9;
        private TextBox textBoxT;
        private Label label10;
        private TextBox textBoxBitMutationProbability;
        private Label label11;
        private TextBox textBoxGenMutationProbability;
        private Label label15;
        private Label label16;
        private ComboBox comboBoxCrossingoverTypeZ;
        private ComboBox comboBoxCrossingoverTypeR;
        private Label label17;
        private ComboBox comboBoxSelectionType;
        private Label label18;
        private Label labelL;
        private TextBox textBoxL;
        private ToolTip toolTip1;
        private TextBox textBoxP0;
        private Label labelP0;
        private TextBox textBoxLambda;
        private Label labelLambda;
        private TextBox textBoxCrossingoverProbability;
        private Label label19;
        private TextBox textBoxEpsilon;
        private Label label12;
        private TextBox textBoxAmountOfGenerations;
        private TextBox textBoxOutputZ;
        private Label label13;
        private TextBox textBoxOutputR;
        private Label label14;
    }
}