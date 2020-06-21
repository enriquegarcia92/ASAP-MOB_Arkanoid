using System;
using System.ComponentModel;
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
                var dt = BaseDatos.ExecuteQuery($"SELECT nombres,puntaje FROM Jugadores ORDER BY puntaje DESC LIMIT 10 ");
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    throw new EmptyscoresException("No hay puntajes previos");
                }

                
            }
            catch(EmptyscoresException ex)
            {
                MessageBox.Show(ex.Message);
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}