﻿using KutuphaneOtomasyonum.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonum.controllers
{
    public class controller
    {
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


    }
}
