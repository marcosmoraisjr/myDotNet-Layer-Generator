using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Gerador.Library
{
    public partial class FormProcessando : Form
    {
        public String _titulo
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public String _texto
        {
            get { return label1.Text; }
            set { this.label1.Text = value; }
        }
        public ProgressBar ProgressBar
        {
            get { return this.progressBar1; }
            set { this.progressBar1 = value; }
        }

        public FormProcessando()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " " + Application.ProductVersion;
        }
 
        
        /***OPERAÇÃO COM PROGRESSBAR INICIO*/
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe),
                    new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }
        private void ProgressBarStart(ProgressBar pb)
        {
            progressBar1.Visible = true;
            //label1.Text = aviso;
            SetControlPropertyThreadSafe(pb, "Visible", true);
            SetControlPropertyThreadSafe(pb, "Style", ProgressBarStyle.Marquee);
            SetControlPropertyThreadSafe(pb, "MarqueeAnimationSpeed", 10);
        }
        private void ProgressBarStop(ProgressBar pb)
        {
            SetControlPropertyThreadSafe(pb, "Style", ProgressBarStyle.Blocks);
            SetControlPropertyThreadSafe(pb, "MarqueeAnimationSpeed", 0);
            SetControlPropertyThreadSafe(pb, "Visible", false);
        }
        /***OPERAÇÃO COM PROGRESSBAR FIM*/

        public void FormProgressBar_Load(object sender, EventArgs e)
        {
            if (_texto.ToString().Trim().Length > 1)
            {
                label1.Text = _texto.ToString();
            }
            this.ProgressBarStart(progressBar1);
        }
        public void FormProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ProgressBarStop(progressBar1);
        }
    }
}
