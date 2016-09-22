using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Pages.Pageclasses
{
    class ResponFoto
    {
        public string status { set; get; }
        public string foto { set; get; }
        public ResponFoto(string foto, string status)
        {
            this.status = status;
            this.foto = foto;
        }
    }
}
