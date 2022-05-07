using Newtonsoft.Json;
using PIAWF1._1.Models;
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
                int CarrerasPermitidas = Convert.ToInt32(txtCarrerasPerm.Text);
                double EntradasLanzadas = Convert.ToDouble(txtEntLanzadas.Text);
                double BasePorBolas = Convert.ToDouble(txtBBPerm.Text);
                double Hits = Convert.ToDouble(txtHitsPerm.Text);

                double ERA = CarrerasPermitidas / EntradasLanzadas;
                txtERA.Text = Math.Round(ERA, 3).ToString();

                double WHIP = (BasePorBolas + Hits) / EntradasLanzadas;
                txtWHIP.Text = Math.Round(WHIP, 3).ToString();


            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string JsonPitcheoRuta = System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data\EstadisticaPitcheo.json");

            List<EstadisticaPitcheoModel> _TablaDatos = JsonConvert.DeserializeObject<List<EstadisticaPitcheoModel>>(File.ReadAllText(JsonPitcheoRuta)) ?? new List<EstadisticaPitcheoModel>();

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
                EstadisticaPitcheoModel fila = new EstadisticaPitcheoModel();
                fila.EntradasLanzadas = double.Parse(txtEntLanzadas.Text);
                fila.HitsPermitidos = int.Parse(txtHitsPerm.Text);
                fila.CarrerasPerm = int.Parse(txtCarrerasPerm.Text);
                fila.BasePorBolaPerm = int.Parse(txtBBPerm.Text);
                fila.NombrePitcher = txtNombre.Text;
                fila.ERA = Math.Round(double.Parse(txtERA.Text), 3);
                fila.WHIP = Math.Round(double.Parse(txtWHIP.Text), 3);

                _TablaDatos.Add(fila);
                TablaDatosPitcher.DataSource = _TablaDatos;
                TablaDatosPitcher.Refresh();

                var jsonSave = JsonConvert.SerializeObject(_TablaDatos);
                File.WriteAllText(JsonPitcheoRuta, jsonSave);

                LimpiarCaajasTexto();
            }
        }
        public void LimpiarCaajasTexto()
        {
            txtNombre.Text = string.Empty;
            txtEntLanzadas.Text = string.Empty;
            txtHitsPerm.Text = string.Empty;
            txtCarrerasPerm.Text = string.Empty;
            txtBBPerm.Text = string.Empty;
            txtERA.Text = string.Empty;
            txtWHIP.Text = string.Empty;
        }

        private void btnRegreso_Click(object sender, EventArgs e)
        {
            Menu ventana = new Menu();
            ventana.Show();
            this.Hide();
        }

        private void Pitcheo_Load(object sender, EventArgs e)
        {
            try
            {
                List<EstadisticaPitcheoModel> _TablaDatos = new List<EstadisticaPitcheoModel>();
                string JsonPitcheoRuta = System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data\EstadisticaPitcheo.json");
                if (!Directory.Exists(System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data")))
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data"));
                }
                if (!File.Exists(JsonPitcheoRuta))
                {
                    var json = JsonConvert.SerializeObject(_TablaDatos);
                    File.WriteAllText(JsonPitcheoRuta, json);
                }
                else
                {
                    //?? si viene nulo, condiciones ternarios
                    _TablaDatos = JsonConvert.DeserializeObject<List<EstadisticaPitcheoModel>>(File.ReadAllText(JsonPitcheoRuta)) ?? new List<EstadisticaPitcheoModel>();
                }

                TablaDatosPitcher.DataSource = _TablaDatos;
                TablaDatosPitcher.Refresh();
                TablaDatosPitcher.Columns["ERA"].Visible = false;
                TablaDatosPitcher.Columns["WHIP"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("No se pudo crear el archivo", ex), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Pitcheo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu ventana = new Menu();
            ventana.Show();
            this.Hide();
        }
    }
}
