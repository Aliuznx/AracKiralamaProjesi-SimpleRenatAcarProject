using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Araç_Kiralama_Otomasyonu
{
    public partial class frmsatıs : Form
    {
        SqlConnection baglanti = Class1.baglan();
        public frmsatıs()
        {
            InitializeComponent();
        }

        
        private void frmsatıs_Load(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }

            dataGridView1.DataSource = Class1.dtdoldur("SELECT * FROM satış");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "TC";
            dataGridView1.Columns[2].HeaderText = "Ad Soyad";
            dataGridView1.Columns[3].HeaderText = "Plaka";
            dataGridView1.Columns[4].HeaderText = "Marka";
            dataGridView1.Columns[5].HeaderText = "Seri";
            dataGridView1.Columns[6].HeaderText = "Yıl";
            dataGridView1.Columns[7].HeaderText = "Renk";
            dataGridView1.Columns[8].HeaderText = "Gün";
            dataGridView1.Columns[9].HeaderText = "Fiyat";
            dataGridView1.Columns[10].HeaderText = "Tutar";
            dataGridView1.Columns[11].HeaderText = "Çıkış Tarihi";
            dataGridView1.Columns[12].HeaderText = "Dönüş Tarihi";

            baglanti.Close();

            label2.Text = "Toplam " + dataGridView1.Rows.Count.ToString() + " kayıt listelendi.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Class1.dtdoldur("select * from satış where TC like '%" + textBox1.Text + "%'");

        }

    }
}
