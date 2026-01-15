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
    public partial class FrmDoktorGiris : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGirisler fr = new FrmGirisler();
            fr.Show();
            this.Hide();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@d1 and DoktorSifre=@d2", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", MskTC.Text);
            komut.Parameters.AddWithValue("@d2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            bgl.baglanti().Close();
            if(dr.Read())
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.TCno = MskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre hatalı!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
