using System;
using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    public partial class Menu : Form
    {
        

        public Menu()
        {
            InitializeComponent();
        }

        private void puntajes_Click(object sender, EventArgs e)
        {
            Puntuaciones scores = new Puntuaciones();
            scores.Show();
            this.Hide();
        }

        private void jugar_Click(object sender, EventArgs e)
        {
            User juego = new User();
            juego.Show();
            this.Hide();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }
    }
}