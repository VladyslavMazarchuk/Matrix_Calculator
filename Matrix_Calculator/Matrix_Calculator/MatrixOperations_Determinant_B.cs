using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class MatrixOperations_Determinant_B
    {
        public static void MatricesDeterminantB(TextBox[,] matrixTextBoxesB, int rowCountB, int columnCountB, Panel panel)
        {
            try
            {
                int rowsB = rowCountB;
                int colsB = columnCountB;

                if (rowCountB != columnCountB)
                {
                    MessageBox.Show("Матриця не є квадратною. Введіть квадратну матрицю.");
                    return;
                }

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

                double determinant = CalculateDeterminant(matrixB, rowsB);

                panel.Controls.Clear();
                var textBox = new TextBox
                {
                    Width = 100,
                    Height = 20,
                    Location = new Point(0, 0),
                    Text = determinant.ToString()
                };
                panel.Controls.Add(textBox);
            }
            catch
            {
                MessageBox.Show($"Під час обчислення визначника матриці сталася помилка: матриця має бути квадратною!");
            }
        }
        private static double CalculateDeterminant(double[,] matrix, int size)
        {
            if (size == 1)
            {
                return matrix[0, 0];
            }
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double determinant = 0;
                int sign = 1;

                for (int i = 0; i < size; i++)
                {
                    double[,] subMatrix = new double[size - 1, size - 1];
                    for (int j = 1; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (k < i)
                            {
                                subMatrix[j - 1, k] = matrix[j, k];
                            }
                            else if (k > i)
                            {
                                subMatrix[j - 1, k - 1] = matrix[j, k];
                            }
                        }
                    }

                    determinant += sign * matrix[0, i] * CalculateDeterminant(subMatrix, size - 1);
                    sign = -sign;
                }

                return determinant;
            }
        }
    }
}