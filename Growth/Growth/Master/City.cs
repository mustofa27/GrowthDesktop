﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class City
    {
        private int kode, kodeArea;
        string nama;
        public int id { set { kode = value; } get { return kode; } }
        public int kd_area { set { kodeArea = value; } get { return kodeArea; } }
        public string nm_kota { set { nama = value; } get { return nama; } }
        public string nm_area { set; get; }
        public string kode_area { get; set; }
        public City(int kode, int kodeArea, string nama)
        {
            setKode(kode);
            setKodeArea(kodeArea);
            setNama(nama);
        }

        public void setKode(int kode)
        {
            this.kode = kode;
        }

        public int getKode()
        {
            return kode;
        }

        public int getKodeArea()
        {
            return kodeArea;
        }

        public void setKodeArea(int kodeArea)
        {
            this.kodeArea = kodeArea;
        }

        public string getNama()
        {
            return nama;
        }

        public void setNama(string nama)
        {
            this.nama = nama;
        }

    }
}
