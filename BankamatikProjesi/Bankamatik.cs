using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankamatikProjesi
{
    public partial class Bankamatik : Form
    {
        public Bankamatik()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-T6JACR2\SQLEXPRESS;Initial Catalog=BankamatikProjesi;Integrated Security=True");

        private void LnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Bankamatik3 bnk = new Bankamatik3();
            bnk.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKISILER where hesapno=@p1 and sıfre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", MskHesap.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Bankamatik2 bn = new Bankamatik2();
                bn.hesap = MskHesap.Text;
                bn.Show();
            }
            else
            {
                MessageBox.Show("Girilen bilgiler hatalıdır. Tekrar Deneyiniz.");
            }
            baglanti.Close();
        }
    }
}
