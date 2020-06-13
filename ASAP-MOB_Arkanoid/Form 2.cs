using System;
using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    public partial class Form_2 : Form
    {
        public Form_2()
        {
            InitializeComponent();
        }

        private void Form_2_Load(object sender, EventArgs e)
        {
        
            var dt = BaseDatos.ExecuteQuery($"SELECT id, nombres, puntaje FROM Jugadores ");
            dataGridView1.DataSource = dt;
            /*
             try
            {
                var dt = BaseDatos.ExecuteQuery($"SELECT id, nombres, puntaje FROM Jugadores ");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema puntuaciones");
            }
             */
            
        }
    }
}