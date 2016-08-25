﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class TakeOrder
    {
        private int id, kd_visit, kd_produk, qty, status;
        private string date_order, satuan;
        public TakeOrder(int id, int kd_visit, int kd_produk, int qty, int status, string date_order, string satuan)
        {
            setId(id);
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
    }
}