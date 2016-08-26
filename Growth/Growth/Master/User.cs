﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class User
    {
        private int kode;
        private int kd_kota;
        private int kd_area;
        private int kodeRole;
        private int status;
        private string NIK;
        private string nama;
        private string alamat;
        private string telepon;
        private string path_foto;
        private string username;
        private string password;
        private string email;
        private string gcmId;
        private int toleransi;
        public User(int kode, int kodeRole, int kd_kota, int kd_area,string NIK, string nama, string alamat, string telepon, string path_foto,
                    string username, string password, string email, int status, string gcmId, int toleransi)
        {
            setKode(kode);
            setKodeRole(kodeRole);
            setNIK(NIK);
            setNama(nama);
            setAlamat(alamat);
            setKd_kota(kd_kota);
            setKd_area(kd_area);
            setTelepon(telepon);
            setPath_foto(path_foto);
            setUsername(username);
            setPassword(password);
            setEmail(email);
            setStatus(status);
            setGcmId(gcmId);
            setToleransi(toleransi);
        }
        public User(string username, string password)
        {
            setUsername(username);
            setPassword(password);
        }
        public string getGcmId()
        {
            return gcmId;
        }

        public void setGcmId(string gcmId)
        {
            this.gcmId = gcmId;
        }
        public int getKd_area()
        {
            return kd_area;
        }

        public void setKd_area(int kd_area)
        {
            this.kd_area = kd_area;
        }
        public int getKode()
        {
            return kode;
        }

        public void setKode(int kode)
        {
            this.kode = kode;
        }

        public int getKodeRole()
        {
            return kodeRole;
        }

        public void setKodeRole(int kodeRole)
        {
            this.kodeRole = kodeRole;
        }

        public string getNIK()
        {
            return NIK;
        }

        public void setNIK(string NIK)
        {
            this.NIK = NIK;
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

        public int getKd_kota()
        {
            return kd_kota;
        }

        public void setKd_kota(int kd_kota)
        {
            this.kd_kota = kd_kota;
        }

        public string getTelepon()
        {
            return telepon;
        }

        public void setTelepon(string telepon)
        {
            this.telepon = telepon;
        }

        public string getPath_foto()
        {
            return path_foto;
        }

        public void setPath_foto(string path_foto)
        {
            this.path_foto = path_foto;
        }

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setStatus(int status)
        {
            this.status = status;
        }

        public int getStatus()
        {
            return status;
        }
        public int getToleransi()
        {
            return toleransi;
        }

        public void setToleransi(int toleransi)
        {
            this.toleransi = toleransi;
        }
    }
}
