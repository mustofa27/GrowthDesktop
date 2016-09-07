using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Pages.Pageclasses
{
    class TopSales
    {
        public int Urut { set; get; }
        public string Name { set; get; }
        public string Area { set; get; }
        public int TotalVisit { set; get; }
        public int EffectiveCall { set; get; }
        public TopSales(string nama, string area, int total, int effect)
        {
            Name = nama;
            Area = area;
            TotalVisit = total;
            EffectiveCall = effect;
        }
    }
}
