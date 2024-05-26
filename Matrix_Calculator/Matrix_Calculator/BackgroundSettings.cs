using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Calculator
{
    public class ColorManager
    {
        private Control control;
        private List<Label> labels;

        public ColorManager(Control control, params Label[] labels)
        {
            this.control = control;
            this.labels = labels.ToList();
        }

        public void SetColor(Color color)
        {
            control.BackColor = color;

            if (color == Color.Yellow)
            {
                foreach (var label in labels)
                {
                    label.ForeColor = Color.Blue;
                }
            }
            else
            {
                foreach (var label in labels)
                {
                    label.ForeColor = SystemColors.ControlText;
                }
            }
        }

        public void SilverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetColor(Color.Silver);
        }

        public void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetColor(Color.Red);
        }

        public void OrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetColor(Color.Orange);
        }

        public void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetColor(Color.Yellow);
        }

        public void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetColor(Color.Green);
        }
        public void StandartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetColor(Color.White);
        }
    }
}