using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Araç_Kiralama_Otomasyonu
{
    public partial class musteri_listele : Form
    {
       SqlConnection baglanti = Class1.baglan();
        public musteri_listele()
        {
            InitializeComponent();
        }
        public void musterigetir()
        {
            dataGridView1.DataSource = Class1.dtdoldur("select TC, adsoyad, telefon, adres, mail from musteri");


        }

        public void Temizle()
        {
            
          
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void musteri_listele_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Class1.dtdoldur("SELECT * FROM musteri");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "TC";
            dataGridView1.Columns[2].HeaderText = "Ad Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[5].HeaderText = "E Mail";
            labelKayitsayisi.Text = "Toplam "+ dataGridView1.Rows.Count.ToString() +" kayıt listelendi.";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            textBox1.Text = satır.Cells[1].Value.ToString();
            textBox2.Text = satır.Cells[2].Value.ToString();
            textBox3.Text = satır.Cells[3].Value.ToString();
            textBox4.Text = satır.Cells[4].Value.ToString();
            textBox5.Text = satır.Cells[5].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "update musteri set TC=@TC, adsoyad=@adsoyad, telefon=@telefon, adres=@adres, mail=@mail where TC=@TC";
            SqlCommand guncelle = new SqlCommand(kayit, baglanti);
            guncelle.Parameters.AddWithValue("@TC", textBox1.Text);
            guncelle.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@telefon", textBox3.Text);
            guncelle.Parameters.AddWithValue("@adres", textBox4.Text);
            guncelle.Parameters.AddWithValue("@mail", textBox5.Text);
            guncelle.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("KAYIT BAŞARIYLA GÜNCELLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            musterigetir();
            Temizle();

            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Class1.dtdoldur("select * from musteri where TC like '%" + textBox6.Text + "%'");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string silme = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand silme_islemi = new SqlCommand("DELETE FROM musteri where MusteriID=" + silme, baglanti);
            silme_islemi.ExecuteNonQuery();
            dataGridView1.DataSource = Class1.dtdoldur("select * from musteri");
            MessageBox.Show("MÜŞTERİ BAŞARIYLA SİLİNDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            dataGridView1.Columns[1].HeaderText = "TC";
            dataGridView1.Columns[2].HeaderText = "Ad Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[5].HeaderText = "E Mail";

      

         }
    }
}
