using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Matrix_Calculator
{
    public partial class MainPage : Form
    {
        private ColorManager colorManager;
        private TextBox[,] matrixTextBoxes;
        private TextBox[,] matrixTextBoxesB;
        private int rowCount = 1;
        private int columnCount = 1;
        private int rowCountB = 1;
        private int columnCountB = 1;

        private MatrixClearer matrixClearer = new MatrixClearer();
        private Replacement matrixSwapper = new Replacement();

        public MainPage()
        {
            InitializeComponent();
            colorManager = new ColorManager(this, NameMatrixA_label, NameMatrixB_label, Result_label, Size_label1, Size_label2, label6, label7);

            SilverToolStripMenuItem.Click += colorManager.SilverToolStripMenuItem_Click;
            RedToolStripMenuItem.Click += colorManager.RedToolStripMenuItem_Click;
            OrangeToolStripMenuItem.Click += colorManager.OrangeToolStripMenuItem_Click;
            YellowToolStripMenuItem.Click += colorManager.BlueToolStripMenuItem_Click;
            GreenToolStripMenuItem.Click += colorManager.GreenToolStripMenuItem_Click;
            StandartToolStripMenuItem.Click += colorManager.StandartToolStripMenuItem_Click;


            InitializeMatrixTextBoxesA();
            ResizeMatrixA();
            numericUpDown_ColumnsA.Minimum = 1;
            numericUpDown_ColumnsA.Maximum = 5;
            numericUpDown_RowsA.Minimum = 1;
            numericUpDown_RowsA.Maximum = 5;
            numericUpDown_ColumnsA.Value = rowCount;
            numericUpDown_RowsA.Value = columnCount;
            numericUpDown_ColumnsA.ValueChanged += NumericUpDownRows_ValueChanged;
            numericUpDown_RowsA.ValueChanged += NumericUpDownColumns_ValueChanged;


            InitializeMatrixTextBoxesB();
            ResizeMatrixB();
            numericUpDown_ColumnsB.Minimum = 1;
            numericUpDown_ColumnsB.Maximum = 5;
            numericUpDown_RowsB.Minimum = 1;
            numericUpDown_RowsB.Maximum = 5;
            numericUpDown_ColumnsB.ValueChanged += NumericUpDownRowsB_ValueChanged;
            numericUpDown_RowsB.ValueChanged += NumericUpDownColumnsB_ValueChanged;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameMatrixA_label.Text = "Matrix A:";
            NameMatrixB_label.Text = "Matrix B:";
            Result_label.Text = "Answer:";
            Size_label1.Text = "Size";
            Size_label2.Text = "Size";
            Button_DeterminantA.Text = "Determinant";
            Button_DeterminantB.Text = "Determinant";
            Button_InverseMatrixB.Text = "Inverse";
            Button_InverseMatrixA.Text = "Inverse";
            Button_TranspositionB.Text = "Transpone";
            Button_TranspositionA.Text = "Transpone";
            Button_RankB.Text = "Find the rank";
            Button_RankA.Text = "Find the rank";
            Button_DisplayLU_A.Text = "LU mapping";
            Button_DisplayLU_B.Text = "LU mapping";
            Button_TraceA.Text = "Trace matrix";
            Button_TraceB.Text = "Trace matrix";
            Button_MultiplyBy_A.Text = "Multiply by:";
            Button_MultiplyBy_B.Text = "Multiply by:";
            Button_ExponentiationA.Text = "Raise to the power:";
            Button_ExponentiationB.Text = "Raise to the power:";
            OperationsToolStripMenuItem.Text = "Operations";
            SettingsToolStripMenuItem.Text = "Settings";
            clearAllToolStripMenuItem.Text = "Clear all";
            ClearMatrixAToolStripMenuItem.Text = "Clear Matrix A";
            ClearMatrixBToolStripMenuItem.Text = "Clear Matrix B";
            ClearMatrixResultToolStripMenuItem.Text = "Clear Answer";
            ColorToolStripMenuItem.Text = "Background";
            LanguageToolStripMenuItem.Text = "Language";
            SilverToolStripMenuItem.Text = "Silver";
            RedToolStripMenuItem.Text = "Red";
            OrangeToolStripMenuItem.Text = "Orange";
            GreenToolStripMenuItem.Text = "Green";
            YellowToolStripMenuItem.Text = "Blue";
            StandartToolStripMenuItem.Text = "White";
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameMatrixA_label.Text = "Matrice A:";
            NameMatrixB_label.Text = "Matrice B:";
            Result_label.Text = "Réponse:";
            Size_label1.Text = "Taille";
            Size_label2.Text = "Taille";
            Button_MultiplyBy_A.Text = "Multiplier par:";
            Button_MultiplyBy_B.Text = "Multiplier par:";
            Button_ExponentiationA.Text = "Élever à la puissance:";
            Button_ExponentiationB.Text = "Élever à la puissance:";
            Button_DeterminantA.Text = "Déterminant";
            Button_DeterminantB.Text = "Déterminant";
            Button_InverseMatrixB.Text = "Inverse";
            Button_InverseMatrixA.Text = "Inverse";
            Button_TranspositionB.Text = "Transposer";
            Button_TranspositionA.Text = "Transposer";
            Button_RankB.Text = "Trouver le rang";
            Button_RankA.Text = "Trouver le rang";
            Button_DisplayLU_A.Text = "Mappage LU";
            Button_DisplayLU_B.Text = "Mappage LU";
            Button_TraceB.Text = "Matrice de trace";
            Button_TraceB.Text = "Matrice de trace";
            OperationsToolStripMenuItem.Text = "Opérations";
            SettingsToolStripMenuItem.Text = "Paramètres";
            clearAllToolStripMenuItem.Text = "Tout effacer";
            ClearMatrixAToolStripMenuItem.Text = "Effacer la matrice A";
            ClearMatrixBToolStripMenuItem.Text = "Effacer la matrice B";
            ClearMatrixResultToolStripMenuItem.Text = "Réponse claire";
            ColorToolStripMenuItem.Text = "Arrière-plan";
            LanguageToolStripMenuItem.Text = "Langue";
            SilverToolStripMenuItem.Text = "Argent";
            RedToolStripMenuItem.Text = "Rouge";
            OrangeToolStripMenuItem.Text = "Orange";
            GreenToolStripMenuItem.Text = "Vert";
            YellowToolStripMenuItem.Text = "Bleu";
            StandartToolStripMenuItem.Text = "Blanc";
        }

        private void italianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameMatrixA_label.Text = "Matrice A:";
            NameMatrixB_label.Text = "Matrice B:";
            Result_label.Text = "Risposta:";
            Size_label1.Text = "Dimensione";
            Size_label2.Text = "Dimensione";
            Button_MultiplyBy_B.Text = "Moltiplica per:";
            Button_MultiplyBy_B.Text = "Moltiplica per:";
            Button_ExponentiationA.Text = "Elevato alla potenza:";
            Button_ExponentiationB.Text = "Elevato alla potenza:";
            Button_DeterminantA.Text = "Determinante";
            Button_DeterminantB.Text = "Determinante";
            Button_InverseMatrixB.Text = "Inversa";
            Button_InverseMatrixA.Text = "Inversa";
            Button_TranspositionB.Text = "Trasposta";
            Button_TranspositionA.Text = "Trasposta";
            Button_RankB.Text = "Trova il rango";
            Button_RankA.Text = "Trova il rango";
            Button_DisplayLU_A.Text = "Mappatura LU";
            Button_DisplayLU_B.Text = "Mappatura LU";
            Button_TraceA.Text = "Traccia matrice";
            Button_TraceB.Text = "Traccia matrice";
            OperationsToolStripMenuItem.Text = "Operazioni";
            SettingsToolStripMenuItem.Text = "Impostazioni";
            clearAllToolStripMenuItem.Text = "Cancella tutto";
            ClearMatrixAToolStripMenuItem.Text = "Cancella Matrice A";
            ClearMatrixBToolStripMenuItem.Text = "Cancella Matrice B";
            ClearMatrixResultToolStripMenuItem.Text = "Risposta chiara";
            ColorToolStripMenuItem.Text = "Sfondo";
            LanguageToolStripMenuItem.Text = "Lingua";
            SilverToolStripMenuItem.Text = "Argento";
            RedToolStripMenuItem.Text = "Rosso";
            OrangeToolStripMenuItem.Text = "Arancione";
            GreenToolStripMenuItem.Text = "Verde";
            YellowToolStripMenuItem.Text = "Blu";
            StandartToolStripMenuItem.Text = "Bianco";
        }

        private void polishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameMatrixA_label.Text = "Macierz A:";
            NameMatrixB_label.Text = "Macierz B:";
            Result_label.Text = "Odpowiedź:";
            Size_label1.Text = "Rozmiar";
            Size_label2.Text = "Rozmiar";
            Button_MultiplyBy_A.Text = "Pomnóż przez:";
            Button_MultiplyBy_B.Text = "Pomnóż przez:";
            Button_ExponentiationA.Text = "Podnieś do potęgi:";
            Button_ExponentiationB.Text = "Podnieś do potęgi:";
            Button_DeterminantA.Text = "Wyznacznik";
            Button_DeterminantB.Text = "Wyznacznik";
            Button_InverseMatrixB.Text = "Odwrotność";
            Button_InverseMatrixA.Text = "Odwrotność";
            Button_TranspositionB.Text = "Transponuj";
            Button_TranspositionA.Text = "Transponuj";
            Button_RankB.Text = "Znajdź rangę";
            Button_RankA.Text = "Znajdź rangę";
            Button_DisplayLU_A.Text = "Mapowanie LU";
            Button_DisplayLU_B.Text = "Mapowanie LU";
            Button_TraceA.Text = "Macierz śledzenia";
            Button_TraceB.Text = "Macierz śledzenia";
            OperationsToolStripMenuItem.Text = "Operacje";
            SettingsToolStripMenuItem.Text = "Ustawienia";
            clearAllToolStripMenuItem.Text = "Wyczyść wszystko";
            ClearMatrixAToolStripMenuItem.Text = "Wyczyść macierz A";
            ClearMatrixBToolStripMenuItem.Text = "Wyczyść macierz B";
            ClearMatrixResultToolStripMenuItem.Text = "Wyraźna odpowiedź";
            ColorToolStripMenuItem.Text = "Tło";
            LanguageToolStripMenuItem.Text = "Język";
            SilverToolStripMenuItem.Text = "Srebrny";
            RedToolStripMenuItem.Text = "Czerwony";
            OrangeToolStripMenuItem.Text = "Pomarańczowy";
            GreenToolStripMenuItem.Text = "Zielony";
            YellowToolStripMenuItem.Text = "Niebieski";
            StandartToolStripMenuItem.Text = "Biały";
        }

        private void ukrainianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameMatrixA_label.Text = "Матриця A:";
            NameMatrixB_label.Text = "Матриця B:";
            Result_label.Text = "Відповідь:";
            Size_label1.Text = "Розмір:";
            Size_label2.Text = "Розмір:";
            Button_MultiplyBy_A.Text = "Помножити на:";
            Button_MultiplyBy_B.Text = "Помножити на:";
            Button_ExponentiationA.Text = "Піднести до степеню:";
            Button_ExponentiationB.Text = "Піднести до степеню:";
            Button_DeterminantA.Text = "Знайти визначник";
            Button_DeterminantB.Text = "Знайти визначник";
            Button_InverseMatrixB.Text = "Знайти зворотну";
            Button_InverseMatrixA.Text = "Знайти зворотну";
            Button_TranspositionB.Text = "Транспонувати";
            Button_TranspositionA.Text = "Транспонувати";
            Button_RankB.Text = "Знайти ранг";
            Button_RankA.Text = "Знайти ранг";
            Button_DisplayLU_A.Text = "Відображення LU";
            Button_DisplayLU_B.Text = "Відображення LU";
            Button_TraceA.Text = "Слід матриці";
            Button_TraceB.Text = "Слід матриці";
            OperationsToolStripMenuItem.Text = "Операції";
            SettingsToolStripMenuItem.Text = "Налаштування";
            clearAllToolStripMenuItem.Text = "Очистити все";
            ClearMatrixAToolStripMenuItem.Text = "Очистити матрицю A";
            ClearMatrixBToolStripMenuItem.Text = "Очистити матрицю B";
            ClearMatrixResultToolStripMenuItem.Text = "Очистити Відповідь";
            ColorToolStripMenuItem.Text = "Фон";
            LanguageToolStripMenuItem.Text = "Мова";
            SilverToolStripMenuItem.Text = "Сріий";
            RedToolStripMenuItem.Text = "Червоний";
            OrangeToolStripMenuItem.Text = "Помаранчевий";
            GreenToolStripMenuItem.Text = "Зелений";
            YellowToolStripMenuItem.Text = "Блакитний";
            StandartToolStripMenuItem.Text = "Білий";
        }
        private void InitializeMatrixTextBoxesA()
        {
            matrixTextBoxes = new TextBox[rowCount, columnCount];
            DisplayMatrixA_panel.Controls.Clear();

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    var textBox = new TextBox
                    {
                        Width = 50,
                        Height = 20,
                        Text = " ",
                        Location = new Point(column * 55, row * 25)
                    };

                    matrixTextBoxes[row, column] = textBox;
                    DisplayMatrixA_panel.Controls.Add(textBox);
                }
            }
            DisplayMatrixA_panel.Size = new Size(columnCount * 55, rowCount * 25);

            initialPanel7Location = OperationMatrixA_panel.Location;
        }
        private void ResizeMatrixA()
        {
            string[,] values = new string[rowCount, columnCount];
            for (int row = 0; row < Math.Min(matrixTextBoxes.GetLength(0), rowCount); row++)
            {
                for (int column = 0; column < Math.Min(matrixTextBoxes.GetLength(1), columnCount); column++)
                {
                    values[row, column] = matrixTextBoxes[row, column].Text;
                }
            }

            InitializeMatrixTextBoxesA();

            for (int row = 0; row < Math.Min(matrixTextBoxes.GetLength(0), rowCount); row++)
            {
                for (int column = 0; column < Math.Min(matrixTextBoxes.GetLength(1), columnCount); column++)
                {
                    matrixTextBoxes[row, column].Text = values[row, column];
                }
            }

            DisplayMatrixA_panel.Size = new Size(columnCount * 55, rowCount * 25);


        }
        private Point initialPanel7Location;

        private void NumericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            rowCount = (int)numericUpDown_ColumnsA.Value;
            ResizeMatrixA();
        }

        private void NumericUpDownColumns_ValueChanged(object sender, EventArgs e)
        {
            columnCount = (int)numericUpDown_RowsA.Value;
            ResizeMatrixA();
        }
        private void InitializeMatrixTextBoxesB()
        {
            matrixTextBoxesB = new TextBox[rowCountB, columnCountB];
            DisplayMatrixB_panel.Controls.Clear();

            for (int row = 0; row < rowCountB; row++)
            {
                for (int column = 0; column < columnCountB; column++)
                {
                    var textBox = new TextBox
                    {
                        Width = 50,
                        Height = 20,
                        Text = " ",
                        Location = new Point(column * 55, row * 25)
                    };

                    matrixTextBoxesB[row, column] = textBox;
                    DisplayMatrixB_panel.Controls.Add(textBox);
                }
            }
            DisplayMatrixB_panel.Size = new Size(columnCountB * 55, rowCountB * 25);

            initialPanel8Location = OperationMatrixB_panel.Location;
        }
        private void ResizeMatrixB()
        {
            string[,] values = new string[rowCountB, columnCountB];
            for (int row = 0; row < Math.Min(matrixTextBoxesB.GetLength(0), rowCountB); row++)
            {
                for (int column = 0; column < Math.Min(matrixTextBoxesB.GetLength(1), columnCountB); column++)
                {
                    values[row, column] = matrixTextBoxesB[row, column].Text;
                }
            }

            InitializeMatrixTextBoxesB();

            for (int row = 0; row < Math.Min(matrixTextBoxesB.GetLength(0), rowCountB); row++)
            {
                for (int column = 0; column < Math.Min(matrixTextBoxesB.GetLength(1), columnCountB); column++)
                {
                    matrixTextBoxesB[row, column].Text = values[row, column];
                }
            }

            DisplayMatrixB_panel.Size = new Size(columnCountB * 55, rowCountB * 25);
        }
        private Point initialPanel8Location;

        private void NumericUpDownRowsB_ValueChanged(object sender, EventArgs e)
        {
            rowCountB = (int)numericUpDown_ColumnsB.Value;
            ResizeMatrixB();
        }

        private void NumericUpDownColumnsB_ValueChanged(object sender, EventArgs e)
        {
            columnCountB = (int)numericUpDown_RowsB.Value;
            ResizeMatrixB();
        }

        private void Button_Replacement_Click(object sender, EventArgs e)
        {
            matrixSwapper.SwapMatrices(DisplayMatrixA_panel, DisplayMatrixB_panel);
        }

        private void Button_Multiplication_Click(object sender, EventArgs e)
        {
            MatrixOperations_Multiplication.MultiplyMatrices(matrixTextBoxes, matrixTextBoxesB, rowCount, columnCount, rowCountB, columnCountB, result_panel);
        }

        private void Button_Addition_Click(object sender, EventArgs e)
        {
            MatrixOperations.AddMatrices(matrixTextBoxes, matrixTextBoxesB, rowCount, columnCount, rowCountB, columnCountB, result_panel);
        }

        private void Button_Subtraction_Click(object sender, EventArgs e)
        {
            MatrixOperations_Subtraction.SubtractMatrices(matrixTextBoxes, matrixTextBoxesB, rowCount, columnCount, rowCountB, columnCountB, result_panel);
        }
        private void Button_DeterminantA_Click(object sender, EventArgs e)
        {
            MatrixOperations_Determinant_A.MatricesDeterminantA(matrixTextBoxes, rowCount, columnCount, result_panel);
        }
        private void Button_DeterminantB_Click(object sender, EventArgs e)
        {
            MatrixOperations_Determinant_B.MatricesDeterminantB(matrixTextBoxesB, rowCountB, columnCountB, result_panel);
        }
        private void Button_InverseMatrixA_Click(object sender, EventArgs e)
        {
            InverseMatrixA.InverseMatrix(matrixTextBoxes, rowCount, columnCount, result_panel);
        }
        private void Button_InverseMatrixB_Click(object sender, EventArgs e)
        {
            InverseMatrixB.InverseMatrix(matrixTextBoxesB, rowCountB, columnCountB, result_panel);
        }
        private void Button_TranspositionB_Click(object sender, EventArgs e)
        {
            MatrixTransposition_B.MatrixTranspositionB(matrixTextBoxesB, rowCountB, columnCountB, result_panel);
        }
        private void Button_TranspositionA_Click(object sender, EventArgs e)
        {
            MatrixTransposition_A.MatrixTranspositionA(matrixTextBoxes, rowCount, columnCount, result_panel);
        }
        private void Button_RankB_Click(object sender, EventArgs e)
        {
            MatrixRank_B.CalculateMatrixRank(matrixTextBoxesB, rowCountB, columnCountB, result_panel);
        }
        private void Button_RankA_Click(object sender, EventArgs e)
        {
            MatrixRank_A.CalculateMatrixRank(matrixTextBoxes, rowCount, columnCount, result_panel);
        }
        private void Button_DisplayLU_A_Click(object sender, EventArgs e)
        {
            LUDecompositionMatrixA.CalculateLU_A(matrixTextBoxes, rowCount, columnCount, result_panel);
        }
        private void Button_DisplayLU_B_Click(object sender, EventArgs e)
        {
            LUDecompositionMatrixB.CalculateLU_B(matrixTextBoxesB, rowCountB, columnCountB, result_panel);
        }
        private void Button_MultiplyBy_A_Click(object sender, EventArgs e)
        {
            MultiplyMatrixA.MultiplyMatrix(matrixTextBoxes, rowCount, columnCount, textBox19, result_panel);
        }

        private void Button_MultiplyBy_B_Click(object sender, EventArgs e)
        {
            MultiplyMatrixB.MultiplyMatrix(matrixTextBoxesB, rowCountB, columnCountB, textBox21, result_panel);
        }
        private void Button_ExponentiationA_Click(object sender, EventArgs e)
        {
            ExponentiationMatrixA.ExpMatrixA(matrixTextBoxes, rowCount, columnCount, textBox20, result_panel);
        }
        private void Button_ExponentiationB_Click(object sender, EventArgs e)
        {
            ExponentiationMatrixB.ExpMatrixB(matrixTextBoxesB, rowCountB, columnCountB, textBox22, result_panel);
        }
        private void Button_TraceA_Click(object sender, EventArgs e)
        {
            TraceMatrixA.CalculateTraceA(matrixTextBoxes, rowCount, columnCount, result_panel);
        }
        private void Button_TraceB_Click(object sender, EventArgs e)
        {
            TraceMatrixB.CalculateTraceB(matrixTextBoxesB, rowCountB, columnCountB, result_panel);
        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrixClearer.ClearAll(DisplayMatrixA_panel, DisplayMatrixB_panel, result_panel);
        }

        private void ClearMatrixAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrixClearer.ClearMatrixA(DisplayMatrixA_panel);
        }

        private void ClearMatrixBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrixClearer.ClearMatrixB(DisplayMatrixB_panel);
        }

        private void ClearMatrixResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrixClearer.ClearMatrixResult(result_panel);
        }
    }
}