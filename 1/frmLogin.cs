using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class frmLogin : Form
    {
        string usuario = "admin";
        string contraseña = "1234";
        public bool ingreso = false;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == usuario & txtContraseña.Text == contraseña)
            {
                ingreso = true;
                MessageBox.Show("Iniciando sesión");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta\nVolver a intentar");
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                txtUsuario.Focus();
            }
        }
    }
}
