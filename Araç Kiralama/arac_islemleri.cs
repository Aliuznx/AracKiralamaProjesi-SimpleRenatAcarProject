using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Araç_Kiralama_Otomasyonu
{
    public partial class arac_islemleri : Form
    {
        SqlConnection baglanti = Class1.baglan();
        public arac_islemleri()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox6.Text = openFileDialog1.FileName;
            
        }
        public void A_Listele()
        {
            baglanti.Open();
            string getir = "select * from arac";
            SqlCommand a_Getir = new SqlCommand(getir, baglanti);
            SqlDataAdapter sda1 = new SqlDataAdapter(a_Getir);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string arac_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand silme_islemi = new SqlCommand("DELETE FROM arac where aracID=" + arac_no, baglanti);
            silme_islemi.ExecuteNonQuery();
            MessageBox.Show("Araç Başarıyla Silindi");
            baglanti.Close();
            A_Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand arac_kaydet = new SqlCommand("INSERT INTO arac (plaka, marka, seri, yil, renk, KM, yakıt, kira_ucreti, durumu, tarih, resim)VALUES(@plaka, @marka, @seri, @yil, @renk, @KM, @yakıt, @kira_ucreti, @durumu, @tarih, @resim)", baglanti);
            arac_kaydet.Parameters.AddWithValue("@plaka", textBox1.Text);
            arac_kaydet.Parameters.AddWithValue("@marka", textBox2.Text);
            arac_kaydet.Parameters.AddWithValue("@seri", textBox3.Text);
            arac_kaydet.Parameters.AddWithValue("@yil", textBox4.Text);
            arac_kaydet.Parameters.AddWithValue("@renk", textBox5.Text);


            arac_kaydet.Parameters.AddWithValue("@KM", textBox7.Text);
            arac_kaydet.Parameters.AddWithValue("@yakıt", comboBox1.Text);
            arac_kaydet.Parameters.AddWithValue("@kira_ucreti", textBox9.Text);
            arac_kaydet.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
            arac_kaydet.Parameters.AddWithValue("@durumu", textBox11.Text);
            arac_kaydet.Parameters.AddWithValue("@resim", textBox6.Text);

            arac_kaydet.ExecuteNonQuery();
            MessageBox.Show("ARAÇ BAŞARIYLA EKLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            textBox9.Text = "";
            dateTimePicker1.Text = "";
            textBox11.Text = "";
            pictureBox1.ImageLocation = "";
            baglanti.Close();
            dataGridView1.DataSource = Class1.dtdoldur("select * from arac");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void arac_islemleri_Load(object sender, EventArgs e)
        {
            
            
            textBox11.SelectedIndex=0;
            
            dataGridView1.DataSource = Class1.dtdoldur("SELECT * FROM arac");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Plaka";
            dataGridView1.Columns[2].HeaderText = "Marka";
            dataGridView1.Columns[3].HeaderText = "Seri";
            dataGridView1.Columns[4].HeaderText = "Yıl";
            dataGridView1.Columns[5].HeaderText = "Renk";
            dataGridView1.Columns[6].HeaderText = "KM";
            dataGridView1.Columns[7].HeaderText = "Yakıt";
            dataGridView1.Columns[8].HeaderText = "Kira Ücreti";
            dataGridView1.Columns[9].HeaderText = "Durumu";
            dataGridView1.Columns[10].HeaderText = "Traihi";
            dataGridView1.Columns[11].HeaderText = "Resim Yolu";
            label12.Text = "Toplam " + dataGridView1.Rows.Count.ToString() + " kayıt listelendi.";
           
        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            textBox1.Text = satır.Cells[1].Value.ToString();
            textBox2.Text = satır.Cells[2].Value.ToString();
            textBox3.Text = satır.Cells[3].Value.ToString();
            textBox4.Text = satır.Cells[4].Value.ToString();
            textBox5.Text = satır.Cells[5].Value.ToString();
            textBox7.Text = satır.Cells[6].Value.ToString();
            comboBox1.Text = satır.Cells[7].Value.ToString();
            textBox9.Text = satır.Cells[8].Value.ToString();
            dateTimePicker1.Text = satır.Cells[10].Value.ToString();
            textBox11.Text = satır.Cells[9].Value.ToString();
            textBox6.Text = satır.Cells[11].Value.ToString();
            pictureBox1.ImageLocation = satır.Cells[11].Value.ToString();


        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Class1.dtdoldur("select * from arac where plaka like '%" + textBox12.Text + "%'");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image.Width < pictureBox1.Width && pictureBox1.Image.Height < pictureBox1.Height)
            {
                pictureBox1.Width = pictureBox1.Image.Width;
                pictureBox1.Height = pictureBox1.Image.Height;
            }
        }

        private void arac_islemleri_SizeChanged(object sender, EventArgs e)
        {
          
        }

        private void arac_islemleri_Resize(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.aracislemleriekrani);
        }
    }
}
