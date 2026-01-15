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
    public partial class FrmHastaGiris : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGirisler fr = new FrmGirisler();
            fr.Show();
            this.Hide();
        }

        public void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@hastaTC and HastaSifre=@hastaSifre", bgl.baglanti());
            komut.Parameters.AddWithValue("@hastaTC", MskTC.Text);
            komut.Parameters.AddWithValue("@hastaSifre", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            bgl.baglanti().Close();

            if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc=MskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC ve şifre uyumsuzluğu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
