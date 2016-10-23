using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Growth.Interfaces;
using Growth.Pages.VisitPlan;

namespace Growth.Helper
{
    class ConnectionHandler
    {
        private Callback callback;
        private string URL = "http://demo.growth.co.id/";
        private TakeOrderList takeOrderList;

        public ConnectionHandler(Callback callback)
        {
            this.callback = callback;
        }

        public void getAllData()
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/getAll", callback);
        }
        public void getTop()
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/getTop", callback);
        }
        #region visitplan
        public void setVisit(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/setVisit", callback, json);
        }
        public void delVisit(int id)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/delVisit/" + id, callback);
        }
        public void editVisit(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/editVisit", callback, json);
        }
        #endregion
        public void setArea(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/setArea", callback, json);
        }
        #region distributor
        public void setDistributor(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/setDistributor", callback, json);
        }
        public void delDistributor(int id)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/delDistributor/" + id, callback);
        }
        public void editDistributor(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/editDistributor", callback, json);
        }
        #endregion
        #region Produk
        public void setProduk(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/setProduk", callback, json);
        }
        public void delProduk(int id)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/delProduk/" + id, callback);
        }
        public void editProduk(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/editProduk", callback, json);
        }
        #endregion
        #region outlet
        public void setOutlet(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/setOutlet", callback, json);
        }
        public void delOutlet(int id)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/delOutlet/" + id, callback);
        }
        public void editOutlet(string json)
        {
            ConnectionHelper.PostToPage(URL + "desktop/editOutlet", callback, json);
        }
        #endregion
        #region takeorder
        public void delTakeOrder(int id)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/delTakeOrder/" + id, callback);
        }
        #endregion
        public void getFoto(int id)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/getFoto/" + id, callback);
        }
        public void authUser(string username,string password)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/login/" + username + "/" + password, callback);
        }
        public void changePassword(string email, string nik, string telp)
        {
            ConnectionHelper.DownloadPageAsync(URL + "desktop/resetPass/" + email + "/" + nik + "/" + telp, callback);
        }
    }
}
