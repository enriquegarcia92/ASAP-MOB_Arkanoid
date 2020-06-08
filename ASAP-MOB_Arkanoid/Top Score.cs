using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    public partial class Top_Score : UserControl
    {
        public Top_Score()
        {
            InitializeComponent();
        }

        private void mostrar()
        {
            var dt = ConnectionDB.ExecuteQuery($"SELECT FROM Jugadores");
            dataGridView1.DataSource = dt.TableName[0];

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        public DataTable DataSource { get; set; }
    }
}