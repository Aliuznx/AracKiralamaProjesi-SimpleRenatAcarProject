using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Araç_Kiralama_Otomasyonu
{
    class Class1
    {
        private SqlConnection baglanti;
        public static SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ("Data Source=localhost;Initial Catalog=Araç_Kiralama_Otomasyonu;User=sa;Password=405523");
            return baglanti;


        }
       
        public static DataTable dtdoldur(string SqlSorgusu)
        {


            SqlConnection baglanti = baglan();
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter(SqlSorgusu, baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            baglanti.Close();
            return dt;
        }


        public void bos_arac(ComboBox combo, string sorgu)
        {
            baglanti.Open();
            SqlCommand boagetir = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = boagetir.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read["plaka"].ToString());
            }
            baglanti.Close();
        }

        public void satishesapla(SqlCommand komut, Label lbl, string sorgu)
        {
            baglanti.Open();
            komut = new SqlCommand();
            lbl.Text = "toplamtutar=" + komut.ExecuteScalar() + "TL";
            baglanti.Close();
        }

       

       
        public void CombodanGetir(ComboBox araclar, TextBox marka, TextBox seri, TextBox yil, TextBox renk, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                marka.Text = read["marka"].ToString();
                seri.Text = read["seri"].ToString();
                yil.Text = read["yil"].ToString();
                renk.Text = read["renk"].ToString();
            }
            baglanti.Close();

            
        }
    }
}
