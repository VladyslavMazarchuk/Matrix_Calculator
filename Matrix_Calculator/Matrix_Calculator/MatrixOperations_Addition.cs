using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    public class MatrixOperations
    {
        public static void AddMatrices(TextBox[,] matrixTextBoxes, TextBox[,] matrixTextBoxesB, int rowCount, int columnCount, int rowCountB, int columnCountB, Panel resultPanel)
        {
            try
            {
                int rowsA = rowCount;
                int colsA = columnCount;
                int rowsB = rowCountB;
                int colsB = columnCountB;

                if (rowsA != rowsB || colsA != colsB)
                {
                    MessageBox.Show("Матриці повинні мати однакові розміри для додавання.");
                    return;
                }

                double[,] result = new double[rowsA, colsA];

                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsA; j++)
                    {
                        double valueA, valueB;
                        if (!double.TryParse(matrixTextBoxes[i, j].Text, out valueA) || !double.TryParse(matrixTextBoxesB[i, j].Text, out valueB))
                        {
                            MessageBox.Show("Невірні дані в матрицях. Введіть дійсні числові значення.");
                            return;
                        }
                        result[i, j] = valueA + valueB;
                    }
                }

                DisplayResultMatrixInPanel(result, rowsA, colsA, resultPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Під час додавання матриць сталася помилка: {ex.Message}");
            }
        }

        private static void DisplayResultMatrixInPanel(double[,] matrix, int rows, int columns, Panel panel)
        {
            panel.Controls.Clear();

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    var textBox = new TextBox
                    {
                        Width = 50,
                        Height = 20,
                        Location = new Point(column * 55, row * 25),
                        Text = matrix[row, column].ToString()
                    };

                    panel.Controls.Add(textBox);
                }
            }

            panel.Size = new Size(columns * 55, rows * 25);
        }
    }
}