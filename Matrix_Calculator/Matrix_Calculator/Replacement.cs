using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class Replacement
    {
        public void SwapMatrices(Button button, Panel panel5, Panel panel6)
        {
            try
            {
                SwapMatrices(panel5, panel6);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при зміні матриць: {ex.Message}");
            }
        }

        public void SwapMatrices(Panel panel5, Panel panel6)
        {
            double[,] matrixA = GetMatrixValuesFromPanel(panel5);
            double[,] matrixB = GetMatrixValuesFromPanel(panel6);

            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                MessageBox.Show("Матриці повинні мати однакові розміри для заміни.");
                return;
            }

            SetMatrixValuesToPanel(matrixB, panel5);
            SetMatrixValuesToPanel(matrixA, panel6);
        }

        private double[,] GetMatrixValuesFromPanel(Panel panel)
        {
            int rows = panel.Controls.Count / GetNumberOfColumns(panel.Controls);
            int cols = GetNumberOfColumns(panel.Controls);
            double[,] matrix = new double[rows, cols];

            int index = 0;
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    double value = 0;
                    if (!string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        if (!double.TryParse(textBox.Text, out value))
                        {
                            MessageBox.Show("Невірні дані в матриці. Введіть дійсні числові значення.");
                            
                        }
                    }
                    int row = index / cols;
                    int col = index % cols;
                    matrix[row, col] = value;
                    index++;
                }
            }

            return matrix;
        }

        private void SetMatrixValuesToPanel(double[,] matrix, Panel panel)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int index = 0;
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    int row = index / cols;
                    int col = index % cols;
                    textBox.Text = matrix[row, col].ToString();
                    index++;
                }
            }
        }

        private int GetNumberOfColumns(Control.ControlCollection controls)
        {
            int textBoxCount = controls.OfType<TextBox>().Count();
            return textBoxCount / controls.Count;
        }
    }
}