using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class TraceMatrixB
    {
        public static void CalculateTraceB(TextBox[,] matrixTextBoxesB, int rowCountB, int columnCountB, Panel panel)
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

                double traceB = CalculateTrace(matrixB);

                panel.Controls.Clear();

                var textBox = new TextBox
                {
                    Width = 150,
                    Height = 20,
                    Location = new Point(0, 0),
                    Text = $"{traceB}"
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