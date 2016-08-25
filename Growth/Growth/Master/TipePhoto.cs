using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class TipePhoto
    {
        private int id;
        private string nama_tipe;

        public TipePhoto(int id, string nama_tipe)
        {
            this.id = id;
            this.nama_tipe = nama_tipe;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getNama_tipe()
        {
            return nama_tipe;
        }

        public void setNama_tipe(string nama_tipe)
        {
            this.nama_tipe = nama_tipe;
        }
    }
}
