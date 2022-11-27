using KutuphaneOtomasyonum.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonum.controllers
{

    public class controller

    {
        repository repository = new repository();
        public controller()
        {
            repository repository = new repository();
        }

        public users login(string kullaniciadi, string sifre)
        {
            users gelenDeger;
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                repository repository = new repository();
                gelenDeger = repository.login(kullaniciadi, sifre);
                return gelenDeger;
                
            }
            else
            {
                users users= new users();
                users.status = loginStatus.eksikParametre;
                return users;
            }

        }
        public loginStatus kitapKaydet(kitap kitap)
        {
            if (!string.IsNullOrEmpty(kitap.kitapID.ToString()) && !string.IsNullOrEmpty(kitap.Kitapİsmi) && !string.IsNullOrEmpty(kitap.Yazari) && !string.IsNullOrEmpty(kitap.SayfaSayisi.ToString()) && !string.IsNullOrEmpty(kitap.YayinEvi) && !string.IsNullOrEmpty(kitap.BasimYili.ToString()))
            {
                

                return repository.kitapKaydet(kitap);
            }
            else
            {
                return loginStatus.eksikParametre;
            }
                



             

        }
        public List<kitap> kitaplariGetir()
        {
            repository repository = new repository();
            return repository.kitaplariGetir();


        }


    }
}
