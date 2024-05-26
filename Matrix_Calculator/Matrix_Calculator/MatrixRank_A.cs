using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Calculator
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class MatrixRank_A
    {
        public static int CalculateMatrixRank(TextBox[,] matrixTextBoxes, int rowCount, int columnCount, Panel panel)
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
                            MessageBox.Show("Некоректні дані у матриці А. Введіть дійсні числові значення.");
                            return -1;
                        }
                        matrixA[row, col] = value;
                    }
                }

                int rank = CalculateRank(matrixA, rowsA, colsA);

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