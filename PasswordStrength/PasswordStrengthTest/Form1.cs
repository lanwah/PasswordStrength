using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordStrengthTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int nLevel = 0;
            if (int.TryParse(this.textBox1.Text, out nLevel))
            {
                this.passwordStrength1.CurrentPasswordLevel = nLevel;
            }
        }
    }
}
