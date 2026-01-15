using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmBrans : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCno;
        public FrmBrans()
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

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            Txtid.Enabled = false;
            dataGridView1.ReadOnly = true;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            bgl.baglanti().Close();
            dataGridView1.DataSource = dt;


        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("insert into Tbl_Branslar (BransAd) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", TxtBrans.Text);
            int sonuc = komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if(TxtBrans.Text == string.Empty)
            {
                MessageBox.Show("Kaydını yapmak istediğiniz branşı gerekli alana giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (sonuc == 1)
            {
                MessageBox.Show("Branş kayıdı başarılya tamamlanmıştır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtBrans.Text = string.Empty;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Branş kayıdı yapılırken kata oluştu!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Branslar where Bransid=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", Txtid.Text);
            int sonuc = komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if(Txtid.Text==string.Empty)
            {
                MessageBox.Show("Seçili bir Branş ID olmadığı için herhangi bir silme işlemi yapılmadı!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (sonuc == 1)
            {
                MessageBox.Show("Branş numarası '" + Txtid.Text + "' olan branş sistemden başarılı bir şekilde silinmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                Txtid.Text = string.Empty;
                TxtBrans.Text = string.Empty;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.CurrentRow.Cells["Bransid"].Value.ToString();
            TxtBrans.Text = dataGridView1.CurrentRow.Cells["BransAd"].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Branslar set BransAd=@d1 where Bransid=@d2", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", TxtBrans.Text);
            komut.Parameters.AddWithValue("@d2", Txtid.Text);
            int sonuc = komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if(TxtBrans.Text == string.Empty || Txtid.Text == string.Empty)
            {
                MessageBox.Show("Branş güncellemesi için gerekli boşlukları doldurun!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(sonuc == 1)
            {
                MessageBox.Show("Branş numarası " + Txtid.Text + " olan branşın bilgileri başarılı bir şekilde güncellenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                TxtBrans.Text = string.Empty;
                Txtid.Text=string.Empty;
            }
            else
            {
                MessageBox.Show("Branş güncelleme işlemi sırasında bir hata oluştu!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
