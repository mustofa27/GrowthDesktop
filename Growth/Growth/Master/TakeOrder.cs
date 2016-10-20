﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class TakeOrder
    {
        private int Id, kd_visit, Kd_produk, qty, status;
        private string Date_order, Satuan, Kd_to;
        public string nm_sales { set; get; }
        public string nm_outlet { set; get; }
        public string nm_produk { set; get; }
        public string kota { set; get; }
        public string area { set; get; }
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

        public int kd_visitplan
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

        public int kd_produk
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

        public int qty_order
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

        public int status_order
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

        public string date_order
        {
            get
            {
                return Date_order;
            }

            set
            {
                Date_order = value;
            }
        }

        public string satuan
        {
            get
            {
                return Satuan;
            }

            set
            {
                Satuan = value;
            }
        }

        public string kd_to
        {
            get
            {
                return Kd_to;
            }

            set
            {
                Kd_to = value;
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
