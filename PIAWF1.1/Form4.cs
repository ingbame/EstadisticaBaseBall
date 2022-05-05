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
    public partial class Pitcheo : Form
    {
        public Pitcheo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtEntLanzadas.Text == "" || txtHitsPerm.Text == "" || txtCarrerasPerm.Text == "" ||
                txtBBPerm.Text == "")

            {
                MessageBox.Show("Es necesario esten todos los valores", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double CarrerasPermitidas = Convert.ToDouble(txtCarrerasPerm.Text);
                double EntradasLanzadas = Convert.ToDouble(txtEntLanzadas.Text);
                double BasePorBolas = Convert.ToDouble(txtBBPerm.Text);
                double Hits = Convert.ToDouble(txtHitsPerm);

                double ERA = CarrerasPermitidas / EntradasLanzadas;
                txtERA.Text = ERA.ToString();

                double WHIP = BasePorBolas + Hits / EntradasLanzadas;
                txtWHIP.Text = WHIP.ToString();
                

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtEntLanzadas.Text == "" || txtHitsPerm.Text == "" || txtCarrerasPerm.Text == "" ||
                txtBBPerm.Text == "")

            {
                MessageBox.Show("Es necesario esten todos los valores", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(TablaDatosPitcher);
                fila.Cells[0].Value = txtNombre.Text;
                fila.Cells[1].Value = txtERA.Text;
                fila.Cells[2].Value = txtWHIP.Text;
                

                TablaDatosPitcher.Rows.Add(fila);

                txtNombre.Text = "";
                txtEntLanzadas.Text = "";
                txtHitsPerm.Text = "";
                txtCarrerasPerm.Text = "";
                txtBBPerm.Text = "";
                txtERA.Text = "";
                txtWHIP.Text = "";
            }
        }
    }
}
