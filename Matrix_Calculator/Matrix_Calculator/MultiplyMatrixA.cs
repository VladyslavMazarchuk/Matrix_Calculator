using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

        namespace Matrix_Calculator
        {
            internal class MultiplyMatrixA
            {
                public static void MultiplyMatrix(TextBox[,] matrixTextBoxes, int rowCount, int columnCount, TextBox textbox19, Panel panel)
                {
                    try
                    {
                        int rowsA = rowCount;
                        int colsA = columnCount;

                        double multiplier;
                        if (!double.TryParse(textbox19.Text, out multiplier))
                        {
                            MessageBox.Show("Некоректне число для множення. Введіть дійсне числове значення.");
                            return;
                        }

                        double[,] matrixA = new double[rowsA, colsA];
                        for (int row = 0; row < rowsA; row++)
                        {
                            for (int col = 0; col < colsA; col++)
                            {
                                double value;
                                if (!double.TryParse(matrixTextBoxes[row, col].Text, out value))
                                {
                                    MessageBox.Show("Некоректні дані у матриці А. Введіть дійсні числові значення.");
                                    return;
                                }
                                matrixA[row, col] = value;
                            }
                        }

                        double[,] multipliedMatrixA = MultiplyMatrixByScalar(matrixA, rowsA, colsA, multiplier);

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
                                    Text = multipliedMatrixA[row, col].ToString("0.###")
                                };
                                panel.Controls.Add(textBox);
                            }
                        }
                        panel.Size = new Size(colsA * 55, rowsA * 25);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Під час множення матриці сталася помилка: {ex.Message}");
                    }
                }

                private static double[,] MultiplyMatrixByScalar(double[,] matrix, int rows, int cols, double scalar)
                {
                    double[,] result = new double[rows, cols];
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            result[row, col] = matrix[row, col] * scalar;
                        }
                    }
                    return result;
                }
            }
        }