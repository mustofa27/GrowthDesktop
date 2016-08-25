using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Area
    {
        private int id;
        private string nama,kode;
        public Area(int id, string kode, string nama)
        {
            setKode(kode);
            setNama(nama);
            setid(id);
        }

        public void setid(int id)
        {
            this.id = id;
        }

        public int getid()
        {
            return id;
        }

        public void setNama(string nama)
        {
            this.nama = nama;
        }

        public string getNama()
        {
            return nama;
        }
        public void setKode(string kode)
        {
            this.kode = kode;
        }

        public string getKode()
        {
            return kode;
        }
    }
}
