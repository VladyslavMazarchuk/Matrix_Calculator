using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class InverseMatrixA
    {
        public static void InverseMatrix(TextBox[,] matrixTextBoxes, int rowCount, int columnCount, Panel panel)
        {
            try
            {
                if (rowCount != columnCount)
                {
                    MessageBox.Show("Матриця не є квадратною. Введіть квадратну матрицю.");
                    return;
                }
                
                int rowsA = rowCount;
                int colsA = columnCount;

                double[,] matrixA = new double[rowsA, colsA];
                for (int row = 0; row < rowsA; row++)
                {
                    for (int col = 0; col < colsA; col++)
                    {
                        double value;
                        if (!double.TryParse(matrixTextBoxes[row, col].Text, out value))
                        {
                            MessageBox.Show("Некоректні дані у матриці A. Введіть дійсні числові значення.");
                            return;
                        }
                        matrixA[row, col] = value;
                    }
                }

                double[,] inverseMatrixB = CalculateInverseMatrix(matrixA, rowsA, colsA);

                panel.Controls.Clear();
                for (int row = 0; row < rowsA; row++)
                {
                    for (int col = 0; col < colsA; col++)
                    {
                        var textBox = new TextBox
                        {
                            Width = 50,
                            Height = 20,
                            Location = new Point(col * 55, row * 25),
                            Text = inverseMatrixB[row, col].ToString("0.###")
                        };
                        panel.Controls.Add(textBox);
                    }
                }

                panel.Size = new Size(colsA * 55, rowsA * 25);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Під час обчислення зворотної матриці сталася помилка: {ex.Message}");
            }
        }

        private static double[,] CalculateInverseMatrix(double[,] matrix, int rows, int cols)
        {
            double[,] augmentedMatrix = new double[rows, cols * 2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    augmentedMatrix[row, col] = matrix[row, col];
                    augmentedMatrix[row, col + cols] = (row == col) ? 1 : 0;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                double pivot = augmentedMatrix[row, row];
                for (int col = 0; col < cols * 2; col++)
                {
                    augmentedMatrix[row, col] /= pivot;
                }

                for (int i = 0; i < rows; i++)
                {
                    if (i != row)
                    {
                        double factor = augmentedMatrix[i, row];
                        for (int j = 0; j < cols * 2; j++)
                        {
                            augmentedMatrix[i, j] -= factor * augmentedMatrix[row, j];
                        }
                    }
                }
            }

            double[,] inverseMatrix = new double[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    inverseMatrix[row, col] = augmentedMatrix[row, col + cols];
                }
            }

            return inverseMatrix;
        }
    }
}