using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Tipe
    {
        private int id;
        private string nm_tipe;
        public Tipe(int id, string nm_tipe)
        {
            setId(id);
            setNm_tipe(nm_tipe);
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return id;
        }

        public void setNm_tipe(string nm_tipe)
        {
            this.nm_tipe = nm_tipe;
        }

        public string getNm_tipe()
        {
            return nm_tipe;
        }

    }
}
