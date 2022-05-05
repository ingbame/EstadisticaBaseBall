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
	        if (txtNombre.Text == "" || txtVecesalBat.Text == "" || txtHits.Text == ""|| txtDoubles.Text == ""|| txtTriplets.Text == ""|| txtHR.Text == ""
            || txtBaseBolas.Text == "" || txtGolpe.Text == "" || txtSF.Text == "")
	
            {
                MessageBox.Show("Es necesario esten todos los valores", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double VecesAlBat = Convert.ToDouble(txtVecesalBat.Text);
                double Hits = Convert.ToDouble(txtHits.Text);
                double Dobles = Convert.ToDouble(txtDoubles.Text);
                double Triples = Convert.ToDouble(txtTriplets.Text);
                double HR = Convert.ToDouble(txtHR.Text);
                double Bolas = Convert.ToDouble(txtBaseBolas.Text);
                double Golpe = Convert.ToDouble(txtGolpe.Text);
                double SF = Convert.ToDouble(txtSF.Text);

                double resultadoAVG = Hits / VecesAlBat;
                txtAVG.Text = resultadoAVG.ToString();

                double resultadoOBP = (Hits + Bolas + Golpe) / (VecesAlBat + Bolas + Golpe + SF);
                txtOBP.Text = resultadoOBP.ToString();

                double DobletesSlug = Dobles;
                double TripletesSlug = Triples * 2;
                double HRSlug = HR * 3;
                double TotalSlug = Hits + DobletesSlug + TripletesSlug + HRSlug;

                double resultadoSlug = TotalSlug/ VecesAlBat;
                txtSlugging.Text = resultadoSlug.ToString();

                double resultadoOPS = resultadoSlug + resultadoOBP;
                txtOPS.Text = resultadoOPS.ToString();

            }

        }

        private void TablaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtVecesalBat.Text == "" || txtHits.Text == "" || txtDoubles.Text == "" || txtTriplets.Text == "" || txtHR.Text == ""
            || txtBaseBolas.Text == "" || txtGolpe.Text == "")

            {
                MessageBox.Show("Es necesario esten todos los valores", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(TablaDatos);
                fila.Cells[0].Value = txtNombre.Text;
                fila.Cells[1].Value = txtAVG.Text;
                fila.Cells[2].Value = txtOBP.Text;
                fila.Cells[3].Value = txtSlugging.Text;
                fila.Cells[4].Value = txtOPS.Text;

                TablaDatos.Rows.Add(fila);

                txtNombre.Text = "";
                txtHits.Text = "";
                txtDoubles.Text = "";
                txtGolpe.Text = "";
                txtTriplets.Text = "";
                txtHR.Text = "";
                txtSF.Text = "";
                txtVecesalBat.Text = "";
                txtBaseBolas.Text = "";
                txtAVG.Text = "";
                txtOBP.Text = "";
                txtSlugging.Text = "";
                txtOPS.Text = "";

            }
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
    }
}