using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Competitor
    {
        private int Id, Kd_kota;
        private string Nm_competitor, Alamat;
        public Competitor(int id, int kd_kota, string nm_competitor, string alamat)
        {
            this.id = id;
            this.kd_kota = kd_kota;
            this.nm_competitor = nm_competitor;
            this.alamat = alamat;
        }
        public int id { get { return Id; } set { Id = value; } }
        public int kd_kota { get { return Kd_kota; } set { Kd_kota = value; } }
        public string nm_competitor { set { Nm_competitor = value; } get { return Nm_competitor; } }
        public string alamat { set { Alamat = value; } get { return Alamat; } }
        public string getNm_competitor()
        {
            return nm_competitor;
        }

        public void setNm_competitor(string nm_competitor)
        {
            this.nm_competitor = nm_competitor;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getKd_kota()
        {
            return kd_kota;
        }

        public void setKd_kota(int kd_kota)
        {
            this.kd_kota = kd_kota;
        }

        public string getAlamat()
        {
            return alamat;
        }

        public void setAlamat(string alamat)
        {
            this.alamat = alamat;
        }

    }
}
