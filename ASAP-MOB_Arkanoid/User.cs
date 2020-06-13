using System;
using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    Program.usuario = textBox1.Text;
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}