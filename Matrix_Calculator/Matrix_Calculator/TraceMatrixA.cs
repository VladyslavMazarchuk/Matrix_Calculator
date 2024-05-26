using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class TraceMatrixA
    {
        public static void CalculateTraceA(TextBox[,] matrixTextBoxes, int rowCount, int columnCount, Panel panel)
        {
            try
            {
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

                double traceA = CalculateTrace(matrixA);

                panel.Controls.Clear();

                var textBox = new TextBox
                {
                    Width = 150,
                    Height = 20,
                    Location = new Point(0, 0),
                    Text = $"{traceA}"
                };
                panel.Controls.Add(textBox);

                panel.Size = new Size(150, 25);
            }
            catch
            {
                MessageBox.Show($"Під час розрахунку сліду матриці сталася помилка: матриця має бути квадратною!");
            }
        }

        private static double CalculateTrace(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double trace = 0;

            for (int i = 0; i < n; i++)
            {
                trace += matrix[i, i];
            }

            return trace;
        }
    }
}