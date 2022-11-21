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

        public void kitaplariGetir()
        {
            con = new SqlConnection("Data Source=SEFA\\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa;password=1");
            con.Open();
            cmd = new SqlCommand("select * from kitap", con);
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {



            }
           


        }

    }
}
