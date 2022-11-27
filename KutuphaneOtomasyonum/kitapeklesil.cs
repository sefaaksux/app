using KutuphaneOtomasyonum.controllers;
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
using KutuphaneOtomasyonum;

namespace KutuphaneOtomasyonum
{
    public partial class kitapeklesil : Form
    {
        controller controller = new controller();


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
            controller controller = new controller();
            kitaplariGetir();




        }

        private void kitaplariGetir()
        {
            List<kitap> kitapList = controller.kitaplariGetir();
            dataGridView1.DataSource = kitapList;
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            kitap kitap = new kitap();
            kitap.kitapID =int.Parse( txt_kitapID.Text);
            kitap.Yazari = txt_kitapyazari.Text;
            kitap.Kitapİsmi = txt_kitapismi.Text;
            kitap.SayfaSayisi =int.Parse( txt_sayfasayisi.Text);
            kitap.BasimYili = int.Parse(txt_basimyili.Text);
            kitap.YayinEvi = txt_yayinevi.Text;


           loginStatus donenDeger = controller.kitapKaydet(kitap);

            if(donenDeger==loginStatus.basarili)
            {
                MessageBox.Show("Kayıt başarıyla eklendi", "bilgi", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("eksik parametre girdiniz.");
            }
            kitaplariGetir();

        }
    }
}
