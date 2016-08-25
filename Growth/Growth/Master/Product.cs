using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Product
    {
        private int id;
        private string kd_produk, nm_produk;
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
