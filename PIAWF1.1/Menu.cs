using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIAWF1._1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnBateo_Click(object sender, EventArgs e)
        {
            Bateo ventana = new Bateo();
            ventana.Show();
            this.Hide();
        }

        private void btnPitcheo_Click(object sender, EventArgs e)
        {
            Pitcheo ventana = new Pitcheo();
            ventana.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
