using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonum.Ado
{
    public class repository
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public repository()
        {
            con = new SqlConnection("Data Source=SEFA\\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa;password=1");
        }

        public users login(string kullaniciadi,string sifre)
        {
            List<users> userList = new List<users>();
            con.Open();
            cmd = new SqlCommand("select * from loginTable where kullaniciAdi=@p1 and sifre=@p2", con);
            cmd.Parameters.AddWithValue("@p1", kullaniciadi);
            cmd.Parameters.AddWithValue("@p2", sifre);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                users users = new users();
                users.id =int.Parse(dr["id"].ToString());
                users.adi = dr["adi"].ToString();
                users.soyadi = dr["soyAdi"].ToString();
                users.kullaniciadi = dr["kullaniciAdi"].ToString();
                users.sifre = dr["sifre"].ToString();
                users.yetki = dr["yetki"].ToString();
                users.dogumTarihi = dr["dogumTarihi"].ToString();
                users.emailadres = dr["emailAdres"].ToString();
                userList.Add(users);
                con.Close();
                users.status = loginStatus.basarili;
                return users;                

            }
            else
            {
                users users = new users();
                users.status = loginStatus.basarisiz;
                return users;
            }      
        }

        public List<kitap> kitaplariGetir()
        {
            List<kitap> kitapList = new List<kitap>();
            con = new SqlConnection("Data Source=SEFA\\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa;password=1");
            con.Open();
            cmd = new SqlCommand("select * from kitap", con);
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                kitap kitap = new kitap();
                kitap.kitapID =int.Parse( dr["kitapID"].ToString());
                kitap.Kitapİsmi = dr["Kitapİsmi"].ToString();
                kitap.Yazari = dr["Yazari"].ToString();
                kitap.SayfaSayisi = int.Parse( dr["SayfaSayisi"].ToString());
                kitap.YayinEvi =dr["YayinEvi"].ToString();
                kitap.BasimYili =int.Parse(dr["BasimYili"].ToString());
                kitapList.Add(kitap);
            }
            con.Close();
            return kitapList;

        }

        public loginStatus kitapKaydet(kitap kitap)
        {
            con.Open();
            cmd = new SqlCommand("insert into kitap(kitapID,Kitapİsmi,Yazari,SayfaSayisi,YayinEvi,BasimYili) values(@p1,@p2,@p3,@p4,@p5,p6)", con);
            cmd.Parameters.AddWithValue("@p1",kitap.kitapID);
            cmd.Parameters.AddWithValue("@p2", kitap.Kitapİsmi);
            cmd.Parameters.AddWithValue("@p3",kitap.Yazari);
            cmd.Parameters.AddWithValue("@p4", kitap.SayfaSayisi);
            cmd.Parameters.AddWithValue("@p5", kitap.YayinEvi);
            cmd.Parameters.AddWithValue("@p6", kitap.BasimYili);

            int returnValue =cmd.ExecuteNonQuery();
            con.Close();

            if (returnValue==1)
            {
                return loginStatus.basarili;
            }
            else
            {
                return loginStatus.basarisiz;
            }

              




        }


    }
}
