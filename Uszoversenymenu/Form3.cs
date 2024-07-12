using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uszoversenymenu
{
    public partial class Form3 : Form
    {
        private string keszito;
        public Form3(string keszito)
        {
            InitializeComponent();
            this.keszito = keszito;
        }

        private void NevjegyForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Készítette:" + keszito;
        }
    }
}
