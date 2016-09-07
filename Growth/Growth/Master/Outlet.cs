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
        private int Status_area,toleransi;
        private string nama, namaPIC, alamat, rank, telpon, Reg_status, Kodepos, Longitude, Latitude, telpPIC, foto;
        public string kota { set; get; }
        public string area { set; get; }
        public string nm_tipe { set; get; }
        public int kd_outlet
        {
            get
            {
                return kode;
            }

            set
            {
                kode = value;
            }
        }

        public int kd_kota
        {
            get
            {
                return kode_kota;
            }

            set
            {
                kode_kota = value;
            }
        }

        public int kd_dist
        {
            get
            {
                return kode_distributor;
            }

            set
            {
                kode_distributor = value;
            }
        }

        public int kd_user
        {
            get
            {
                return kode_user;
            }

            set
            {
                kode_user = value;
            }
        }

        public int kd_tipe
        {
            get
            {
                return tipe;
            }

            set
            {
                tipe = value;
            }
        }

        public int status_area
        {
            get
            {
                return Status_area;
            }

            set
            {
                Status_area = value;
            }
        }

        public int toleransi_long
        {
            get
            {
                return toleransi;
            }

            set
            {
                toleransi = value;
            }
        }

        public string nm_outlet
        {
            get
            {
                return nama;
            }

            set
            {
                nama = value;
            }
        }

        public string nm_pic
        {
            get
            {
                return namaPIC;
            }

            set
            {
                namaPIC = value;
            }
        }

        public string almt_outlet
        {
            get
            {
                return alamat;
            }

            set
            {
                alamat = value;
            }
        }

        public string rank_outlet
        {
            get
            {
                return rank;
            }

            set
            {
                rank = value;
            }
        }

        public string Telpon
        {
            get
            {
                return telpon;
            }

            set
            {
                telpon = value;
            }
        }

        public string reg_status
        {
            get
            {
                return Reg_status;
            }

            set
            {
                Reg_status = value;
            }
        }

        public string kodepos
        {
            get
            {
                return Kodepos;
            }

            set
            {
                Kodepos = value;
            }
        }

        public string longitude
        {
            get
            {
                return Longitude;
            }

            set
            {
                Longitude = value;
            }
        }

        public string latitude
        {
            get
            {
                return Latitude;
            }

            set
            {
                Latitude = value;
            }
        }

        public string tlp_pic
        {
            get
            {
                return telpPIC;
            }

            set
            {
                telpPIC = value;
            }
        }

        public string foto_outlet
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
            }
        }

        public Outlet(int kd, int kode_distributor, int kd_kota, int kd_user, string nama, string alamat, int tipe, string rank, string telpon, string reg_status, string kodepos, string latitude, string longitude, int toleransi, string foto, string namaPIC, string telpPIC, int status_area)
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
            setFoto(foto);
            setKodepos(kodepos);
            setToleransi(toleransi);
        }

        public string getTelpPIC()
        {
            return telpPIC;
        }

        public void setTelpPIC(string telpPIC)
        {
            this.telpPIC = telpPIC;
        }

        public string getKodepos()
        {
            return Kodepos;
        }

        public void setKodepos(string kodepos)
        {
            this.Kodepos = kodepos;
        }

        public string getFoto()
        {
            return foto;
        }

        public void setFoto(string foto)
        {
            this.foto = foto;
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
            return Status_area;
        }

        public void setStatus_area(int status_area)
        {
            this.Status_area = status_area;
        }

        public int getToleransi()
        {
            return toleransi;
        }

        public void setToleransi(int toleransi)
        {
            this.toleransi = toleransi;
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
            return Longitude;
        }

        public void setLongitude(string longitude)
        {
            this.Longitude = longitude;
        }

        public string getLatitude()
        {
            return Latitude;
        }

        public void setLatitude(string latitude)
        {
            this.Latitude = latitude;
        }

        public string getReg_status()
        {
            return Reg_status;
        }

        public void setReg_status(string reg_status)
        {
            this.Reg_status = reg_status;
        }
    }
}
