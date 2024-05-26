using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class ExponentiationMatrixB
    {
            public static void ExpMatrixB(TextBox[,] matrixTextBoxesB, int rowCount, int columnCount, TextBox textBox22, Panel panel)
            {
                try
                {
                    int rowsB = rowCount;
                    int colsB = columnCount;

                    int exponent;
                    if (!int.TryParse(textBox22.Text, out exponent))
                    {
                        MessageBox.Show("Некоректне число степеня. Введіть ціле число.");
                        return;
                    }

                    double[,] matrixA = new double[rowsB, colsB];
                    for (int row = 0; row < rowsB; row++)
                    {
                        for (int col = 0; col < colsB; col++)
                        {
                            double value;
                            if (!double.TryParse(matrixTextBoxesB[row, col].Text, out value))
                            {
                                MessageBox.Show("Некоректні дані у матриці A. Введіть дійсні числові значення.");
                                return;
                            }
                            matrixA[row, col] = value;
                        }
                    }

                    double[,] poweredMatrixA = PowerMatrix(matrixA, rowsB, colsB, exponent);

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
                                Text = poweredMatrixA[row, col].ToString("0.###")
                            };
                            panel.Controls.Add(textBox);
                        }
                    }

                    panel.Size = new Size(colsB * 55, rowsB * 25);
                }
                catch 
                {
                    MessageBox.Show($"Під час піднесення матриці до степеня сталася помилка: матриця має бути квадратною!");
                }
            }

            private static double[,] PowerMatrix(double[,] matrix, int rows, int cols, int exponent)
            {
                if (exponent == 0)
                {
                    return CreateIdentityMatrix(rows, cols);
                }
                else if (exponent == 1)
                {
                    return matrix;
                }
                else
                {
                    double[,] result = matrix;
                    for (int i = 2; i <= exponent; i++)
                    {
                        result = MultiplyMatrices(result, matrix, rows, cols);
                    }
                    return result;
                }
            }

            private static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2, int rows, int cols)
            {
                double[,] result = new double[rows, cols];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            result[row, col] += matrix1[row, k] * matrix2[k, col];
                        }
                    }
                }
                return result;
            }

            private static double[,] CreateIdentityMatrix(int rows, int cols)
            {
                double[,] identityMatrix = new double[rows, cols];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        identityMatrix[row, col] = (row == col) ? 1 : 0;
                    }
                }
                return identityMatrix;
            }
        }
    }