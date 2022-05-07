using Newtonsoft.Json;
using PIAWF1._1.Models;

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
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText(@"..\Data\Usuarios.json"));
            if ((txtUsuario.Text != "") && (txtPassword.Text != ""))
            {
                var usr = usuarios.Where(w => w.UserName == txtUsuario.Text).FirstOrDefault();
                if (usr != null) 
                {
                    if (usr.Password == txtPassword.Text)
                    {
                        logeo = new Menu();
                        logeo.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Password incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                else
                    MessageBox.Show("Credenciales invalidas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Campos vacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
