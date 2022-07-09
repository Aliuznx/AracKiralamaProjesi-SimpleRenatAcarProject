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
    public partial class musteriekle : Form
    {
       
        
        SqlConnection baglanti = Class1.baglan();
        
        public musteriekle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
               
                SqlCommand ekle = new SqlCommand("insert into musteri values (@TC, @adsoyad, @telefon, @adres, @mail) ",baglanti);
                ekle.Parameters.AddWithValue("@TC", textBox1.Text);
                ekle.Parameters.AddWithValue("@adsoyad", textBox2.Text);
                ekle.Parameters.AddWithValue("@telefon", textBox3.Text);
                ekle.Parameters.AddWithValue("@adres", textBox4.Text);
                ekle.Parameters.AddWithValue("@mail", textBox5.Text);
                ekle.ExecuteNonQuery();
                MessageBox.Show("MÜŞTERİ BAŞARIYLA EKLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
            }
            catch (Exception )
            {

                MessageBox.Show("hatalı bilgi girildi");
            }

            finally
            {
                foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                {
                    
                }
                baglanti.Close();

            }
        }

      
}
  }

 
       
