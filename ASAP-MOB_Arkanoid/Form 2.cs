using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace ASAP_MOB_Arkanoid
{
    public partial class Form_2 : Form
    {
        public Form_2()
        {
            InitializeComponent();
            VerDatos();
        }
        
        private static string host = "127.0.0.1",
            puerto = "5432",
            database = "ASAP-MOB",
            userId = "postgres",
            password = "Oscar";

        private static string sConnection =
            $"Server={host};Port={puerto};User Id={userId};Password={password};Database={database};";

        private void VerDatos()
        {
            string query = "SELECT id, nombres, puntaje FROM Jugadores";

            using (NpgsqlConnection con = new NpgsqlConnection(sConnection))
            {
                con.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, con);
                
                var ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Descending);
                con.Close();
            }
        }
        
    }
}