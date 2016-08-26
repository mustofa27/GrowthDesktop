using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Outlet
    {
        private int kode;
        private int kode_kota;
        private int kode_distributor;
        private int kode_user;
        private int tipe;
        private int status_area;
        private string nama, namaPIC, alamat, rank, telpon, reg_status, longitude, latitude, telpPIC/*, foto*/;
        public Outlet(int kd, int kd_kota, int kd_user, int kode_distributor, string nama, string alamat, int tipe, string rank, string telpon, string reg_status, string latitude, string longitude, string namaPIC, string telpPIC, int status_area)
        {
            setKode(kd);
            setKode_kota(kd_kota);
            setKode_user(kd_user);
            setNama(nama);
            setAlamat(alamat);
            setKode_distributor(kode_distributor);
            setTipe(tipe);
            setRank(rank);
            setTelpon(telpon);
            setReg_status(reg_status);
            setLatitude(latitude);
            setLongitude(longitude);
            setNamaPIC(namaPIC);
            setTelpPIC(telpPIC);
            setStatus_area(status_area);
        }

        public string getTelpPIC()
        {
            return telpPIC;
        }

        public void setTelpPIC(string telpPIC)
        {
            this.telpPIC = telpPIC;
        }

        public string getNamaPIC()
        {
            return namaPIC;
        }

        public void setNamaPIC(string namaPIC)
        {
            this.namaPIC = namaPIC;
        }

        public int getStatus_area()
        {
            return status_area;
        }

        public void setStatus_area(int status_area)
        {
            this.status_area = status_area;
        }
        public int getKode()
        {
            return kode;
        }

        public void setKode(int kode)
        {
            this.kode = kode;
        }

        public int getKode_kota()
        {
            return kode_kota;
        }

        public void setKode_kota(int kode_kota)
        {
            this.kode_kota = kode_kota;
        }

        public int getKode_distributor()
        {
            return kode_distributor;
        }

        public void setKode_distributor(int kode_distributor)
        {
            this.kode_distributor = kode_distributor;
        }

        public int getKode_user()
        {
            return kode_user;
        }

        public void setKode_user(int kode_user)
        {
            this.kode_user = kode_user;
        }

        public string getNama()
        {
            return nama;
        }

        public void setNama(string nama)
        {
            this.nama = nama;
        }

        public string getAlamat()
        {
            return alamat;
        }

        public void setAlamat(string alamat)
        {
            this.alamat = alamat;
        }

        public int getTipe()
        {
            return tipe;
        }

        public void setTipe(int tipe)
        {
            this.tipe = tipe;
        }

        public string getRank()
        {
            return rank;
        }

        public void setRank(string rank)
        {
            this.rank = rank;
        }

        public string getTelpon()
        {
            return telpon;
        }

        public void setTelpon(string telpon)
        {
            this.telpon = telpon;
        }

        public string getLongitude()
        {
            return longitude;
        }

        public void setLongitude(string longitude)
        {
            this.longitude = longitude;
        }

        public string getLatitude()
        {
            return latitude;
        }

        public void setLatitude(string latitude)
        {
            this.latitude = latitude;
        }

        public string getReg_status()
        {
            return reg_status;
        }

        public void setReg_status(string reg_status)
        {
            this.reg_status = reg_status;
        }
    }
}
