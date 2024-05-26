using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class MatrixRank_B
    {
        public static int CalculateMatrixRank(TextBox[,] matrixTextBoxesB, int rowCountB, int columnCountB, Panel panel)
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
                            return -1; 
                        }
                        matrixB[row, col] = value;
                    }
                }

                int rank = CalculateRank(matrixB, rowsB, colsB);

                panel.Controls.Clear();
                var textBox = new TextBox
                {
                    Text = $"{rank}",
                    Location = new Point(0, 0),
                    AutoSize = true
                };
                panel.Controls.Add(textBox);

                return rank;
            }
            catch
            {
                MessageBox.Show($"Під час знаходження рангу матриці сталася помилка: матриця має бути квадратною!");
                return -1; 
            }
        }

        private static int CalculateRank(double[,] matrix, int rows, int cols)
        {
            int rank = 0;
            double[,] matrixCopy = new double[rows, cols];
            Array.Copy(matrix, matrixCopy, matrix.Length);

            for (int row = 0; row < rows; row++)
            {
                int nonzeroRow = -1;
                for (int i = row; i < rows; i++)
                {
                    if (Math.Abs(matrixCopy[i, row]) > double.Epsilon)
                    {
                        nonzeroRow = i;
                        break;
                    }
                }

                if (nonzeroRow == -1)
                {
                    continue;
                }

                SwapRows(matrixCopy, row, nonzeroRow);

              
                for (int i = row + 1; i < rows; i++)
                {
                    double factor = matrixCopy[i, row] / matrixCopy[row, row];
                    for (int j = row; j < cols; j++)
                    {
                        matrixCopy[i, j] -= matrixCopy[row, j] * factor;
                    }
                }

                rank++;
            }

            return rank;
        }

        private static void SwapRows(double[,] matrix, int row1, int row2)
        {
            int cols = matrix.GetLength(1);
            for (int col = 0; col < cols; col++)
            {
                double temp = matrix[row1, col];
                matrix[row1, col] = matrix[row2, col];
                matrix[row2, col] = temp;
            }
        }
    }
}