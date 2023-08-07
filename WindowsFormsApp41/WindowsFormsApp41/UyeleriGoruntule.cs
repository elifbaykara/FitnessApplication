using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace WindowsFormsApp41
{
    public partial class UyeleriGoruntule : Form
    {
        public UyeleriGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\elif\Documents\SporDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void UyeleriGoruntule_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        private void Adfiltrele()
        {
            baglanti.Open();
            string query = "select *from UyeTbl where UAdSoyad='" + AraUyeTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Adfiltrele();
            AraUyeTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void AraUyeTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
