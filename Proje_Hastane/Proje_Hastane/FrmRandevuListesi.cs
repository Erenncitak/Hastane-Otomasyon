using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmRandevuListesi : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCno;
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSekreterDetay fr = new FrmSekreterDetay();
            fr.TCno = this.TCno;
            fr.Show();
            this.Hide();
        }
    }
}
