using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class TakeOrder
    {
        private int id, kd_visit, kd_produk, qty, status;
        private string date_order, satuan, kd_to;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Kd_visit
        {
            get
            {
                return kd_visit;
            }

            set
            {
                kd_visit = value;
            }
        }

        public int Kd_produk
        {
            get
            {
                return kd_produk;
            }

            set
            {
                kd_produk = value;
            }
        }

        public int Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Date_order
        {
            get
            {
                return date_order;
            }

            set
            {
                date_order = value;
            }
        }

        public string Satuan
        {
            get
            {
                return satuan;
            }

            set
            {
                satuan = value;
            }
        }

        public string Kd_to
        {
            get
            {
                return kd_to;
            }

            set
            {
                kd_to = value;
            }
        }

        public TakeOrder(int id, string kd_to, int kd_visit, int kd_produk, int qty, string satuan, string date_order, int status)
        {
            setId(id);
            setKd_to(kd_to);
            setKd_visit(kd_visit);
            setKd_produk(kd_produk);
            setQty(qty);
            setStatus(status);
            setDate_order(date_order);
            setSatuan(satuan);
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setKd_visit(int kd_visit)
        {
            this.kd_visit = kd_visit;
        }

        public void setKd_produk(int kd_produk)
        {
            this.kd_produk = kd_produk;
        }

        public void setStatus(int status)
        {
            this.status = status;
        }

        public void setQty(int qty)
        {
            this.qty = qty;
        }

        public void setDate_order(string date_order)
        {
            this.date_order = date_order;
        }

        public void setKd_to(string kd_to)
        {
            this.kd_to = kd_to;
        }

        public void setSatuan(string satuan)
        {
            this.satuan = satuan;
        }

        public int getId()
        {
            return id;
        }

        public int getKd_visit()
        {
            return kd_visit;
        }

        public int getKd_produk()
        {
            return kd_produk;
        }

        public int getQty()
        {
            return qty;
        }

        public int getStatus()
        {
            return status;
        }

        public string getDate_order()
        {
            return date_order;
        }

        public string getSatuan()
        {
            return satuan;
        }

        public string getKd_to()
        {
            return kd_to;
        }
    }
}
