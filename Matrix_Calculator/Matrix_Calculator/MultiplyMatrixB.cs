using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class MultiplyMatrixB
    {
        public static void MultiplyMatrix(TextBox[,] matrixTextBoxes, int rowCountB, int columnCountB, TextBox textbox21, Panel panel)
        {
            try
            {
                int rowsB = rowCountB;
                int colsB = columnCountB;

                double multiplier;
                if (!double.TryParse(textbox21.Text, out multiplier))
                {
                    MessageBox.Show("Некоректне число для множення. Введіть дійсне числове значення.");
                    return;
                }

                double[,] matrixB = new double[rowsB, colsB];
                for (int row = 0; row < rowsB; row++)
                {
                    for (int col = 0; col < colsB; col++)
                    {
                        double value;
                        if (!double.TryParse(matrixTextBoxes[row, col].Text, out value))
                        {
                            MessageBox.Show("Некоректні дані у матриці А. Введіть дійсні числові значення.");
                            return;
                        }
                        matrixB[row, col] = value;
                    }
                }

                double[,] multipliedMatrixB = MultiplyMatrixByScalar(matrixB, rowsB, colsB, multiplier);

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
                            Text = multipliedMatrixB[row, col].ToString("0.###")
                        };
                        panel.Controls.Add(textBox);
                    }
                }
                panel.Size = new Size(colsB * 55, rowsB * 25);
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