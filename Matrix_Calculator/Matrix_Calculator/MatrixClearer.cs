using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    internal class MatrixClearer
    {
        public void ClearAll(Panel panel5, Panel panel6, Panel panel9)
        {
            ClearMatrix(panel5);
            ClearMatrix(panel6);
            ClearMatrix(panel9);
        }

        public void ClearMatrixA(Panel panel5)
        {
            ClearMatrix(panel5);
        }

        public void ClearMatrixB(Panel panel6)
        {
            ClearMatrix(panel6);
        }

        public void ClearMatrixResult(Panel panel9)
        {

            ClearMatrix(panel9);
        }

        private void ClearMatrix(Panel panel)
        {

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }
    }
}