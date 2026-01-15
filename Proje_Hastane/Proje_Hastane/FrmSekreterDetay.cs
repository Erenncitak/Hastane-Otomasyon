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
    public partial class FrmSekreterDetay : Form
    {
        public string TCno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = TCno;
            //Ad soyad
            SqlCommand komut = new SqlCommand("select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", TCno);
            object sonuc= komut.ExecuteScalar();
            if (sonuc!=null)
            {
                LblAdSoyad.Text = sonuc.ToString();
            }
            else
            {
                MessageBox.Show("Beklenmedik bir hata oluştu!!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            // Branşları tabloya aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Branşları çekme
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr= komut2.ExecuteReader();
            while (dr.Read())
            {
                CmbBrans.Items.Add(dr["BransAd"].ToString());
            }
            bgl.baglanti().Close();

            // Doktorları tabloya aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@d1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@d1",CmbBrans.Text.ToString());
            SqlDataReader dr =  komut3.ExecuteReader();
            while(dr.Read())
            {
                CmbDoktor.Items.Add(dr["DoktorAd"] + " " + dr["DoktorSoyad"]);
            }
            bgl.baglanti().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@r1",MskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@r2",MskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@r3",CmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@r4",CmbDoktor.Text);
            int donenCevap = komutKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            
            if( donenCevap ==1)
            {
                MessageBox.Show("Randevu başarılı bir şekilde oluşturuldu.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MskTarih.Text = string.Empty;
                MskSaat.Text = string.Empty;
                CmbBrans.Text = string.Empty;
                CmbDoktor.Text = string.Empty;
            }
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komutDuyuru = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.baglanti());
            komutDuyuru.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            int sonuc = komutDuyuru.ExecuteNonQuery();
            if(sonuc == 1)
            {
                MessageBox.Show("Duyur başarılı bir şekilde oluşturulmuştur.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                RchDuyuru.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Duyur oluşturulurken hata oluştu. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fr = new FrmDoktorPaneli();
            fr.TCno = this.TCno;
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris fr = new FrmSekreterGiris();
            fr.TCno = this.TCno;  // Mevcut sekreter TC numarasını yeni forma aktar
            fr.Show();
            this.Hide();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans fr = new FrmBrans();
            fr.TCno = this.TCno;
            fr.Show();
            this.Hide();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fr = new FrmRandevuListesi();
            fr.TCno = this.TCno;
            fr.Show();
            this.Hide();
        }
    }
}
