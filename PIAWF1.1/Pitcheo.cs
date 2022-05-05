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
            //puedes usar la función string que devuelve un bool, valida si es nulo o vacío 
            //La mayoría de los textos usa trim() para borrar espacios iniciales o finales, esto es básico en desarrollo al capturar data
            //Ejemplo con txtNombre, cambia los demás
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || txtEntLanzadas.Text == "" || txtHitsPerm.Text == "" || txtCarrerasPerm.Text == "" ||
                txtBBPerm.Text == "")

            {
                MessageBox.Show("Es necesario esten todos los valores", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //usar try catch, que pasa si meten letras??????
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
            //puedes usar la función string que devuelve un bool, valida si es nulo o vacío 
            //La mayoría de los textos usa trim() para borrar espacios iniciales o finales, esto es básico en desarrollo al capturar data
            //Ejemplo con txtNombre, cambia los demás
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || txtEntLanzadas.Text == "" || txtHitsPerm.Text == "" || txtCarrerasPerm.Text == "" ||
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

                //De preferencia encapsular en un metodo el limpiado de información, ya que si se requiere en otro lugar ya no se duplica el código
                //usar propiedad por standar string.empty ejemplo en la siguiente linea
                txtNombre.Text = string.Empty;
                txtEntLanzadas.Text = "";
                txtHitsPerm.Text = "";
                txtCarrerasPerm.Text = "";
                txtBBPerm.Text = "";
                txtERA.Text = "";
                txtWHIP.Text = "";
            }
        }

        private void btnRegreso_Click(object sender, EventArgs e)
        {
            Menu ventana = new Menu();
            ventana.Show();
            this.Hide();
        }
    }
}
