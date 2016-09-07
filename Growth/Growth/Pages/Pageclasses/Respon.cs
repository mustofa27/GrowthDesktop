using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Pages.Pageclasses
{
    class Respon
    {
        public string status { set; get; }
        public int id { set; get; }
        public Respon(int id, string status)
        {
            this.status = status;
            this.id = id;
        }
    }
}
