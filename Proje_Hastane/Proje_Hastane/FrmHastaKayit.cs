using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmHastaKayit : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }

        private void BtnKayitYap_Click(object sender, EventArgs e)
        {   
            SqlCommand komut = new SqlCommand("sp_hastaEkle",bgl.baglanti());
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@HastaAd", TxtAd.Text);
            komut.Parameters.AddWithValue("@HastaSoyad", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@HastaTC", MskTC.Text);
            komut.Parameters.AddWithValue("@HastaTelefon",MskTelefon.Text);
            komut.Parameters.AddWithValue("@HastaSifre", TxtSifre.Text);
            komut.Parameters.AddWithValue("@HastaCinsiyet", CmbCinsiyet.SelectedItem);
            int sonuc = komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (sonuc == 1)
            {
                MessageBox.Show("Başarıyla kayıt olundu.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                TxtAd.Text = string.Empty;
                TxtSoyad.Text = string.Empty;
                MskTC.Text = string.Empty;
                MskTelefon.Text = string.Empty;
                TxtSifre.Text = string.Empty;
                CmbCinsiyet.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Kayıt olurken bir hata oluştu!!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
