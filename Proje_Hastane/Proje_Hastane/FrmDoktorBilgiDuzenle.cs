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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCno;
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad,DoktorBrans,DoktorSifre from Tbl_Doktorlar where DoktorTC=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", TCno);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                TxtAd.Text = dr["DoktorAd"].ToString();
                TxtSoyad.Text = dr["DoktorSoyad"].ToString();
                MskTC.Text = TCno;
                CmbBrans.Text = dr["DoktorBrans"].ToString();
                TxtSifre.Text = dr["DoktorSifre"].ToString();
            }
            dr.Close();
            bgl.baglanti().Close();


            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while( dr2.Read())
            {
                CmbBrans.Items.Add(dr2["BransAd"].ToString());
            }
            dr.Close();
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDoktorDetay fr = new FrmDoktorDetay();
            fr.TCno = this.TCno;
            fr.Show();
            this.Hide();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@d1, DoktorSoyad=@d2, DoktorBrans=@d3, DoktorSifre=@d5 where DoktorTC=@d4", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", TxtAd.Text);
            komut.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@d4", MskTC.Text);
            komut.Parameters.AddWithValue("@d5", TxtSifre.Text);
            int sonuc = komut.ExecuteNonQuery();
            if (sonuc == 1)
            {
                MessageBox.Show("Güncelleme işlemi başarıyla tamamlanmıştır Detay Sayfasına yönlendiriliyorsunuz..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.TCno = this.TCno;
                fr.Show();
                this.Hide();
            }
        }
    }
}
