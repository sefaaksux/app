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

namespace KutuphaneOtomasyonum
{
    public partial class kitapeklesil : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public kitapeklesil()
        {
            InitializeComponent();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void kitapeklesil_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void kitaplariGetir()
        {
            List<kitap> kitaplist = new List<kitap>();
            con = new SqlConnection("Data Source=SEFA\\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa;password=1");
            con.Open();
            cmd = new SqlCommand("select * from kitap", con);
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                kitap kitap = new kitap();
                kitap.kitapID =int.Parse( dr["ID"].ToString());
                kitap.Kitapİsmi = dr["Kitapİsmi"].ToString();
                kitap.Yazari = dr["yazari"].ToString();
                kitap.SayfaSayisi =int.Parse( dr["SayfaSayisi"].ToString());
                kitap.YayinEvi = dr["Kitapİsmi"].ToString();
                kitap.BasimYili =int.Parse( dr["Kitapİsmi"].ToString());
                kitaplist.Add(kitap);


            }



    }

    }
}
