namespace PIAWF1._1
{
    public partial class Login : Form
    {
        Menu logeo;

        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text != "") && (txtPassword.Text != ""))
            {
                if ((txtUsuario.Text == "Admin") && (txtPassword.Text == "pass123"))
                {
                    logeo = new Menu();
                    logeo.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Credenciales invalidas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
