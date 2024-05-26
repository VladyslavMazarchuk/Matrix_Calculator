using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class MatrixOperations_Multiplication
    {
        public static void MultiplyMatrices(TextBox[,] matrixTextBoxes, TextBox[,] matrixTextBoxesB, int rowCount, int columnCount, int rowCountB, int columnCountB, Panel resultPanel)
        {
            try
            {
                int rowsA = rowCount;
                int colsA = columnCount;
                int rowsB = rowCountB;
                int colsB = columnCountB;

                if (colsA != rowsB)
                {
                    MessageBox.Show("Кількість стовпців у матриці A повинна дорівнювати кількості рядків у матриці B для множення.");
                    return;
                }

                double[,] result = new double[rowsA, colsB];

                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsB; j++)
                    {
                        double sum = 0;
                        for (int k = 0; k < colsA; k++)
                        {
                            double valueA, valueB;
                            if (!double.TryParse(matrixTextBoxes[i, k].Text, out valueA) || !double.TryParse(matrixTextBoxesB[k, j].Text, out valueB))
                            {
                                MessageBox.Show("Невірні дані в матрицях. Введіть дійсні числові значення.");
                                return;
                            }
                            sum += valueA * valueB;
                        }
                        result[i, j] = sum;
                    }
                }

                DisplayResultMatrixInPanel(result, rowsA, colsB, resultPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Під час множення матриці сталася помилка: {ex.Message}");
            }
        }

        private static void DisplayResultMatrixInPanel(double[,] matrix, int rows, int columns, Panel panel)
        {
            panel.Controls.Clear();

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    var textBox = new TextBox
                    {
                        Width = 50,
                        Height = 20,
                        Location = new Point(column * 55, row * 25),
                        Text = matrix[row, column].ToString()
                    };

                    panel.Controls.Add(textBox);
                }
            }

            panel.Size = new Size(columns * 55, rows * 25);
        }
    }
}