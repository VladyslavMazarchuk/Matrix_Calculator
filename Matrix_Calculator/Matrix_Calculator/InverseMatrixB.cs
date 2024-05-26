using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class InverseMatrixB
    {
        public static void InverseMatrix(TextBox[,] matrixTextBoxesB, int rowCountB, int columnCountB, Panel panel)
        {
            try
            {

                if (rowCountB != columnCountB)
                {
                    MessageBox.Show("Матриця не є квадратною. Введіть квадратну матрицю.");
                    return;
                }

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

                double[,] inverseMatrixB = CalculateInverseMatrix(matrixB, rowsB, colsB);

                panel.Controls.Clear();
                for (int row = 0; row < rowsB; row++)
                {
                    for (int col = 0; col < colsB; col++)
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

                panel.Size = new Size(colsB * 55, rowsB * 25);
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