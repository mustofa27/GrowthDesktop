using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Area
    {
        private int id_area;
        private string nama,kode;
        public Area(int id, string kode, string nama)
        {
            setKode(kode);
            setNama(nama);
            setid(id);
        }
        public int id { set { id_area = value; } get { return id_area; } }
        public string nm_area { set { nama = value; } get { return nama; } }
        public string kd_area { set { kode = value; } get { return kode; } }
        public void setid(int id)
        {
            this.id_area = id;
        }

        public int getid()
        {
            return id_area;
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
