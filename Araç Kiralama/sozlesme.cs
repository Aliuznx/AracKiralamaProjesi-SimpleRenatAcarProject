using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace Araç_Kiralama_Otomasyonu
{
    public partial class sozlesme : Form
    {
        SqlConnection baglanti = Class1.baglan();
        public sozlesme()
        {
            InitializeComponent();
        }
        public DataTable tablo = new DataTable();
        public SqlCommand kmt = new SqlCommand();
        public SqlCommand kmt2 = new SqlCommand();


        public void Temizle()
        {
            cikistarihitext.Text = DateTime.Now.ToShortDateString();
            donustarihitext.Text = DateTime.Now.ToShortDateString();
            tcnotextbox.Text = "";
            adsoyadtextbox.Text = "";
            telnotextbox.Text = "";
            ehliyetnotextbox.Text = "";
            ehliyettarihitextbox.Text = "";
            ehliyetyertextbox.Text = "";
            ucrettext.Text = "";
            textBox14.Text = "";
            markatext.Text = "";
            serinotext.Text = "";
            modelyilitext.Text = "";
            renktext.Text = "";
            plakatextbox.Text = "";
            guntext.Text = "";
            tutartext.Text = "";
            araccombo.Text = "";
            kisaseklicombo.Text = "";
            cikistarihitext.Text = "";
            donustarihitext.Text = "";
            txtTcAra.Text = "";
        }

        public void listele()
        {
            tablo.Clear();
            baglanti.Close();
            baglanti.Open();
            SqlDataAdapter liste = new SqlDataAdapter("select * From sözleşme", baglanti);
            liste.Fill(tablo);
            dataGridView1.DataSource = tablo;
            liste.Dispose();
            baglanti.Close();
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[1].HeaderText = "tc";
                dataGridView1.Columns[2].HeaderText = "adsoyad";
                dataGridView1.Columns[3].HeaderText = "telefon";
                dataGridView1.Columns[4].HeaderText = "ehliyetno";
                dataGridView1.Columns[5].HeaderText = "e_tarih";
                dataGridView1.Columns[6].HeaderText = "e_yer";
                dataGridView1.Columns[7].HeaderText = "plaka";
                dataGridView1.Columns[8].HeaderText = "marka";
                dataGridView1.Columns[9].HeaderText = "seri";
                dataGridView1.Columns[10].HeaderText = "yil";
                dataGridView1.Columns[11].HeaderText = "renk";
                dataGridView1.Columns[12].HeaderText = "kirasekli";
                dataGridView1.Columns[13].HeaderText = "kiraucreti";
                dataGridView1.Columns[14].HeaderText = " gün";
                dataGridView1.Columns[15].HeaderText = "tutar";
                dataGridView1.Columns[16].HeaderText = "ctarih";
                dataGridView1.Columns[17].HeaderText = "dtarih";



            }
            catch
            {
                ;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            kmt.Connection = baglanti;
            kmt.CommandText = "INSERT INTO sözleşme (tc, adsoyad, telefon, ehliyetno, e_tarih, e_yer, plaka, marka, seri, yil, renk,  kirasekli, kiraucreti, gün, tutar, ctarih, dtarih ) VALUES ('" + tcnotextbox.Text + "','" + adsoyadtextbox.Text + "','" + telnotextbox.Text + "','" + ehliyetnotextbox.Text + "' , '" + ehliyettarihitextbox.Text + "' , '" + ehliyetyertextbox.Text + "' , '" + plakatextbox.Text + "' , '" + markatext.Text + "','" + serinotext.Text + "','" + modelyilitext.Text + "','" + renktext.Text + "','" + kisaseklicombo.Text + "' , '" + ucrettext.Text + "','" + guntext.Text + "','" + tutartext.Text + "','" + cikistarihitext.Value + "','" + donustarihitext.Value + "')";
            kmt.ExecuteNonQuery();
            kmt.Dispose();
            MessageBox.Show("KAYIT BAŞARIYLA EKLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();

            baglanti.Open();
            string sorguaracdurum = "update arac set durumu ='DOLU' where plaka= '" + plakatextbox.Text + "'";
            SqlCommand komutdurum = new SqlCommand(sorguaracdurum, baglanti);
            komutdurum.ExecuteNonQuery();
            komutdurum.Dispose();

            baglanti.Close();
            listele();
            MessageBox.Show("SÖZLEŞME KAYDEDİLDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();




        }


        arac_islemleri arac = new arac_islemleri();
        void bostaolanaracibul()
        {
            SqlCommand cmd;
            SqlDataReader dr;

            baglanti.Close();
            baglanti.Open();
            try
            {
                araccombo.Items.Clear();
                cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "SELECT * FROM arac where durumu = 'BOŞ'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    araccombo.Items.Add(dr["marka"]);

                }
            }
            catch
            {
            }
            baglanti.Close();


        }
        void aracbulucu()
        {
            baglanti.Close();
            baglanti.Open();
            string sorgumarkabulucu = "Select marka from arac where marka='" + araccombo.Text + "'";
            SqlCommand komutmarkabulucu = new SqlCommand(sorgumarkabulucu, baglanti);

            string sorguseribulucu = "Select seri from arac where marka='" + araccombo.Text + "'";
            SqlCommand komutseribulucu = new SqlCommand(sorguseribulucu, baglanti);


            string sorgurenkbulucu = "Select renk from arac where marka='" + araccombo.Text + "'";
            SqlCommand komutrenkbulucu = new SqlCommand(sorgurenkbulucu, baglanti);

            string sorgumodelbulucu = "Select yil from arac where marka='" + araccombo.Text + "'";
            SqlCommand komutmodelbulucu = new SqlCommand(sorgumodelbulucu, baglanti);

            string sorguplakabulucu = "Select plaka from arac where marka='" + araccombo.Text + "'";
            SqlCommand komutplakabulucu = new SqlCommand(sorguplakabulucu, baglanti);

            string sorguucretbulucu = "Select kira_ucreti from arac where marka='" + araccombo.Text + "'";
            SqlCommand komutucretbulucu = new SqlCommand(sorguucretbulucu, baglanti);




            markatext.Text = (string)komutmarkabulucu.ExecuteScalar();
            serinotext.Text = (string)komutseribulucu.ExecuteScalar();
            renktext.Text = (string)komutrenkbulucu.ExecuteScalar();
            modelyilitext.Text = (string)komutmodelbulucu.ExecuteScalar();
            plakatextbox.Text = (string)komutplakabulucu.ExecuteScalar();
            ucrettext.Text = (string)komutucretbulucu.ExecuteScalar();

            baglanti.Close();




        }

        void tcbulucu()
        {
            baglanti.Close();
            baglanti.Open();

            string sorgutcbulucu = "Select tc from musteri where TC='" + txtTcAra.Text + "'";
            SqlCommand komuttcbulucu = new SqlCommand(sorgutcbulucu, baglanti);

            string sorguadbulucu = "Select adsoyad from musteri where TC='" + txtTcAra.Text + "'";
            SqlCommand komutadbulucu = new SqlCommand(sorguadbulucu, baglanti);


            string sorgutelefonbulucu = "Select telefon from msuteri where TC='" + txtTcAra.Text + "'";
            SqlCommand komuttelefonbulucu = new SqlCommand(sorgutelefonbulucu, baglanti);


            tcnotextbox.Text = (string)komuttcbulucu.ExecuteScalar();

            adsoyadtextbox.Text = (string)komutadbulucu.ExecuteScalar();

            telnotextbox.Text = (string)komuttelefonbulucu.ExecuteScalar();

            baglanti.Close();

        }

        private void sozlesme_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Class1.dtdoldur("SELECT * FROM sözleşme");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "TC";
            dataGridView1.Columns[2].HeaderText = "Ad Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Ehliyet No";
            dataGridView1.Columns[5].HeaderText = "Ehliyet Tarihi";
            dataGridView1.Columns[6].HeaderText = "Ehliyet Yeri";
            dataGridView1.Columns[7].HeaderText = "Plaka";
            dataGridView1.Columns[8].HeaderText = "Marka";
            dataGridView1.Columns[9].HeaderText = "Seri";
            dataGridView1.Columns[10].HeaderText = "Yıl";
            dataGridView1.Columns[11].HeaderText = "Renk";
            dataGridView1.Columns[12].HeaderText = "Kira Şekli";

            dataGridView1.Columns[13].HeaderText = "Kira Ücreti";
            dataGridView1.Columns[14].HeaderText = "Gün";
            dataGridView1.Columns[15].HeaderText = "Tutar";
            dataGridView1.Columns[16].HeaderText = "Çıkış Tarihi";
            dataGridView1.Columns[17].HeaderText = "Dönüş Tarihi";


            listele();
            bostaolanaracibul();

            label22.Text = "Toplam " + dataGridView1.Rows.Count.ToString() + " kayıt listelendi.";


        }
        Class1 clas = new Class1();


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            aracbulucu();

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            tcnotextbox.Text = satır.Cells[1].Value.ToString();
            adsoyadtextbox.Text = satır.Cells[2].Value.ToString();
            telnotextbox.Text = satır.Cells[3].Value.ToString();
            ehliyetnotextbox.Text = satır.Cells[4].Value.ToString();
            ehliyettarihitextbox.Text = satır.Cells[5].Value.ToString();
            ehliyetyertextbox.Text = satır.Cells[6].Value.ToString();
            plakatextbox.Text = satır.Cells[7].Value.ToString();
            markatext.Text = satır.Cells[8].Value.ToString();
            serinotext.Text = satır.Cells[9].Value.ToString();
            modelyilitext.Text = satır.Cells[10].Value.ToString();
            renktext.Text = satır.Cells[11].Value.ToString();
            kisaseklicombo.Text = satır.Cells[12].Value.ToString();
            ucrettext.Text = satır.Cells[13].Value.ToString();
            guntext.Text = satır.Cells[14].Value.ToString();
            tutartext.Text = satır.Cells[15].Value.ToString();
            cikistarihitext.Text = satır.Cells[16].Value.ToString();
            donustarihitext.Text = satır.Cells[17].Value.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "update sözleşme set tc=@tc, adsoyad=@adsoyad, telefon=@telefon, ehliyetno=@ehliyetno, e_tarih=@e_tarih, e_yer=@e_yer, marka=@marka, seri=@seri, yil=@yil, renk=@renk, plaka=@plaka, kirasekli=@kirasekli, kiraucreti=@kiraucreti, gün=@gün, tutar=@tutar, ctarih=@ctarih, dtarih=@ctarih where tc=@tc";
            SqlCommand guncelle = new SqlCommand(kayit, baglanti);
            guncelle.Parameters.AddWithValue("@tc", tcnotextbox.Text);
            guncelle.Parameters.AddWithValue("@adsoyad", adsoyadtextbox.Text);
            guncelle.Parameters.AddWithValue("@telefon", telnotextbox.Text);
            guncelle.Parameters.AddWithValue("@ehliyetno", ehliyetnotextbox.Text);
            guncelle.Parameters.AddWithValue("@e_tarih", ehliyettarihitextbox.Text);
            guncelle.Parameters.AddWithValue("@e_yer", ehliyetyertextbox.Text);
            guncelle.Parameters.AddWithValue("@marka", markatext.Text);
            guncelle.Parameters.AddWithValue("@seri", serinotext.Text);
            guncelle.Parameters.AddWithValue("@yil", modelyilitext.Text);
            guncelle.Parameters.AddWithValue("@renk", renktext.Text);
            guncelle.Parameters.AddWithValue("@plaka", plakatextbox.Text);
            guncelle.Parameters.AddWithValue("@kirasekli", kisaseklicombo.Text);
            guncelle.Parameters.AddWithValue("@gün", int.Parse(guntext.Text));
            guncelle.Parameters.AddWithValue("@tutar", int.Parse(tutartext.Text));
            guncelle.Parameters.AddWithValue("@kiraucreti", int.Parse(ucrettext.Text));
            guncelle.Parameters.AddWithValue("@ctarih", cikistarihitext.Text);
            guncelle.Parameters.AddWithValue("@dtarih", donustarihitext.Text);

            guncelle.ExecuteNonQuery();
            dataGridView1.DataSource = Class1.dtdoldur("select * from sözleşme");
            baglanti.Close();
            MessageBox.Show("KAYIT BİLGİLERİ GÜNCELLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(donustarihitext.Text) - DateTime.Parse(cikistarihitext.Text);
            int gun2 = gun.Days;
            guntext.Text = gun2.ToString();
            tutartext.Text = (gun2 * int.Parse(ucrettext.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Aracı teslim etmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {


                baglanti.Close();
                baglanti.Open();


                baglanti.Close();
                baglanti.Open();
                kmt.Connection = baglanti;
                kmt.CommandText = "INSERT INTO satış (tc,adsoyad, marka, seri, yil, renk, plaka, gun, fiyat, tutar, tarih1, tarih2  ) VALUES ('" + tcnotextbox.Text + "','" + adsoyadtextbox.Text + "','" + markatext.Text + "','" + serinotext.Text + "','" + modelyilitext.Text + "','" + renktext.Text + "','" + plakatextbox.Text + "','" + guntext.Text + "','" + ucrettext.Text + "','" + tutartext.Text + "','" + cikistarihitext.Value + "','" + donustarihitext.Value + "')";
                kmt.ExecuteNonQuery();
                kmt.Dispose();

                baglanti.Close();
                baglanti.Open();
                SqlCommand kmtsil;
                kmtsil = new SqlCommand("Delete from sözleşme where sozlesme_ID = " + dataGridView1.CurrentRow.Cells[0].Value.ToString(), baglanti);
                kmtsil.ExecuteNonQuery();
                kmtsil.Dispose();

                baglanti.Close();
                baglanti.Open();


                string drmgnclle = "update arac set durumu ='BOŞ' where plaka= '" + plakatextbox.Text + "'";
                SqlCommand kmt2 = new SqlCommand(drmgnclle, baglanti);
                kmt2.ExecuteNonQuery();
                kmt2.Dispose();

                listele();
                baglanti.Close();
                MessageBox.Show("Araç teslim edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Temizle();
        }



        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Class1.dtdoldur("select * from SÖZLEŞME where TC like '%" + textBox14.Text + "%'");
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "TC";
            dataGridView1.Columns[2].HeaderText = "Ad Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon NO";
            dataGridView1.Columns[4].HeaderText = "Ehliyet Numarası";
            dataGridView1.Columns[5].HeaderText = "Ehliyet Tarihi";
            dataGridView1.Columns[6].HeaderText = "Ehliyetin Verildiği Yer";
            dataGridView1.Columns[7].HeaderText = "Plaka";
            dataGridView1.Columns[8].HeaderText = "Marka";
            dataGridView1.Columns[9].HeaderText = "Seri";
            dataGridView1.Columns[10].HeaderText = "Yıl";
            dataGridView1.Columns[11].HeaderText = "Renk";
            dataGridView1.Columns[12].HeaderText = "Kira Şekli";
            dataGridView1.Columns[13].HeaderText = "Kira Ücreti";
            dataGridView1.Columns[14].HeaderText = "Gün";
            dataGridView1.Columns[15].HeaderText = "Tutar";
            dataGridView1.Columns[16].HeaderText = "Çıkış Tarihi";
            dataGridView1.Columns[17].HeaderText = "Dönüş Tarihi";


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow satır = dataGridView1.CurrentRow;
                DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
                DateTime dönüş = DateTime.Parse(satır.Cells["dtarih"].Value.ToString());
                int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
                TimeSpan gunfarkı = bugün - dönüş;
                int _günfarkı = gunfarkı.Days;
                int ucretfarkı;
                ucretfarkı = _günfarkı * ucret;
                textBox15.Text = ucretfarkı.ToString();
            }
            catch
            {
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Class1.dtdoldur("select * from sözleşme where TC like '%" + tcnotextbox.Text + "%'");

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            if (txtTcAra.Text == "") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            string sorgu2 = "select *from musteri where tc like '" + txtTcAra.Text + "'";
            tcbulucu(txtTcAra, tcnotextbox, adsoyadtextbox, telnotextbox, sorgu2);
        }

        public void tcbulucu(TextBox txtTcAra, TextBox tcnotextbox, TextBox adsoyadtextbox, TextBox telnotextbox, string sorgu2)
        {
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu2, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                tcnotextbox.Text = read["tc"].ToString();
                adsoyadtextbox.Text = read["adsoyad"].ToString();
                telnotextbox.Text = read["telefon"].ToString();

            }
            baglanti.Close();
        }

    }
}

