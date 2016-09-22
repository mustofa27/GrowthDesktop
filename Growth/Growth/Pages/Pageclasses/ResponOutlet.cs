using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Pages.Pageclasses
{
    class ResponOutlet
    {
        public string status { set; get; }
        public int id { set; get; }
        public int toleransi { set; get; }
        public string foto { set; get; }
        public ResponOutlet(int id, string status, int toleransi, string foto)
        {
            this.toleransi = toleransi;
            this.status = status;
            this.id = id;
            this.foto = foto;
        }
    }
}
