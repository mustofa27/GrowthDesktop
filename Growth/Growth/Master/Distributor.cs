using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Distributor
    {
        private int id, kd_kota;
        private string kd_dist, kd_tipe, nm_dist, almt_dist, telp_dist;
        public Distributor(int id, string kd_dist, string kd_tipe, int kd_kota, string nm_dist, string almt_dist, string telp_dist)
        {
            setId(id);
            setKd_dist(kd_dist);
            setKd_tipe(kd_tipe);
            setKd_kota(kd_kota);
            setNm_dist(nm_dist);
            setAlmt_dist(almt_dist);
            setTelp_dist(telp_dist);
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return id;
        }

        public void setKd_dist(string kd_dist)
        {
            this.kd_dist = kd_dist;
        }

        public string getKd_dist()
        {
            return kd_dist;
        }

        public void setKd_tipe(string kd_tipe)
        {
            this.kd_tipe = kd_tipe;
        }

        public string getKd_tipe()
        {
            return kd_tipe;
        }

        public void setKd_kota(int kd_kota)
        {
            this.kd_kota = kd_kota;
        }

        public int getKd_kota()
        {
            return kd_kota;
        }

        public void setNm_dist(string nm_dist)
        {
            this.nm_dist = nm_dist;
        }

        public string getNm_dist()
        {
            return nm_dist;
        }

        public void setAlmt_dist(string almt_dist)
        {
            this.almt_dist = almt_dist;
        }

        public string getAlmt_dist()
        {
            return almt_dist;
        }

        public void setTelp_dist(string telp_dist)
        {
            this.telp_dist = telp_dist;
        }

        public string getTelp_dist()
        {
            return telp_dist;
        }

    }
}
