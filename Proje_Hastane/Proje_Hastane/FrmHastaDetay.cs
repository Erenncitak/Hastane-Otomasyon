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
    public partial class FrmHastaDetay : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        public string ID;
        //public string hastaAdSoyad;
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;
            // Ad Soyad çekme
            SqlCommand komut = new SqlCommand("select Hastaid,HastaAd,HastaSoyad from Tbl_Hastalar where HastaTC=@hastaTC", bgl.baglanti());
            komut.Parameters.AddWithValue("@hastaTC", LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if(dr.Read())
            {
                ID = dr["Hastaid"].ToString();
                //hastaAdSoyad= dr["HastaAd"].ToString() + " " + dr["HastaSoyad"].ToString();
                LblAdSoyad.Text = dr["HastaAd"].ToString() + " " + dr["HastaSoyad"].ToString();
            }
            else
            {
                MessageBox.Show("Hastanın bilgilerine erişirken bir problem oluştu!!!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            //if(LblTC.Text != tc && LblAdSoyad.Text != hastaAdSoyad)
            //{
            //    SqlCommand komut4 = new SqlCommand("select HastaTC,HastaAd,HastaSoyad from Tbl_Hastalar where Hastaid=@d1",bgl.baglanti());
            //    komut4.Parameters.AddWithValue("@d1",Convert.ToInt16(ID));
            //    SqlDataReader dataReader = komut4.ExecuteReader();
            //    while(dataReader.Read())
            //    {
            //        LblTC.Text = dataReader["HastaTC"].ToString();
            //        LblAdSoyad.Text = dataReader["HastaAd"].ToString() + " " + dataReader["HastaSoyad"].ToString();
            //    }
            //}

            // Randevu geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where HastaTC=@tc", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@tc",tc);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Branşları çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2["BransAd"].ToString());
            }
            bgl.baglanti().Close();

        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            CmbDoktor.Items.Clear();
            CmbDoktor.Text = "";
            // Doktor çekme
            if (CmbBrans.SelectedIndex != -1)
            {
                SqlCommand komut3 = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@doktorbrans", bgl.baglanti());
                komut3.Parameters.AddWithValue("@doktorbrans", CmbBrans.Text);
                SqlDataReader dr3 = komut3.ExecuteReader();

                if(CmbDoktor.Text != string.Empty)
                {
                    while (dr3.Read())
                    {
                        CmbDoktor.Items.Add(dr3["DoktorAd"] + " " + dr3["DoktorSoyad"]);
                    }
                    dr3.Close();
                    bgl.baglanti().Close();
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuBrans=@d1 and RandevuDurum=0", bgl.baglanti());
                da.SelectCommand.Parameters.AddWithValue("@d1", CmbBrans.Text);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                bgl.baglanti().Close();
            
            }
            */
            CmbDoktor.Items.Clear();
            CmbDoktor.Text = "";
            dataGridView2.DataSource = null; // eski randevuları temizle

            if (CmbBrans.SelectedIndex == -1)
                return;

            SqlCommand cmd = new SqlCommand(
                "SELECT DoktorAd, DoktorSoyad FROM Tbl_Doktorlar WHERE DoktorBrans=@brans",
                bgl.baglanti());

            cmd.Parameters.AddWithValue("@brans", CmbBrans.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr["DoktorAd"] + " " + dr["DoktorSoyad"]);
            }

            dr.Close();
            bgl.baglanti().Close();

        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbBrans.SelectedIndex == -1 || CmbDoktor.SelectedIndex == -1)
                return;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Tbl_Randevular " +
                "WHERE RandevuBrans=@brans " +
                "AND RandevuDoktor=@doktor " +
                "AND RandevuDurum=0",
                bgl.baglanti());

            da.SelectCommand.Parameters.AddWithValue("@brans", CmbBrans.Text);
            da.SelectCommand.Parameters.AddWithValue("@doktor", CmbDoktor.Text);

            da.Fill(dt);
            dataGridView2.DataSource = dt;

            bgl.baglanti().Close();
            /*
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans='"+CmbBrans.Text+"'" + " and RandevuDoktor='"+CmbDoktor.Text+"' and RandevuDurum=0",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            */
        }

        private void LnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.TCno = LblTC.Text.ToString();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView2.CurrentRow.Cells["Randevuid"].Value.ToString();
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Randevular set RandevuDurum=1,HastaTC=@d1,HastaSikayet=@d2 where Randevuid=@d3", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",LblTC.Text);
            komut.Parameters.AddWithValue("@d2",RchSikayet.Text);
            komut.Parameters.AddWithValue("@d3",Txtid.Text);
            int sonuc = komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if (sonuc == 1)
            {
                MessageBox.Show("Randevu başarılı bir şekilde alınmıştır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where HastaTC=@tc", bgl.baglanti());
                da.SelectCommand.Parameters.AddWithValue("@tc", tc);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                // BURADA KALDIK RANDEVU ALINDIKTAN SONRA DATAGRİDVİEW2 DE İLK BAŞTAKİ GİBİ GRİ BİR GÖRÜNTÜ GELMESİ GEREKİYOR

                dataGridView2.DataSource = null;

                /*
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("select * from Tbl_Randevular where RandevuDurum=0 and RandevuBrans=@d1 and RandevuDoktor=@d2", bgl.baglanti());
                da2.SelectCommand.Parameters.AddWithValue("d1", CmbBrans.Text);
                da2.SelectCommand.Parameters.AddWithValue("d2", CmbDoktor.Text);
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
                */

                Txtid.Text = string.Empty;
                CmbBrans.Text = string.Empty;
                CmbDoktor.Text = string.Empty;
                RchSikayet.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Randevu alınırken bir hata oluştu!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
