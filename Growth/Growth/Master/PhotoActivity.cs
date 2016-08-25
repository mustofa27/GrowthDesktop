using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class PhotoActivity
    {
        private int id, kd_user, kd_outlet, kd_kompetitor, kd_tipe;
        private string nama, tgl_take, tgl_upload, alamat, keterangan, foto;
        public PhotoActivity(int id, int kd_user, int kd_outlet, int kd_kompetitor, int kd_tipe, string nama, string tgl_take, string alamat, string keterangan, string tgl_upload, string foto)
        {
            setId(id);
            setKd_user(kd_user);
            setKd_outlet(kd_outlet);
            setKd_kompetitor(kd_kompetitor);
            setKd_tipe(kd_tipe);
            setNama(nama);
            setTgl_take(tgl_take);
            setAlamat(alamat);
            setKeterangan(keterangan);
            setTgl_upload(tgl_upload);
            setFoto(foto);
        }

        public int getKd_tipe()
        {
            return kd_tipe;
        }

        public void setKd_tipe(int kd_tipe)
        {
            this.kd_tipe = kd_tipe;
        }

        public void setTgl_upload(string tgl_upload)
        {
            this.tgl_upload = tgl_upload;
        }

        public string getTgl_upload()
        {
            return tgl_upload;
        }

        public void setFoto(string foto)
        {
            this.foto = foto;
        }

        public string getFoto()
        {
            return foto;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setAlamat(string alamat)
        {
            this.alamat = alamat;
        }

        public void setKd_kompetitor(int kd_kompetitor)
        {
            this.kd_kompetitor = kd_kompetitor;
        }

        public void setKd_outlet(int kd_outlet)
        {
            this.kd_outlet = kd_outlet;
        }

        public void setKd_user(int kd_user)
        {
            this.kd_user = kd_user;
        }

        public void setKeterangan(string keterangan)
        {
            this.keterangan = keterangan;
        }

        public void setNama(string nama)
        {
            this.nama = nama;
        }

        public void setTgl_take(string tgl_take)
        {
            this.tgl_take = tgl_take;
        }

        public int getId()
        {
            return id;
        }

        public int getKd_kompetitor()
        {
            return kd_kompetitor;
        }

        public int getKd_outlet()
        {
            return kd_outlet;
        }

        public int getKd_user()
        {
            return kd_user;
        }

        public string getAlamat()
        {
            return alamat;
        }

        public string getKeterangan()
        {
            return keterangan;
        }

        public string getNama()
        {
            return nama;
        }

        public string getTgl_take()
        {
            return tgl_take;
        }
    }
}
