using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gerador
{
    public partial class FormSaibaMais : Form
    {
        public FormSaibaMais()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " " + Application.ProductVersion;
        }

        private void FormSaibaMais_Load(object sender, EventArgs e)
        {

        }
    }
}
