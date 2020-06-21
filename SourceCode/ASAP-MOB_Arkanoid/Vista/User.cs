using System;
using System.Linq;
using System.Windows.Forms;
using testarkanoid;

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
            try
            {
                    if (textBox1.Text.Equals("Usuario"))
                    {
                        throw new EmptyUserNameException("Debe ingresar su nickname");
                    } 

                        Program.usuario = textBox1.Text;
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    
            }
            catch (EmptyUserNameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
          
        }
    }
}