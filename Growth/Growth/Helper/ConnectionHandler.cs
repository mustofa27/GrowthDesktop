using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Growth.Interfaces;

namespace Growth.Helper
{
    class ConnectionHandler
    {
        private Callback callback;
        private string URL = "http://demo.growth.co.id/";
        public ConnectionHandler(Callback callback)
        {
            this.callback = callback;
        }
        public void getAllData()
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/getAll", callback);
        }
    }
}
