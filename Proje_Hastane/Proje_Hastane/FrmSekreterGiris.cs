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
    public partial class FrmSekreterGiris : Form
    {
        public string TCno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreter where SekreterTC=@d1 and SekreterSifre=@d2", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", MskTC.Text);
            komut.Parameters.AddWithValue("@d2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            bgl.baglanti().Close();
            
            if(dr.Read())
            {
                FrmSekreterDetay fr = new FrmSekreterDetay();
                fr.TCno = MskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre hatalı!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGirisler fr = new FrmGirisler();
            fr.Show();
            this.Hide();
        }
    }
}
