using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDoktorPaneli : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCno;
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSekreterDetay fr = new FrmSekreterDetay();
            fr.TCno = this.TCno;
            fr.Show();
            this.Hide();
        }

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("select BransAd from Tbl_Branslar ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                CmbBrans.Items.Add(dr["BransAd"]);
            }
            bgl.baglanti().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand doktorEkleme = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
            doktorEkleme.Parameters.AddWithValue("@d1",TxtAd.Text);
            doktorEkleme.Parameters.AddWithValue("@d2",TxtSoyad.Text);
            doktorEkleme.Parameters.AddWithValue("@d3",CmbBrans.Text);
            doktorEkleme.Parameters.AddWithValue("@d4",MskTC.Text);
            doktorEkleme.Parameters.AddWithValue("@d5",TxtSifre.Text);
            int donenSonuc = doktorEkleme.ExecuteNonQuery();
            bgl.baglanti().Close();
            if(TxtAd.Text == string.Empty || TxtSoyad.Text == string.Empty || CmbBrans.Text == string.Empty || MskTC.Text == string.Empty || TxtSifre.Text==string.Empty)
            {
                MessageBox.Show("Doktor kayıdı için gerekli boşlukları doldurun!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if( donenSonuc ==1  )
            {
                MessageBox.Show("Doktor kayıdı başarılı bir şekilde oluşturulmuştur.","Bilgilendirme",MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                TxtAd.Text = string.Empty;
                TxtSoyad.Text = string.Empty;
                CmbBrans.Text = string.Empty;
                MskTC.Text = string.Empty;
                TxtSifre.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Doktor kayıdı yapılırken bir hata oluştu!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtAd.Text = dataGridView1.CurrentRow.Cells["DoktorAd"].Value.ToString();
            TxtSoyad.Text= dataGridView1.CurrentRow.Cells["DoktorSoyad"].Value.ToString();
            CmbBrans.Text =  dataGridView1.CurrentRow.Cells["DoktorBrans"].Value.ToString();
            MskTC.Text = dataGridView1.CurrentRow.Cells["DoktorTC"].Value.ToString();
            TxtSifre.Text = dataGridView1.CurrentRow.Cells["DoktorSifre"].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Doktorlar where DoktorTC=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", MskTC.Text);
            int sonuc = komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if(MskTC.Text == string.Empty)
            {
                MessageBox.Show("Seçili bir TC olmadığı için herhangi bir silme işlemi yapılmadı!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if ( sonuc ==1)
            {
                MessageBox.Show("TC numarası " + MskTC.Text + " olan doktor sistemden başarılı bir şekilde silinmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                TxtAd.Text = string.Empty;
                TxtSoyad.Text = string.Empty;
                CmbBrans.Text = string.Empty;
                MskTC.Text = string.Empty;
                TxtSifre.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Seçili bir doktor olmadığı için herhangi bir silme işlemi yapılmadı!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand doktorEkleme = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2, DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4", bgl.baglanti());
            doktorEkleme.Parameters.AddWithValue("@d1", TxtAd.Text);
            doktorEkleme.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            doktorEkleme.Parameters.AddWithValue("@d3", CmbBrans.Text);
            doktorEkleme.Parameters.AddWithValue("@d4", MskTC.Text);
            doktorEkleme.Parameters.AddWithValue("@d5", TxtSifre.Text);
            int donenSonuc = doktorEkleme.ExecuteNonQuery();
            bgl.baglanti().Close();
            if (TxtAd.Text == string.Empty || TxtSoyad.Text == string.Empty || CmbBrans.Text == string.Empty || MskTC.Text == string.Empty || TxtSifre.Text == string.Empty)
            {
                MessageBox.Show("Doktor güncellemesi için gerekli boşlukları doldurun!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (donenSonuc == 1)
            {
                MessageBox.Show("TC numarası " + MskTC.Text + " olan doktorun bilgileri başarılı bir şekilde güncellenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                TxtAd.Text = string.Empty;
                TxtSoyad.Text = string.Empty;
                CmbBrans.Text = string.Empty;
                MskTC.Text = string.Empty;
                TxtSifre.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Doktor güncelleme işlemi sırasında bir hata oluştu!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
