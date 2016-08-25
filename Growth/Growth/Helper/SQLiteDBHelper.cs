using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Growth.Master;

namespace Growth.Helper
{
    class SQLiteDBHelper
    {
        static SQLiteConnection sqlite_conn;
        #region property db
            static string DB_NAME = "growth.sqlite",
                TABLE_AREA = "area",
                KEY_ID_AREA = "id",
                KEY_KODE_AREA = "kd_area",
                KEY_NAMA_AREA = "nm_area",
                KEY_TOLERANSI = "toleransi",
                TABLE_CITY = "kota",
                KEY_KODE_KOTA = "kd_kota",
                KEY_NAMA_KOTA = "nama_kota",
                TABLE_LOGGING = "logging",
                KEY_KODE_LOGGING = "kd_logging",
                KEY_DESCRIPTION = "description",
                KEY_LOG_TIME = "log_time",
                TABLE_OUTLET = "outlet",
                KEY_KODE_OUTLET = "kd_outlet",
                KEY_NAMA_OUTLET = "nm_outlet",
                KEY_ALAMAT_OUTLET = "almt_outlet",
                KEY_TIPE_OUTLET = "tipe_outlet",
                KEY_RANK_OUTLET = "rank_outlet",
                KEY_TELP_OUTLET = "telp_outlet",
                KEY_LONGITUDE = "longitude",
                KEY_LATITUDE = "nm_pic",
                KEY_NMPIC = "tlp_pic",
                KEY_TLPPIC = "latitude",
                KEY_REGISTER_STATUS = "reg_status",
                KEY_STATUS_AREA = "status_area",
                TABLE_PHOTO = "photo",
                KEY_KODE_PHOTO = "kd_photo",
                KEY_KODE_KOMPETITOR = "kd_kompetitor",
                KEY_NAMA_PHOTO = "nm_photo",
                KEY_JENIS_PHOTO = "jenis_photo",
                KEY_DATE_TAKE_PHOTO = "date_take_photo",
                KEY_ALAMAT_PHOTO = "alamat_comp_activity",
                KEY_DATE_UPLOAD_PHOTO = "date_upload_photo",
                KEY_KETERANGAN = "keterangan",
                TABLE_USER = "user",
                KEY_KODE_USER = "kd_user",
                KEY_KODE_ROLE = "kd_role",
                KEY_NIK = "NIK",
                KEY_NAMA_USER = "nama",
                KEY_ALAMAT_USER = "alamat",
                KEY_TELEPON = "telepon",
                KEY_FOTO = "foto",
                KEY_USERNAME = "username",
                KEY_PASSWORD = "password",
                KEY_EMAIL = "email",
                KEY_STATUS = "status",
                KEY_GCMID = "id_gcm",
                TABLE_VISITPLAN = "VisitPlan",
                KEY_KODE_VISITPLAN = "kd_visitplan",
                KEY_DATE_VISIT = "date_visit",
                KEY_DATE_CREATE_VISIT = "date_create_visit",
                KEY_APPROVE_VISIT = "approve_visit",
                KEY_STATUS_VISIT = "status_visit",
                KEY_DATE_VISITING = "date_visiting",
                KEY_SKIP_ORDER_REASON = "skip_order_reason",
                KEY_SKIP_REASON = "skip_reason",
                TABLE_DISTRIBUTOR = "Distributor",
                KEY_ID_DISTRIBUTOR = "id",
                KEY_KODE_DISTRIBUTOR = "kd_dist",
                KEY_NAMA_DISTRIBUTOR = "nm_dist",
                KEY_ALAMAT_DISTRIBUTOR = "almt_dist",
                KEY_TELEPON_DISTRIBUTOR = "telp_dist",
                TABLE_TIPE = "Tipe",
                KEY_KODE_TIPE = "kd_tipe",
                KEY_NAMA_TIPE = "nm_tipe",
                TABLE_TIPE_PHOTO = "TipePhoto",
                KEY_ID_TIPE = "id",
                KEY_NM_TIPE = "nama_tipe",
                TABLE_COMPETITOR = "Competitor",
                KEY_KODE_COMPETITOR = "kd_competitor",
                KEY_NAMA_COMPETITOR = "nm_competitor",
                KEY_ALAMAT_COMPETITOR = "alamat_competitor",
                TABLE_PRODUK = "Produk",
                KEY_ID_PRODUK = "id_produk",
                KEY_KODE_PRODUK = "kd_produk",
                KEY_NAMA_PRODUK = "nm_produk",
                TABLE_KONFIGURASI = "Konfigurasi",
                KEY_STATUS_APP = "status_app";
        #endregion
        static void CreateOrReadDB()
        {
            if (File.Exists(DB_NAME))
            {
                sqlite_conn = new SQLiteConnection("Data Source=growth.sqlite;Version=3;");
                sqlite_conn.Open();
            }
            else
            {
                SQLiteConnection.CreateFile("growth.sqlite");
                sqlite_conn = new SQLiteConnection("Data Source=growth.sqlite;Version=3;");
                sqlite_conn.Open();
                List<string> sqlList = new List<string>();
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_OUTLET +
                            "(" + KEY_KODE_OUTLET + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_DISTRIBUTOR + " INTEGER NOT NULL,"
                            + KEY_KODE_KOTA + " INTEGER NOT NULL,"
                            + KEY_KODE_USER + " INTEGER NOT NULL,"
                            + KEY_NAMA_OUTLET + " TEXT NOT NULL,"
                            + KEY_ALAMAT_OUTLET + " TEXT NOT NULL,"
                            + KEY_TIPE_OUTLET + " TEXT NOT NULL,"
                            + KEY_RANK_OUTLET + " TEXT NOT NULL,"
                            + KEY_TELP_OUTLET + " TEXT NOT NULL,"
                            + KEY_REGISTER_STATUS + " TEXT NOT NULL,"
                            + KEY_LATITUDE + " TEXT NOT NULL,"
                            + KEY_LONGITUDE + " TEXT NOT NULL,"
                            + KEY_NMPIC + " TEXT NOT NULL,"
                            + KEY_TLPPIC + " TEXT NOT NULL,"
                            + KEY_STATUS_AREA + " INTEGER NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_USER +
                            "(" + KEY_KODE_USER + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_ROLE + " INTEGER NOT NULL,"
                            + KEY_KODE_KOTA + " INTEGER NOT NULL,"
                            + KEY_KODE_AREA + " INTEGER NOT NULL,"
                            + KEY_NIK + " TEXT NOT NULL,"
                            + KEY_NAMA_USER + " TEXT NOT NULL,"
                            + KEY_ALAMAT_USER + " TEXT NOT NULL,"
                            + KEY_TELEPON + " TEXT NOT NULL,"
                            + KEY_FOTO + " TEXT,"
                            + KEY_USERNAME + " TEXT NOT NULL,"
                            + KEY_PASSWORD + " TEXT NOT NULL,"
                            + KEY_EMAIL + " TEXT NOT NULL,"
                            + KEY_STATUS + " INTEGER NOT NULL,"
                            + KEY_TOLERANSI + " INTEGER,"
                            + KEY_GCMID + " TEXT)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_PHOTO +
                            "(" + KEY_KODE_PHOTO + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_USER + " INTEGER NOT NULL,"
                            + KEY_KODE_OUTLET + " INTEGER NOT NULL,"
                            + KEY_KODE_KOMPETITOR + " INTEGER,"
                            + KEY_JENIS_PHOTO + " INTEGER,"
                            + KEY_NAMA_PHOTO + " TEXT NOT NULL,"
                            + KEY_DATE_TAKE_PHOTO + " TEXT NOT NULL,"
                            + KEY_ALAMAT_PHOTO + " TEXT,"
                            + KEY_DATE_UPLOAD_PHOTO + " TEXT,"
                            + KEY_FOTO + " TEXT NOT NULL,"
                            + KEY_KETERANGAN + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_CITY +
                            "(" + KEY_KODE_KOTA + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_AREA + " INTEGER NOT NULL,"
                            + KEY_NAMA_KOTA + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_AREA +
                            "(" + KEY_ID_AREA + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_AREA + " TEXT NOT NULL,"
                            + KEY_NAMA_AREA + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_LOGGING +
                            "(" + KEY_KODE_LOGGING + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_DESCRIPTION + " INTEGER NOT NULL,"
                            + KEY_LOG_TIME + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_DISTRIBUTOR +
                            "(" + KEY_ID_DISTRIBUTOR + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_DISTRIBUTOR + " TEXT NOT NULL,"
                            + KEY_KODE_TIPE + " TEXT NOT NULL,"
                            + KEY_KODE_KOTA + " INTEGER NOT NULL,"
                            + KEY_NAMA_DISTRIBUTOR + " TEXT NOT NULL,"
                            + KEY_ALAMAT_DISTRIBUTOR + " TEXT NOT NULL,"
                            + KEY_TELEPON_DISTRIBUTOR + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_COMPETITOR +
                            "(" + KEY_KODE_COMPETITOR + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_KOTA + " INTEGER NOT NULL,"
                            + KEY_NAMA_COMPETITOR + " TEXT NOT NULL,"
                            + KEY_ALAMAT_COMPETITOR + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_TIPE +
                            "(" + KEY_KODE_TIPE + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_NAMA_TIPE + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_TIPE_PHOTO +
                            "(" + KEY_ID_TIPE + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_NM_TIPE + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_PRODUK +
                            "(" + KEY_ID_PRODUK + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_PRODUK + " TEXT NOT NULL,"
                            + KEY_NAMA_PRODUK + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_VISITPLAN +
                            "(" + KEY_KODE_VISITPLAN + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_OUTLET + " INTEGER NOT NULL,"
                            + KEY_DATE_VISIT + " TEXT NOT NULL,"
                            + KEY_DATE_CREATE_VISIT + " TEXT NOT NULL,"
                            + KEY_APPROVE_VISIT + " INTEGER NOT NULL,"
                            + KEY_STATUS_VISIT + " INTEGER NOT NULL,"
                            + KEY_DATE_VISITING + " TEXT NOT NULL,"
                            + KEY_SKIP_ORDER_REASON + " TEXT NOT NULL,"
                            + KEY_SKIP_REASON + " REAL NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_KONFIGURASI +
                            "(" + KEY_STATUS_APP + " INTEGER DEFAULT 0)");
                foreach (var sql in sqlList)
                {
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
                    command.ExecuteNonQuery();
                }
            }
        }
        #region DB CRUD     
        #region Area
        public static void InsertArea(Area area)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_AREA + "(" + KEY_ID_AREA + ", " + KEY_KODE_AREA + ", " + KEY_NAMA_AREA + ") values (" + area.getid() + ", '" + area.getKode() + "', '" + area.getNama() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteArea(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_AREA + " WHERE "+ KEY_ID_AREA + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static Area ReadArea(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_AREA + " WHERE " + KEY_ID_AREA + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Area area = new Area(int.Parse(reader[KEY_ID_AREA].ToString()),reader[KEY_KODE_AREA].ToString(),reader[KEY_NAMA_AREA].ToString());
                reader.Close();
                return area;
            }
            reader.Close();
            return null;
        }
        public static List<Area> ReadAllArea()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_AREA;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Area> areaList = new List<Area>();
            while (reader.Read())
            {
                areaList.Add(new Area(int.Parse(reader[KEY_ID_AREA].ToString()), reader[KEY_KODE_AREA].ToString(), reader[KEY_NAMA_AREA].ToString()));
            }
            reader.Close();
            return areaList;
        }
        public static void UpdateArea(Area area)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_AREA + " set " + KEY_KODE_AREA + " = '" + area.getKode() + "', " + KEY_NAMA_AREA + " = '" + area.getNama() + "' where " + KEY_ID_AREA + " = "+area.getid();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region City
        public static void InsertCity(City city)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_CITY + "(" + KEY_KODE_KOTA + ", " + KEY_KODE_AREA + ", " + KEY_NAMA_KOTA 
                + ") values (" + city.getKode() + ", " + city.getKodeArea() + ", '" + city.getNama() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteCity(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_CITY + " WHERE " + KEY_KODE_KOTA + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static City ReadCity(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_CITY + " WHERE " + KEY_KODE_KOTA + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                City city = new City(int.Parse(reader[KEY_KODE_KOTA].ToString()), int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NAMA_KOTA].ToString());
                reader.Close();
                return city;
            }
            reader.Close();
            return null;
        }
        public static List<City> ReadAllCity()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_CITY;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            List<City> cityList = new List<City>();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cityList.Add(new City(int.Parse(reader[KEY_KODE_KOTA].ToString()), int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NAMA_KOTA].ToString()));
            }
            reader.Close();
            return cityList;
        }
        public static void UpdateCity(City city)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_CITY + " set " + KEY_KODE_AREA + " = " + city.getKodeArea() 
                + ", " + KEY_NAMA_KOTA + " = '" + city.getNama() + "' where " + KEY_KODE_KOTA + " = " + city.getKode();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Competitor
        public static void InsertCompetitor(Competitor competitor)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_COMPETITOR + " (" + KEY_KODE_COMPETITOR + ", " + KEY_KODE_KOTA + 
                ", " + KEY_NAMA_COMPETITOR +", " + KEY_ALAMAT_COMPETITOR + ") values (" 
                + competitor.getId() + ", " + competitor.getKd_kota() + ", '" + competitor.getNm_competitor() + "', '" 
                + competitor.getAlamat() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteCompetitor(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_COMPETITOR + " WHERE " + KEY_KODE_COMPETITOR + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static Competitor ReadCompetitor(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_COMPETITOR + " WHERE " + KEY_KODE_COMPETITOR + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Competitor competitor = new Competitor(int.Parse(reader[KEY_KODE_COMPETITOR].ToString()),
                    int.Parse(reader[KEY_KODE_KOTA].ToString()), reader[KEY_NAMA_COMPETITOR].ToString(),
                    reader[KEY_ALAMAT_COMPETITOR].ToString());
                reader.Close();
                return competitor;
            }
            reader.Close();
            return null;
        }
        public static List<Competitor> ReadAllCompetitor()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_COMPETITOR;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Competitor> competitorList = new List<Competitor>();
            while (reader.Read())
            {
                competitorList.Add(new Competitor(int.Parse(reader[KEY_KODE_COMPETITOR].ToString()),
                    int.Parse(reader[KEY_KODE_KOTA].ToString()), reader[KEY_NAMA_COMPETITOR].ToString(),
                    reader[KEY_ALAMAT_COMPETITOR].ToString()));
            }
            reader.Close();
            return competitorList;
        }
        public static void UpdateCompetitor(Competitor competitor)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_COMPETITOR + " set " + KEY_KODE_KOTA + " = " + competitor.getKd_kota() 
                + ", " + KEY_NAMA_COMPETITOR + " = '" + competitor.getNm_competitor() + "', " + KEY_ALAMAT_COMPETITOR 
                + " = '" + competitor.getAlamat() + "' where " + KEY_KODE_COMPETITOR + " = " + competitor.getId();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Distributor
        public static void InsertDistributor(Distributor distributor)
        {

        }
        public static void DeleteDistributor(int id)
        {

        }
        public static Distributor ReadDistributor(int id)
        {
            return null;
        }
        public static List<Distributor> ReadAllDistributor()
        {
            return null;
        }
        public static void UpdateDistributor(Distributor distributor)
        {

        }
        #endregion
        #region Logging
        public static void InsertLogging(Logging logging)
        {

        }
        public static void DeleteLogging(int id)
        {

        }
        public static Logging ReadLogging(int id)
        {
            return null;
        }
        public static List<Logging> ReadAllLogging()
        {
            return null;
        }
        public static void UpdateLogging(Logging logging)
        {

        }
        #endregion
        #region Outlet
        public static void InsertOutlet(Outlet outlet)
        {

        }
        public static void DeleteOutlet(int id)
        {

        }
        public static Outlet ReadOutlet(int id)
        {
            return null;
        }
        public static List<Outlet> ReadAllOutlet()
        {
            return null;
        }
        public static void UpdateOutlet(Outlet outlet)
        {

        }
        #endregion
        #region PhotoActivity
        public static void InsertPhotoActivity(PhotoActivity photoActivity)
        {

        }
        public static void DeletePhotoActivity(int id)
        {

        }
        public static PhotoActivity ReadPhotoActivity(int id)
        {
            return null;
        }
        public static List<PhotoActivity> ReadAllPhotoActivity()
        {
            return null;
        }
        public static void UpdatePhotoActivity(PhotoActivity photoActivity)
        {

        }
        #endregion
        #region Product
        public static void InsertProduct(Product product)
        {

        }
        public static void DeleteProduct(int id)
        {

        }
        public static Product ReadProduct(int id)
        {
            return null;
        }
        public static List<Product> ReadProduct()
        {
            return null;
        }
        public static void UpdateProduct(Product product)
        {

        }
        #endregion
        #region TakeOrder
        public static void InsertTakeOrder(TakeOrder takeOrder)
        {

        }
        public static void DeleteTakeOrder(int id)
        {

        }
        public static TakeOrder ReadTakeOrder(int id)
        {
            return null;
        }
        public static List<TakeOrder> ReadTakeOrder()
        {
            return null;
        }
        public static void UpdateTakeOrder(TakeOrder takeOrder)
        {

        }
        #endregion
        #region Tipe
        public static void InsertTipe(Tipe tipe)
        {

        }
        public static void DeleteTipe(int id)
        {

        }
        public static Tipe ReadTipe(int id)
        {
            return null;
        }
        public static List<Tipe> ReadTipe()
        {
            return null;
        }
        public static void UpdateTipe(Tipe tipe)
        {

        }
        #endregion
        #region TipePhoto
        public static void InsertTipePhoto(TipePhoto tipePhoto)
        {

        }
        public static void DeleteTipePhoto(int id)
        {

        }
        public static TipePhoto ReadTipePhoto(int id)
        {
            return null;
        }
        public static List<TipePhoto> ReadTipePhoto()
        {
            return null;
        }
        public static void UpdateTipePhoto(TipePhoto tipePhoto)
        {

        }
        #endregion
        #region User
        public static void InsertUser(User user)
        {

        }
        public static void DeleteUser(int id)
        {

        }
        public static User ReadUser(int id)
        {
            return null;
        }
        public static List<User> ReadAllUser()
        {
            return null;
        }
        public static void UpdateUser(User user)
        {

        }
        #endregion
        #region VisitPlan
        public static void InsertVisitPlan(VisitPlan visitPlan)
        {

        }
        public static void DeleteVisitPlan(int id)
        {

        }
        public static VisitPlan ReadVisitPlan(int id)
        {
            return null;
        }
        public static List<VisitPlan> ReadVisitPlan()
        {
            return null;
        }
        public static void UpdateVisitPlan(VisitPlan visitPlan)
        {

        }
        #endregion
        #endregion
    }
}
