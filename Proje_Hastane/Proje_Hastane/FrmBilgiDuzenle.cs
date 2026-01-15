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
    public partial class FrmBilgiDuzenle : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCno;
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@HastaTC", bgl.baglanti());
            komut.Parameters.AddWithValue("@HastaTC", TCno);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                TxtAd.Text = dr["HastaAd"].ToString();
                TxtSoyad.Text = dr["HastaSoyad"].ToString();
                MskTelefon.Text = dr["HastaTelefon"].ToString();
                TxtSifre.Text = dr["HastaSifre"].ToString();
                CmbCinsiyet.SelectedItem = dr["HastaCinsiyet"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar set HastaAd=@d1, HastaSoyad=@d2,HastaTelefon=@d4,HastaSifre=@d5,HastaCinsiyet=@d6 where HastaTC=@d7",bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@d2",TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@d4",MskTelefon.Text);
            komut2.Parameters.AddWithValue("@d5",TxtSifre.Text);
            komut2.Parameters.AddWithValue("@d6",CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@d7", TCno);
            int sonuc = komut2.ExecuteNonQuery();
            bgl.baglanti().Close();

            if(sonuc == 1)
            {
                MessageBox.Show("Bilgileriniz başarıyla değiştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = TCno;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bir hata oluştu lütfen tekrar deneyiniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHastaDetay fr = new FrmHastaDetay();
            fr.tc=TCno;
            fr.Show();
            this.Hide();
        }
    }
}
