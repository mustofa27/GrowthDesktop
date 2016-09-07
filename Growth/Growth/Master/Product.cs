using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Product
    {
        private int Id;
        private string Kd_produk, Nm_produk;

        public int id
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string kd_produk
        {
            get
            {
                return Kd_produk;
            }

            set
            {
                Kd_produk = value;
            }
        }

        public string nm_produk
        {
            get
            {
                return Nm_produk;
            }

            set
            {
                Nm_produk = value;
            }
        }

        public Product(int id, string kd_produk, string nm_produk)
        {
            setId(id);
            setKd_produk(kd_produk);
            setNm_produk(nm_produk);
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setKd_produk(string kd_produk)
        {
            this.kd_produk = kd_produk;
        }

        public void setNm_produk(string nm_produk)
        {
            this.nm_produk = nm_produk;
        }

        public int getId()
        {
            return id;
        }

        public string getKd_produk()
        {
            return kd_produk;
        }

        public string getNm_produk()
        {
            return nm_produk;
        }
    }
}
