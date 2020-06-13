using System;
using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    public partial class Puntuaciones : Form
    {
        public Puntuaciones()
        {
            InitializeComponent();
        }

        private void Puntuaciones_Load(object sender, EventArgs e)
        {
             try
             {
                 var dt = BaseDatos.ExecuteQuery($"SELECT id, nombres, puntaje FROM Jugadores ");
                 dataGridView1.DataSource = dt;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Ha ocurrido un problema puntuaciones");
             }
        }
    }
}