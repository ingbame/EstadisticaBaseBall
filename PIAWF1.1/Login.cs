namespace PIAWF1._1
{
    public partial class Login : Form
    {
        Bateo logeo;

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
                    this.Close();
                }
            }

        }
    }
}
