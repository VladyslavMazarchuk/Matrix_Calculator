using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
        internal class LUDecompositionMatrixA
        {
            public static void CalculateLU_A(TextBox[,] matrixTextBoxes, int rowCount, int columnCount, Panel panel)
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

                    double[,] matrixL, matrixU;
                    LUDecompose(matrixA, out matrixL, out matrixU);

                    panel.Controls.Clear();

                    int rowsL = matrixL.GetLength(0);
                    int colsL = matrixL.GetLength(1);
                    for (int row = 0; row < rowsL; row++)
                    {
                        for (int col = 0; col < colsL; col++)
                        {
                            var textBox = new TextBox
                            {
                                Width = 50,
                                Height = 20,
                                Location = new Point(col * 55, row * 25),
                                Text = matrixL[row, col].ToString("0.###")
                            };
                            panel.Controls.Add(textBox);
                        }
                    }

                    int rowsU = matrixU.GetLength(0);
                    int colsU = matrixU.GetLength(1);
                    for (int row = 0; row < rowsU; row++)
                    {
                        for (int col = 0; col < colsU; col++)
                        {
                            var textBox = new TextBox
                            {
                                Width = 50,
                                Height = 20,
                                Location = new Point((col + colsL) * 55, row * 25),
                                Text = matrixU[row, col].ToString("0.###")
                            };
                            panel.Controls.Add(textBox);
                        }
                    }

                    panel.Size = new Size((colsL + colsU) * 55, Math.Max(rowsL, rowsU) * 25);
                }
                catch
                {
                    MessageBox.Show($"Під час розрахунку LU-розкладу сталася помилка: матриця має бути квадратною!");
                }
            }

            private static void LUDecompose(double[,] matrixA, out double[,] matrixL, out double[,] matrixU)
            {
                int n = matrixA.GetLength(0);

                matrixL = new double[n, n];
                matrixU = new double[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int k = i; k < n; k++)
                    {
                        double sum = 0;
                        for (int j = 0; j < i; j++)
                        {
                            sum += matrixL[i, j] * matrixU[j, k];
                        }
                        matrixU[i, k] = matrixA[i, k] - sum;
                    }

                    for (int k = i; k < n; k++)
                    {
                        if (i == k)
                        {
                            matrixL[i, i] = 1;
                        }
                        else
                        {
                            double sum = 0;
                            for (int j = 0; j < i; j++)
                            {
                                sum += matrixL[k, j] * matrixU[j, i];
                            }
                            matrixL[k, i] = (matrixA[k, i] - sum) / matrixU[i, i];
                        }
                    }
                }
            }
        }
    }