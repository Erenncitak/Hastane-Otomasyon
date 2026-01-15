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
    public partial class FrmDoktorDetay : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCno;
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            BtnRandevuListesi.Enabled = false;
            LblTC.Text = TCno;
            dataGridView1.ReadOnly = true;
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr["DoktorAd"].ToString() + " " + dr["DoktorSoyad"].ToString();
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuDoktor=@d1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@d1", LblAdSoyad.Text);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(BtnRandevuListesi.Enabled==false)
            RchSikayet.Text = dataGridView1.CurrentRow.Cells["HastaSikayet"].Value.ToString();
            else if (BtnDuyurular.Enabled == false)
            {
                RchSikayet.Text = dataGridView1.CurrentRow.Cells["Duyuru"].Value.ToString();
            }
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            BtnDuyurular.Enabled = false;
            BtnRandevuListesi.Enabled = true;

            RchSikayet.Text = string.Empty;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Duyurular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void randevularıGetir_Click(object sender, EventArgs e)
        {
            BtnDuyurular.Enabled = true;
            BtnRandevuListesi.Enabled = false;
            RchSikayet.Text = string.Empty;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris fr = new FrmDoktorGiris();
            fr.Show();
            this.Hide();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr = new FrmDoktorBilgiDuzenle();
            fr.TCno = this.TCno;
            fr.Show();
            this.Hide();
        }
    }
}
