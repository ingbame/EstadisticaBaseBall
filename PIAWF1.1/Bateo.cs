using Newtonsoft.Json;
using PIAWF1._1.Models;

namespace PIAWF1._1
{
    public partial class Bateo : Form
    {
        public Bateo()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHits_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoubles_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTriplets_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBaseBolas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGolpe_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            //puedes usar la función string que devuelve un bool, valida si es nulo o vacío 
            //La mayoría de los textos usa trim() para borrar espacios iniciales o finales, esto es básico en desarrollo al capturar data
            //Ejemplo con txtNombre, cambia los demás
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || txtVecesalBat.Text == "" || txtHits.Text == "" || txtDoubles.Text == "" || txtTriplets.Text == "" || txtHR.Text == ""
            || txtBaseBolas.Text == "" || txtGolpe.Text == "" || txtSF.Text == "")

            {
                MessageBox.Show("Es necesario esten todos los valores", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //usar try catch, que pasa si meten letras??????
                double VecesAlBat = Convert.ToDouble(txtVecesalBat.Text);
                double Hits = Convert.ToDouble(txtHits.Text);
                double Dobles = Convert.ToDouble(txtDoubles.Text);
                double Triples = Convert.ToDouble(txtTriplets.Text);
                double HR = Convert.ToDouble(txtHR.Text);
                double Bolas = Convert.ToDouble(txtBaseBolas.Text);
                double Golpe = Convert.ToDouble(txtGolpe.Text);
                double SF = Convert.ToDouble(txtSF.Text);

                double resultadoAVG = Hits / VecesAlBat;
                txtAVG.Text = Math.Round(resultadoAVG, 3).ToString();
           
                double resultadoOBP = (Hits + Bolas + Golpe) / (VecesAlBat + Bolas + Golpe + SF);
                txtOBP.Text = Math.Round(resultadoOBP, 3).ToString();

                double DobletesSlug = Dobles;
                double TripletesSlug = Triples * 2;
                double HRSlug = HR * 3;
                double TotalSlug = Hits + DobletesSlug + TripletesSlug + HRSlug;

                double resultadoSlug = TotalSlug / VecesAlBat;
                txtSlugging.Text = Math.Round(resultadoSlug, 3).ToString();

                double resultadoOPS = resultadoSlug + resultadoOBP;
                txtOPS.Text = Math.Round(resultadoOPS, 3).ToString(); 


            }

        }

        private void TablaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string JsonBateoRuta = System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data\EstadisticaBateo.json");

            List<EstadisticaBateoModel> _TablaDatos = JsonConvert.DeserializeObject<List<EstadisticaBateoModel>>(File.ReadAllText(JsonBateoRuta)) ?? new List<EstadisticaBateoModel>();

            //puedes usar la función string que devuelve un bool, valida si es nulo o vacío 
            //La mayoría de los textos usa trim() para borrar espacios iniciales o finales, esto es básico en desarrollo al capturar data
            //Ejemplo con txtNombre, cambia los demás
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || txtVecesalBat.Text == "" || txtHits.Text == "" || txtDoubles.Text == "" || txtTriplets.Text == "" || txtHR.Text == ""
            || txtBaseBolas.Text == "" || txtGolpe.Text == "")

            {
                MessageBox.Show("Es necesario esten todos los valores", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                EstadisticaBateoModel fila = new EstadisticaBateoModel();
                
                fila.NombreBateador = txtNombre.Text;
                fila.VecesAlBat = int.Parse(txtVecesalBat.Text);
                fila.Hits = int.Parse(txtHits.Text);
                fila.Dobletes = int.Parse(txtDoubles.Text);
                fila.Tripletes = int.Parse(txtTriplets.Text);
                fila.HR = int.Parse(txtHR.Text);
                fila.BasesPorBola = int.Parse(txtBaseBolas.Text);
                fila.BasesPorGolpe = int.Parse(txtGolpe.Text);
                fila.Sacrificios = int.Parse(txtSF.Text);
                fila.AVG = Math.Round(double.Parse(txtAVG.Text),3);
                fila.OBP = Math.Round(double.Parse(txtOBP.Text),3);
                fila.SLUG = Math.Round(double.Parse(txtSlugging.Text),3);
                fila.OPS = Math.Round(double.Parse(txtOPS.Text),3);
                _TablaDatos.Add(fila);
                TablaDatos.DataSource = _TablaDatos;
                TablaDatos.Refresh();
                
                var jsonSave = JsonConvert.SerializeObject(_TablaDatos);
                File.WriteAllText(JsonBateoRuta, jsonSave);

                //De preferencia encapsular en un metodo el limpiado de información, ya que si se requiere en otro lugar ya no se duplica el código
                //usar propiedad por standar string.empty ejemplo en la siguiente linea

                LimpiarCajasTexto();
            }
        }
        public void LimpiarCajasTexto()
        {
            txtNombre.Text = string.Empty;
            txtHits.Text = string.Empty;
            txtDoubles.Text = string.Empty;
            txtGolpe.Text = string.Empty;
            txtTriplets.Text = string.Empty;
            txtHR.Text = string.Empty;
            txtSF.Text = string.Empty;
            txtVecesalBat.Text = string.Empty;
            txtBaseBolas.Text = string.Empty;
            txtAVG.Text = string.Empty;
            txtOBP.Text = string.Empty;
            txtSlugging.Text = string.Empty;
            txtOPS.Text = string.Empty;
        }

        private void txtAVG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOBP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSlugging_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegreso_Click(object sender, EventArgs e)
        {
            Menu ventana = new Menu();
            ventana.Show();
            this.Hide();
        }

        private void Bateo_Load(object sender, EventArgs e)
        {
            try
            {
                List<EstadisticaBateoModel> _TablaDatos = new List<EstadisticaBateoModel>();
                string JsonBateoRuta = System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data\EstadisticaBateo.json");
                if (!Directory.Exists(System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data")))
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Data"));
                }
                if (!File.Exists(JsonBateoRuta))
                {
                    var json = JsonConvert.SerializeObject(_TablaDatos);
                    File.WriteAllText(JsonBateoRuta, json);
                }
                else
                {
                    //?? si viene nulo, condiciones ternarios
                    _TablaDatos = JsonConvert.DeserializeObject<List<EstadisticaBateoModel>>(File.ReadAllText(JsonBateoRuta)) ?? new List<EstadisticaBateoModel>();                    
                }
                TablaDatos.DataSource = _TablaDatos;
                TablaDatos.Refresh();
                TablaDatos.Columns["AVG"].Visible = false;
                TablaDatos.Columns["OBP"].Visible = false;
                TablaDatos.Columns["SLUG"].Visible = false;
                TablaDatos.Columns["OPS"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("No se pudo crear el archivo", ex), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Bateo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu ventana = new Menu();
            ventana.Show();
            this.Hide();
        }
    }
}