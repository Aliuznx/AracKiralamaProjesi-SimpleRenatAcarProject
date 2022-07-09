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
    public partial class Giris : Form
    {
        SqlConnection baglanti = Class1.baglan();
        public Giris()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {

            musteriekle frmmusteriekle = new musteriekle();
            frmmusteriekle.ShowDialog();
        }



        public string filtre { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            arac_islemleri arac_islemleri = new arac_islemleri();
            arac_islemleri.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sozlesme sozlesme = new sozlesme();
            sozlesme.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri_listele musteri_listele = new musteri_listele();
            musteri_listele.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmsatıs frmsatıs = new frmsatıs();
            frmsatıs.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
        }
    }
}
