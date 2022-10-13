using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_WinForm_Warcraft
{
    public partial class MainWindow : Form
    {
        Horde Thral = new Horde();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Thral.AddOrc(tbName.Text);

            tbName.Text = string.Empty;

            MessageBox.Show(Thral.Orcs.First().Name);
        }
    }
}
