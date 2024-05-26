using System.Drawing;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

internal class MatrixTransposition_A
{
    public static void MatrixTranspositionA(TextBox[,] matrixTextBoxes, int rowCount, int columnCount, Panel panel)
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
                        return;
                    }
                    matrixA[row, col] = value;
                }
            }

            double[,] transposedMatrixA = CalculateTransposeMatrix(matrixA, rowsA, colsA);

            panel.Controls.Clear();
            for (int row = 0; row < colsA; row++)
            {
                for (int col = 0; col < rowsA; col++)
                {
                    var textBox = new TextBox
                    {
                        Width = 50,
                        Height = 20,
                        Location = new Point(col * 55, row * 25),
                        Text = transposedMatrixA[row, col].ToString("0.###")
                    };
                    panel.Controls.Add(textBox);
                }
            }

            panel.Size = new Size(rowsA * 55, colsA * 25);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Під час знаходження транспонованої матриці сталася помилка: {ex.Message}");
        }
    }

    private static double[,] CalculateTransposeMatrix(double[,] matrix, int rows, int cols)
    {
        double[,] transposedMatrix = new double[cols, rows];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                transposedMatrix[col, row] = matrix[row, col];
            }
        }

        return transposedMatrix;
    }
}