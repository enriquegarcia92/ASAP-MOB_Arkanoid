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
            Form_2 puntuaciones = new Form_2();
            puntuaciones.Show();
        }

        private void jugar_Click(object sender, EventArgs e)
        {
            Form1 juego = new Form1();
            juego.Show();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}