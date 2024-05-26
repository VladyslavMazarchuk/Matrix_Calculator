using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class MatrixTransposition_B
    {
        public static void MatrixTranspositionB(TextBox[,] matrixTextBoxesB, int rowCountB, int columnCountB, Panel panel)
        {
            try
            {
                int rowsB = rowCountB;
                int colsB = columnCountB;

                double[,] matrixB = new double[rowsB, colsB];
                for (int row = 0; row < rowsB; row++)
                {
                    for (int col = 0; col < colsB; col++)
                    {
                        double value;
                        if (!double.TryParse(matrixTextBoxesB[row, col].Text, out value))
                        {
                            MessageBox.Show("Некоректні дані у матриці B. Введіть дійсні числові значення.");
                            return;
                        }
                        matrixB[row, col] = value;
                    }
                }

                double[,] transposedMatrixB = CalculateTransposeMatrix(matrixB, rowsB, colsB);

                panel.Controls.Clear();
                for (int row = 0; row < colsB; row++)
                {
                    for (int col = 0; col < rowsB; col++)
                    {
                        var textBox = new TextBox
                        {
                            Width = 50,
                            Height = 20,
                            Location = new Point(col * 55, row * 25), 
                            Text = transposedMatrixB[row, col].ToString("0.###")
                        };
                        panel.Controls.Add(textBox);
                    }
                }
                panel.Size = new Size(rowsB * 55, colsB * 25);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Під час знаходження транспонованої матриці сталася помилка: {ex.Message}");
            }
        }

        private static double[,] CalculateTransposeMatrix(double[,] matrix, int rows, int cols)
        {
            double[,] transposedMatrix = new double[cols, rows];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    transposedMatrix[col, row] = matrix[row, col];
                }
            }

            return transposedMatrix;
        }
    }
}