using System.Collections.Generic;
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
                KEY_DETAIL_AKSES = "detail_akses",
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
                KEY_KODE_POS = "kode_pos",
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
                TABLE_TAKE_ORDER = "TakeOrder",
                KEY_KODE_TAKE_ORDER = "kd_take_order",
                KEY_KD_TO = "kd_to",
                KEY_QUANTITY = "qty",
                KEY_SATUAN = "satuan",
                KEY_DATE_ORDER = "date_order",
                KEY_STATUS_ORDER = "status_order",
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
                KEY_TOLERANSI_MAX = "toleransi_max",
                TABLE_LOGGEDIN = "loggedin";
        #endregion
        public static bool checkDB()
        {
            return File.Exists(DB_NAME);
        }
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
                            + KEY_TIPE_OUTLET + " INTEGER NOT NULL,"
                            + KEY_RANK_OUTLET + " TEXT NOT NULL,"
                            + KEY_TELP_OUTLET + " TEXT NOT NULL,"
                            + KEY_KODE_POS + " TEXT NOT NULL,"
                            + KEY_REGISTER_STATUS + " TEXT NOT NULL,"
                            + KEY_LATITUDE + " TEXT NOT NULL,"
                            + KEY_LONGITUDE + " TEXT NOT NULL,"
                            + KEY_TOLERANSI + " INTEGER NOT NULL,"
                            + KEY_FOTO + " TEXT NOT NULL,"
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
                            + KEY_KODE_USER + " INTEGER NOT NULL,"
                            + KEY_DESCRIPTION + " TEXT NOT NULL,"
                            + KEY_LOG_TIME + " TEXT NOT NULL,"
                            + KEY_DETAIL_AKSES + " TEXT NOT NULL)");
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
                            + KEY_SKIP_REASON + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_TAKE_ORDER +
                            "(" + KEY_KODE_TAKE_ORDER + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KD_TO + " TEXT NOT NULL,"
                            + KEY_KODE_VISITPLAN + " INTEGER NOT NULL,"
                            + KEY_KODE_PRODUK + " INTEGER NOT NULL,"
                            + KEY_QUANTITY + " INTEGER NOT NULL,"
                            + KEY_SATUAN + " TEXT NOT NULL,"
                            + KEY_DATE_ORDER + " TEXT NOT NULL,"
                            + KEY_STATUS_ORDER + " INTEGER NOT NULL)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_KONFIGURASI +
                            "(" + KEY_TOLERANSI_MAX + " INTEGER DEFAULT 0)");
                sqlList.Add("CREATE TABLE IF NOT EXISTS " + TABLE_LOGGEDIN +
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
                City city = new City(int.Parse(reader[KEY_KODE_KOTA].ToString()), int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NAMA_KOTA].ToString());
                if (city.kd_area != 0)
                {
                    Area area = ReadArea(city.kd_area);
                    city.kode_area = area.kd_area;
                    city.nm_area = area.getNama();
                }
                else
                {
                    city.kode_area = "Area belum tersedia";
                    city.nm_area = "Unregistered";
                }
                cityList.Add(city);
            }
            reader.Close();
            return cityList;
        }
        public static List<City> ReadAllCity(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_CITY + " where " + KEY_KODE_AREA + "= " + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            List<City> cityList = new List<City>();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                City city = new City(int.Parse(reader[KEY_KODE_KOTA].ToString()), int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NAMA_KOTA].ToString());
                if (city.kd_area != 0)
                {
                    Area area = ReadArea(city.kd_area);
                    city.kode_area = area.kd_area;
                    city.nm_area = area.getNama();
                }
                else
                {
                    city.kode_area = "Area belum tersedia";
                    city.nm_area = "Unregistered";
                }
                cityList.Add(city);
            }
            reader.Close();
            return cityList;
        }
        public static List<City> ReadAllCityRegistered()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_CITY + " where " + KEY_KODE_AREA + "!= 0";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            List<City> cityList = new List<City>();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                City city = new City(int.Parse(reader[KEY_KODE_KOTA].ToString()), int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NAMA_KOTA].ToString());
                if (city.kd_area != 0)
                {
                    Area area = ReadArea(city.kd_area);
                    city.kode_area = area.kd_area;
                    city.nm_area = area.getNama();
                }
                else
                {
                    city.kode_area = "Area belum tersedia";
                    city.nm_area = "Unregistered";
                }
                cityList.Add(city);
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
            CreateOrReadDB();
            string sql = "insert into " + TABLE_DISTRIBUTOR + " (" + KEY_ID_DISTRIBUTOR + ", " + KEY_KODE_DISTRIBUTOR +
                ", " + KEY_KODE_TIPE + ", " + KEY_KODE_KOTA + ", " + KEY_NAMA_DISTRIBUTOR + ", " + KEY_ALAMAT_DISTRIBUTOR +
                ", " + KEY_TELEPON_DISTRIBUTOR + ") values ("
                + distributor.getId() + ", '" + distributor.getKd_dist() + "', '" + distributor.getKd_tipe() 
                + "', " + distributor.getKd_kota() + ", '" + distributor.getNm_dist() + "', '"
                + distributor.getAlmt_dist() + "', '" + distributor.getTelp_dist() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteDistributor(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_DISTRIBUTOR + " WHERE " + KEY_ID_DISTRIBUTOR + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static Distributor ReadDistributor(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_DISTRIBUTOR + " WHERE " + KEY_ID_DISTRIBUTOR + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Distributor distributor = new Distributor(int.Parse(reader[KEY_ID_DISTRIBUTOR].ToString()),
                    reader[KEY_KODE_DISTRIBUTOR].ToString(), reader[KEY_KODE_TIPE].ToString()
                    , int.Parse(reader[KEY_KODE_KOTA].ToString()),reader[KEY_NAMA_DISTRIBUTOR].ToString()
                    , reader[KEY_ALAMAT_DISTRIBUTOR].ToString(), reader[KEY_TELEPON_DISTRIBUTOR].ToString());
                reader.Close();
                return distributor;
            }
            reader.Close();
            return null;
        }
        public static List<Distributor> ReadAllDistributor()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_DISTRIBUTOR;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Distributor> distributors = new List<Distributor>();
            while (reader.Read())
            {
                Distributor dist = new Distributor(int.Parse(reader[KEY_ID_DISTRIBUTOR].ToString()),
                    reader[KEY_KODE_DISTRIBUTOR].ToString(), reader[KEY_KODE_TIPE].ToString()
                    , int.Parse(reader[KEY_KODE_KOTA].ToString()), reader[KEY_NAMA_DISTRIBUTOR].ToString()
                    , reader[KEY_ALAMAT_DISTRIBUTOR].ToString(), reader[KEY_TELEPON_DISTRIBUTOR].ToString());
                dist.kota = ReadCity(dist.Kd_kota).nm_kota;
                distributors.Add(dist);
            }
            reader.Close();
            return distributors;
        }
        public static void UpdateDistributor(Distributor distributor)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_DISTRIBUTOR + " set " + KEY_KODE_DISTRIBUTOR + " = '"+ distributor.getKd_dist() +
                "', " + KEY_KODE_TIPE + " = '" + distributor.getKd_tipe() + "', " + KEY_KODE_KOTA + " = " + distributor.getKd_kota() +
                ", " + KEY_NAMA_DISTRIBUTOR + " = '" + distributor.getNm_dist() + "', " + KEY_ALAMAT_DISTRIBUTOR + " = '"+ distributor.getAlmt_dist() +
                "', " + KEY_TELEPON_DISTRIBUTOR + " = '"+ distributor.getTelp_dist() + "' where " + KEY_ID_DISTRIBUTOR + " = " + distributor.getId();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Logging
        public static void InsertLogging(Logging logging)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_LOGGING + " values (" + logging.getKd_logging() + ", " + logging.getKd_user() +
                ", '" + logging.getDescription() + "', '" + logging.getLog_time() + "', '" + logging.getDetail_akses() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteLogging(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_LOGGING + " WHERE " + KEY_KODE_LOGGING + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static Logging ReadLogging(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_LOGGING + " WHERE " + KEY_KODE_LOGGING + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Logging logging = new Logging(int.Parse(reader[KEY_KODE_LOGGING].ToString()), int.Parse(reader[KEY_KODE_USER].ToString()),
                    reader[KEY_DESCRIPTION].ToString(), reader[KEY_LOG_TIME].ToString(), reader[KEY_DETAIL_AKSES].ToString());
                reader.Close();
                return logging;
            }
            reader.Close();
            return null;
        }
        public static List<Logging> ReadAllLogging()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_LOGGING;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Logging> loggings = new List<Logging>();
            while (reader.Read())
            {
                loggings.Add(new Logging(int.Parse(reader[KEY_KODE_LOGGING].ToString()), int.Parse(reader[KEY_KODE_USER].ToString()),
                    reader[KEY_DESCRIPTION].ToString(), reader[KEY_LOG_TIME].ToString(), reader[KEY_DETAIL_AKSES].ToString()));
            }
            reader.Close();
            return loggings;
        }
        public static void UpdateLogging(Logging logging)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_LOGGING + " set " + KEY_KODE_USER + " = " + logging.getKd_user() + ", " + 
                KEY_DESCRIPTION + " = '" + logging.getDescription()+ "', " + KEY_LOG_TIME + " = '" + logging.getLog_time() + "', " +
                KEY_DETAIL_AKSES + " = '" + logging.getDetail_akses() + "' where " + KEY_KODE_LOGGING + " = " + logging.getKd_logging();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Outlet
        public static void InsertOutlet(Outlet outlet)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_OUTLET + " values ("
                + outlet.getKode() + ", " + outlet.getKode_distributor() + ", " + outlet.getKode_kota()
                + ", " + outlet.getKode_user() + ", '" + outlet.getNama() + "', '"
                + outlet.getAlamat() + "', " + outlet.getTipe() + ", '" + outlet.getRank() + "', '" + outlet.getTelpon() + "', '" + outlet.getKodepos() +
                "', '" + outlet.getReg_status() + "', '" + outlet.getLatitude() + "', '" + outlet.getLongitude() + "', " + outlet.getToleransi() + ", '" + outlet.getFoto()
                + "', '" + outlet.getNamaPIC() + "', '" + outlet.getTelpPIC() + "', " + outlet.getStatus_area() + ")";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteOutlet(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_OUTLET + " WHERE " + KEY_KODE_OUTLET + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static Outlet ReadOutlet(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_OUTLET + " WHERE " + KEY_KODE_OUTLET + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Outlet outlet = new Outlet(int.Parse(reader[KEY_KODE_OUTLET].ToString()),
                    int.Parse(reader[KEY_KODE_DISTRIBUTOR].ToString()), int.Parse(reader[KEY_KODE_KOTA].ToString()),
                     int.Parse(reader[KEY_KODE_USER].ToString()), reader[KEY_NAMA_OUTLET].ToString(),
                     reader[KEY_ALAMAT_OUTLET].ToString(), int.Parse(reader[KEY_TIPE_OUTLET].ToString()),
                     reader[KEY_RANK_OUTLET].ToString(), reader[KEY_TELP_OUTLET].ToString(),
                     reader[KEY_REGISTER_STATUS].ToString(), reader[KEY_KODE_POS].ToString(), reader[KEY_LATITUDE].ToString(),
                     reader[KEY_LONGITUDE].ToString(), int.Parse(reader[KEY_TOLERANSI].ToString()), reader[KEY_FOTO].ToString(),
                     reader[KEY_NMPIC].ToString(), reader[KEY_TLPPIC].ToString(), int.Parse(reader[KEY_STATUS_AREA].ToString()));
                reader.Close();
                return outlet;
            }
            reader.Close();
            return null;
        }
        public static List<Outlet> ReadAllOutlet()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_OUTLET;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Outlet> outlets = new List<Outlet>();
            while (reader.Read())
            {
                Outlet outlet = new Outlet(int.Parse(reader[KEY_KODE_OUTLET].ToString()),
                    int.Parse(reader[KEY_KODE_DISTRIBUTOR].ToString()), int.Parse(reader[KEY_KODE_KOTA].ToString()),
                     int.Parse(reader[KEY_KODE_USER].ToString()), reader[KEY_NAMA_OUTLET].ToString(),
                     reader[KEY_ALAMAT_OUTLET].ToString(), int.Parse(reader[KEY_TIPE_OUTLET].ToString()),
                     reader[KEY_RANK_OUTLET].ToString(), reader[KEY_TELP_OUTLET].ToString(),
                     reader[KEY_REGISTER_STATUS].ToString(), reader[KEY_KODE_POS].ToString(), reader[KEY_LATITUDE].ToString(),
                     reader[KEY_LONGITUDE].ToString(), int.Parse(reader[KEY_TOLERANSI].ToString()), reader[KEY_FOTO].ToString(),
                     reader[KEY_NMPIC].ToString(), reader[KEY_TLPPIC].ToString(), int.Parse(reader[KEY_STATUS_AREA].ToString()));
                User user = ReadUser(outlet.getKode_user());
                City kota = ReadCity(user.kd_kota);
                outlet.area = ReadArea(kota.getKodeArea()).getNama();
                outlet.kota = kota.getNama();
                outlet.nm_tipe = ReadTipe(outlet.kd_tipe).nm_tipe;
                outlets.Add(outlet);
            }
            reader.Close();
            return outlets;
        }
        public static void UpdateOutlet(Outlet outlet)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_OUTLET + " set " + KEY_KODE_DISTRIBUTOR + " = " + outlet.getKode_distributor() +
                ", " + KEY_KODE_KOTA + " = " + outlet.getKode_kota() + ", " + KEY_KODE_USER + " = " + outlet.getKode_user() +
                ", " + KEY_NAMA_OUTLET + " = '" + outlet.getNama() + "', " + KEY_ALAMAT_OUTLET + " = '" + outlet.getAlamat() +
                "', " + KEY_TIPE_OUTLET + " = " + outlet.getTipe() + ", " + KEY_RANK_OUTLET + " = '" + outlet.getRank() +
                "', " + KEY_TELP_OUTLET + " = '" + outlet.getTelpon() + "', " + KEY_REGISTER_STATUS + " = '" + outlet.getReg_status() +
                "', " + KEY_KODE_POS + " = '" + outlet.getKodepos() + "', " + KEY_LATITUDE + " = '" + outlet.getLatitude() + 
                "', " + KEY_LONGITUDE + " = '" + outlet.getLongitude() + "', " + KEY_TOLERANSI + " = " + outlet.getToleransi() +
                ", " + KEY_FOTO + " = '" + outlet.getFoto() + "', " + KEY_NMPIC + " = '" + outlet.getNamaPIC() + "', " + KEY_TLPPIC + " = '" + outlet.getTelpPIC() +
                "', " + KEY_STATUS_AREA + " = " + outlet.getStatus_area() + " where " + KEY_KODE_OUTLET + " = " + outlet.getKode();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region PhotoActivity
        public static void InsertPhotoActivity(PhotoActivity photoActivity)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_PHOTO + " values ("
                + photoActivity.getId() + ", " + photoActivity.getKd_user() + ", " + photoActivity.getKd_outlet()
                + ", " + photoActivity.getKd_kompetitor() + ", " + photoActivity.getKd_tipe() + ", '"
                + photoActivity.getNama() + "', '" + photoActivity.getTgl_take() + "', '" + photoActivity.getAlamat() 
                + "', '" + photoActivity.getTgl_upload() + "', '" + photoActivity.getFoto() 
                + "', '" + photoActivity.getKeterangan() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeletePhotoActivity(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_PHOTO + " WHERE " + KEY_KODE_PHOTO + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static PhotoActivity ReadPhotoActivity(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_PHOTO + " WHERE " + KEY_KODE_PHOTO + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                PhotoActivity photoActivity = new PhotoActivity(int.Parse(reader[KEY_KODE_PHOTO].ToString()),
                    int.Parse(reader[KEY_KODE_USER].ToString()), int.Parse(reader[KEY_KODE_OUTLET].ToString()),
                     int.Parse(reader[KEY_KODE_KOMPETITOR].ToString()), int.Parse(reader[KEY_JENIS_PHOTO].ToString()),
                     reader[KEY_NAMA_PHOTO].ToString(), reader[KEY_DATE_TAKE_PHOTO].ToString(),
                     reader[KEY_ALAMAT_PHOTO].ToString(), reader[KEY_DATE_UPLOAD_PHOTO].ToString(),
                     reader[KEY_FOTO].ToString(), reader[KEY_KETERANGAN].ToString());
                reader.Close();
                return photoActivity;
            }
            reader.Close();
            return null;
        }
        public static List<PhotoActivity> ReadAllPhotoActivity()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_PHOTO;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<PhotoActivity> photoActivities = new List<PhotoActivity>();
            while (reader.Read())
            {
                 photoActivities.Add(new PhotoActivity(int.Parse(reader[KEY_KODE_PHOTO].ToString()),
                    int.Parse(reader[KEY_KODE_USER].ToString()), int.Parse(reader[KEY_KODE_OUTLET].ToString()),
                     int.Parse(reader[KEY_KODE_KOMPETITOR].ToString()), int.Parse(reader[KEY_JENIS_PHOTO].ToString()),
                     reader[KEY_NAMA_PHOTO].ToString(), reader[KEY_DATE_TAKE_PHOTO].ToString(),
                     reader[KEY_ALAMAT_PHOTO].ToString(), reader[KEY_DATE_UPLOAD_PHOTO].ToString(),
                     reader[KEY_FOTO].ToString(), reader[KEY_KETERANGAN].ToString()));
            }
            reader.Close();
            return photoActivities;
        }
        public static void UpdatePhotoActivity(PhotoActivity photoActivity)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_PHOTO + " set " + KEY_KODE_USER + " = " + photoActivity.getKd_user() +
                ", " + KEY_KODE_OUTLET + " = " + photoActivity.getKd_outlet() + ", " + KEY_KODE_KOMPETITOR + " = " + photoActivity.getKd_kompetitor() +
                ", " + KEY_JENIS_PHOTO + " = " + photoActivity.getKd_tipe() + ", " + KEY_NAMA_PHOTO + " = '" + photoActivity.getNama() +
                "', " + KEY_DATE_TAKE_PHOTO + " = '" + photoActivity.getTgl_take() + "', " + KEY_ALAMAT_PHOTO + " = '" + photoActivity.getAlamat() +
                "', " + KEY_DATE_UPLOAD_PHOTO + " = '" + photoActivity.getTgl_upload() + "', " + KEY_FOTO + " = '" + photoActivity.getFoto() +
                "', " + KEY_KETERANGAN + " = '" + photoActivity.getKeterangan() + "' where " + KEY_KODE_PHOTO + " = " + photoActivity.getId();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Product
        public static void InsertProduct(Product product)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_PRODUK + " values (" + product.getId() + ", '" + product.getKd_produk() + "', '" + product.getNm_produk() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteProduct(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_PRODUK + " WHERE " + KEY_ID_PRODUK + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static Product ReadProduct(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_PRODUK + " WHERE " + KEY_ID_PRODUK + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Product product = new Product(int.Parse(reader[KEY_ID_PRODUK].ToString()), reader[KEY_KODE_PRODUK].ToString(), reader[KEY_NAMA_PRODUK].ToString());
                reader.Close();
                return product;
            }
            reader.Close();
            return null;
        }
        public static List<Product> ReadAllProduct()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_PRODUK;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product(int.Parse(reader[KEY_ID_PRODUK].ToString()), reader[KEY_KODE_PRODUK].ToString(), reader[KEY_NAMA_PRODUK].ToString()));
            }
            reader.Close();
            return products;
        }
        public static void UpdateProduct(Product product)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_PRODUK + " set " + KEY_KODE_PRODUK + " = '" + product.getKd_produk()
                + "', " + KEY_NAMA_PRODUK + " = '" + product.getNm_produk() + "' where " + KEY_ID_PRODUK + " = " + product.getId();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region TakeOrder
        public static void InsertTakeOrder(TakeOrder takeOrder)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_TAKE_ORDER + " values ("
                + takeOrder.getId() + ", '" + takeOrder.getKd_to() + "', " + takeOrder.getKd_visit()
                + ", " + takeOrder.getKd_produk() + ", " + takeOrder.getQty() + ", '"
                + takeOrder.getSatuan() + "', '" + takeOrder.getDate_order() + "', " + takeOrder.getStatus() + ")";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteTakeOrder(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_TAKE_ORDER + " WHERE " + KEY_KODE_TAKE_ORDER + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static TakeOrder ReadTakeOrder(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_TAKE_ORDER + " WHERE " + KEY_KODE_TAKE_ORDER + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                TakeOrder takeOrder = new TakeOrder(int.Parse(reader[KEY_KODE_TAKE_ORDER].ToString()),
                    reader[KEY_KD_TO].ToString(), int.Parse(reader[KEY_KODE_VISITPLAN].ToString()),
                    int.Parse(reader[KEY_KODE_PRODUK].ToString()),int.Parse(reader[KEY_QUANTITY].ToString()),
                    reader[KEY_SATUAN].ToString(), reader[KEY_DATE_ORDER].ToString(), int.Parse(reader[KEY_STATUS_ORDER].ToString()));
                reader.Close();
                return takeOrder;
            }
            reader.Close();
            return null;
        }
        public static List<TakeOrder> ReadAllTakeOrder()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_TAKE_ORDER;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<TakeOrder> takeOrders = new List<TakeOrder>();
            while (reader.Read())
            {
                takeOrders.Add(new TakeOrder(int.Parse(reader[KEY_KODE_TAKE_ORDER].ToString()),
                    reader[KEY_KD_TO].ToString(), int.Parse(reader[KEY_KODE_VISITPLAN].ToString()),
                    int.Parse(reader[KEY_KODE_PRODUK].ToString()), int.Parse(reader[KEY_QUANTITY].ToString()),
                    reader[KEY_SATUAN].ToString(), reader[KEY_DATE_ORDER].ToString(), int.Parse(reader[KEY_STATUS_ORDER].ToString())));
            }
            reader.Close();
            return takeOrders;
        }
        public static void UpdateTakeOrder(TakeOrder takeOrder)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_TAKE_ORDER + " set " + KEY_KD_TO + " = '" + takeOrder.getKd_to() +
                "', " + KEY_KODE_VISITPLAN + " = " + takeOrder.getKd_visit() + ", " + KEY_KODE_PRODUK + " = " + takeOrder.getKd_produk() +
                ", " + KEY_QUANTITY + " = " + takeOrder.getQty() + ", " + KEY_SATUAN + " = '" + takeOrder.getSatuan() +
                "', " + KEY_DATE_ORDER + " = '" + takeOrder.getDate_order() + "', " + KEY_STATUS_ORDER + " = " + takeOrder.getStatus() +
                " where " + KEY_KODE_TAKE_ORDER + " = " + takeOrder.getId();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Tipe
        public static void InsertTipe(Tipe tipe)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_TIPE + " values (" + tipe.getId() + ", '" + tipe.getNm_tipe() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteTipe(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_TIPE + " WHERE " + KEY_KODE_TIPE + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static Tipe ReadTipe(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_TIPE + " WHERE " + KEY_KODE_TIPE + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Tipe tipe = new Tipe(int.Parse(reader[KEY_KODE_TIPE].ToString()), reader[KEY_NAMA_TIPE].ToString());
                reader.Close();
                return tipe;
            }
            reader.Close();
            return null;
        }
        public static List<Tipe> ReadAllTipe()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_TIPE;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Tipe> tipes = new List<Tipe>();
            while (reader.Read())
            {
                tipes.Add(new Tipe(int.Parse(reader[KEY_KODE_TIPE].ToString()), reader[KEY_NAMA_TIPE].ToString()));
            }
            reader.Close();
            return tipes;
        }
        public static void UpdateTipe(Tipe tipe)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_TIPE + " set " + KEY_NAMA_TIPE + " = '" + tipe.getNm_tipe() + "' where " + KEY_KODE_TIPE + " = " + tipe.getId();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region TipePhoto
        public static void InsertTipePhoto(TipePhoto tipePhoto)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_TIPE_PHOTO + " values (" + tipePhoto.getId() + ", '" + tipePhoto.getNama_tipe() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteTipePhoto(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_TIPE_PHOTO + " WHERE " + KEY_ID_TIPE + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static TipePhoto ReadTipePhoto(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_TIPE_PHOTO + " WHERE " + KEY_ID_TIPE + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                TipePhoto tipe = new TipePhoto(int.Parse(reader[KEY_ID_TIPE].ToString()), reader[KEY_NM_TIPE].ToString());
                reader.Close();
                return tipe;
            }
            reader.Close();
            return null;
        }
        public static List<TipePhoto> ReadTipePhoto()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_TIPE_PHOTO;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<TipePhoto> tipes = new List<TipePhoto>();
            while(reader.Read())
            {
                tipes.Add(new TipePhoto(int.Parse(reader[KEY_ID_TIPE].ToString()), reader[KEY_NM_TIPE].ToString()));
            }
            reader.Close();
            return tipes;
        }
        public static void UpdateTipePhoto(TipePhoto tipePhoto)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_TIPE_PHOTO + " set " + KEY_NM_TIPE + " = '" + tipePhoto.getNama_tipe() + "' where " + KEY_ID_TIPE + " = " + tipePhoto.getId();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region User
        public static void InsertUser(User user)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_USER + " values ("
                + user.getKode() + ", " + user.getKodeRole() + ", " + user.getKd_kota()
                + ", " + user.getKd_area() + ", '" + user.getNIK() + "', '"
                + user.getNama() + "', '" + user.getAlamat() + "', '" + user.getTelepon() + "', '" + user.getPath_foto() +
                "', '" + user.getUsername() + "', '" + user.getPassword() + "', '" + user.getEmail() +
                "', " + user.getStatus() + ", " + user.getToleransi() + ", '" + user.getGcmId() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteUser(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_USER + " WHERE " + KEY_KODE_USER + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static User ReadUser(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_USER + " WHERE " + KEY_KODE_USER + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                User user = new User(int.Parse(reader[KEY_KODE_USER].ToString()),
                    int.Parse(reader[KEY_KODE_ROLE].ToString()), int.Parse(reader[KEY_KODE_KOTA].ToString()),
                     int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NIK].ToString(),
                     reader[KEY_NAMA_USER].ToString(), reader[KEY_ALAMAT_USER].ToString(),
                     reader[KEY_TELEPON].ToString(), reader[KEY_FOTO].ToString(),
                     reader[KEY_USERNAME].ToString(), reader[KEY_PASSWORD].ToString(),
                     reader[KEY_EMAIL].ToString(), int.Parse(reader[KEY_STATUS].ToString()),
                     reader[KEY_GCMID].ToString(), int.Parse(reader[KEY_TOLERANSI].ToString()));
                reader.Close();
                return user;
            }
            reader.Close();
            return null;
        }
        public static List<User> ReadAllUser()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_USER + " WHERE " + KEY_KODE_ROLE + "= 3";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new User(int.Parse(reader[KEY_KODE_USER].ToString()),
                    int.Parse(reader[KEY_KODE_ROLE].ToString()), int.Parse(reader[KEY_KODE_KOTA].ToString()),
                     int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NIK].ToString(),
                     reader[KEY_NAMA_USER].ToString(), reader[KEY_ALAMAT_USER].ToString(),
                     reader[KEY_TELEPON].ToString(), reader[KEY_FOTO].ToString(),
                     reader[KEY_USERNAME].ToString(), reader[KEY_PASSWORD].ToString(),
                     reader[KEY_EMAIL].ToString(), int.Parse(reader[KEY_STATUS].ToString()),
                     reader[KEY_GCMID].ToString(), int.Parse(reader[KEY_TOLERANSI].ToString())));
            }
            reader.Close();
            return users;
        }
        public static List<User> ReadAllSF()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_USER;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new User(int.Parse(reader[KEY_KODE_USER].ToString()),
                    int.Parse(reader[KEY_KODE_ROLE].ToString()), int.Parse(reader[KEY_KODE_KOTA].ToString()),
                     int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NIK].ToString(),
                     reader[KEY_NAMA_USER].ToString(), reader[KEY_ALAMAT_USER].ToString(),
                     reader[KEY_TELEPON].ToString(), reader[KEY_FOTO].ToString(),
                     reader[KEY_USERNAME].ToString(), reader[KEY_PASSWORD].ToString(),
                     reader[KEY_EMAIL].ToString(), int.Parse(reader[KEY_STATUS].ToString()),
                     reader[KEY_GCMID].ToString(), int.Parse(reader[KEY_TOLERANSI].ToString())));
            }
            reader.Close();
            return users;
        }
        public static void UpdateUser(User user)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_USER + " set " + KEY_KODE_ROLE + " = " + user.getKodeRole() + 
                ", " + KEY_KODE_KOTA + " = " + user.getKd_kota() +
                ", " + KEY_KODE_AREA + " = " + user.getKd_area() + ", " + KEY_NIK + " = '" + user.getNIK() +
                "', " + KEY_NAMA_USER + " = '" + user.getNama() + "', " + KEY_ALAMAT_USER + " = '" + user.getAlamat() +
                "', " + KEY_TELEPON + " = '" + user.getTelepon() + "', " + KEY_FOTO + " = '" + user.getPath_foto() +
                "', " + KEY_USERNAME + " = '" + user.getUsername() + "', " + KEY_PASSWORD + " = '" + user.getPassword() +
                "', " + KEY_EMAIL + " = '" + user.getEmail() + "', " + KEY_STATUS + " = " + user.getStatus() +
                ", " + KEY_TOLERANSI + " = " + user.getToleransi() + ", " + KEY_GCMID + " = '" + user.getGcmId() +
                "' where " + KEY_KODE_USER + " = " + user.getKode();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region VisitPlan
        public static void InsertVisitPlan(VisitPlan visitPlan)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_VISITPLAN + " values ("
                + visitPlan.getKd_visit() + ", " + visitPlan.getKd_outlet() + ", '" + visitPlan.getDate_visit()
                + "', '" + visitPlan.getDate_created() + "', " + visitPlan.getApprove_visit() + ", "
                + visitPlan.getStatus_visit() + ", '" + visitPlan.getDate_visiting() + "', '" + visitPlan.getSkip_order_reason() 
                + "', '" + visitPlan.getSkip_reason() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteVisitPlan(int id)
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_VISITPLAN + " WHERE " + KEY_KODE_VISITPLAN + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static VisitPlan ReadVisitPlan(int id)
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_VISITPLAN + " WHERE " + KEY_KODE_VISITPLAN + "=" + id;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                VisitPlan visitPlan = new VisitPlan(int.Parse(reader[KEY_KODE_VISITPLAN].ToString()),
                    int.Parse(reader[KEY_KODE_OUTLET].ToString()), reader[KEY_DATE_VISIT].ToString(),
                     reader[KEY_DATE_CREATE_VISIT].ToString(), int.Parse(reader[KEY_APPROVE_VISIT].ToString()),
                     int.Parse(reader[KEY_STATUS_VISIT].ToString()), reader[KEY_DATE_VISITING].ToString(), 
                     reader[KEY_SKIP_ORDER_REASON].ToString(),reader[KEY_SKIP_REASON].ToString());
                reader.Close();
                return visitPlan;
            }
            reader.Close();
            return null;
        }
        public static List<VisitPlan> ReadAllVisitPlan()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_VISITPLAN;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            List<VisitPlan> visitPlans = new List<VisitPlan>();
            while (reader.Read())
            {
                VisitPlan visit = new VisitPlan(int.Parse(reader[KEY_KODE_VISITPLAN].ToString()),
                    int.Parse(reader[KEY_KODE_OUTLET].ToString()), reader[KEY_DATE_VISIT].ToString(),
                     reader[KEY_DATE_CREATE_VISIT].ToString(), int.Parse(reader[KEY_APPROVE_VISIT].ToString()),
                     int.Parse(reader[KEY_STATUS_VISIT].ToString()), reader[KEY_DATE_VISITING].ToString(),
                     reader[KEY_SKIP_ORDER_REASON].ToString(), reader[KEY_SKIP_REASON].ToString());
                Outlet outlet = ReadOutlet(visit.getKd_outlet());
                User user = ReadUser(outlet.getKode_user());
                visit.kota = ReadCity(user.getKd_kota()).getNama();
                visit.nm_outlet = outlet.getNama();
                visit.nm_dist = ReadDistributor(outlet.getKode_distributor()).getNm_dist();
                visit.alamat_outlet = outlet.getAlamat();
                visit.nm_sales = user.getNama();
                visitPlans.Add(visit);
            }
            reader.Close();
            return visitPlans;
        }
        public static void UpdateVisitPlan(VisitPlan visitPlan)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_VISITPLAN + " set " + KEY_KODE_OUTLET + " = " + visitPlan.getKd_outlet() +
                ", " + KEY_DATE_VISIT + " = '" + visitPlan.getDate_visit() + "', " + KEY_DATE_CREATE_VISIT + " = '" + visitPlan.getDate_created() +
                "', " + KEY_APPROVE_VISIT + " = " + visitPlan.getApprove_visit() + ", " + KEY_STATUS_VISIT + " = " + visitPlan.getStatus_visit() +
                ", " + KEY_DATE_VISITING + " = '" + visitPlan.getDate_visiting() + "', " + KEY_SKIP_ORDER_REASON + " = '" + visitPlan.getSkip_order_reason() +
                "', " + KEY_SKIP_REASON + " = '" + visitPlan.getSkip_reason() + "' where " + KEY_KODE_VISITPLAN + " = " + visitPlan.getKd_visit();
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Konfigurasi
        public static void InsertKonfigurasi(int toleransi_max)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_KONFIGURASI + " values (" + toleransi_max + ")";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static int ReadKonfigurasi()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_KONFIGURASI;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int toleransi = int.Parse(reader[KEY_TOLERANSI_MAX].ToString());
                reader.Close();
                return toleransi;
            }
            reader.Close();
            return 0;
        }
        public static void UpdateKonfigurasi(int toleransi_max)
        {
            CreateOrReadDB();
            string sql = "update " + TABLE_KONFIGURASI + " set " + KEY_TOLERANSI_MAX + " = " + toleransi_max;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Dashboard query

        #endregion
        #region Login
        public static void InsertLoginUser(User user)
        {
            CreateOrReadDB();
            string sql = "insert into " + TABLE_LOGGEDIN + " values ("
                + user.getKode() + ", " + user.getKodeRole() + ", " + user.getKd_kota()
                + ", " + user.getKd_area() + ", '" + user.getNIK() + "', '"
                + user.getNama() + "', '" + user.getAlamat() + "', '" + user.getTelepon() + "', '" + user.getPath_foto() +
                "', '" + user.getUsername() + "', '" + user.getPassword() + "', '" + user.getEmail() +
                "', " + user.getStatus() + ", " + user.getToleransi() + ", '" + user.getGcmId() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static void DeleteLoginUser()
        {
            CreateOrReadDB();
            string sql = "DELETE FROM " + TABLE_LOGGEDIN;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            command.ExecuteNonQuery();
        }
        public static User ReadLoginUser()
        {
            CreateOrReadDB();
            string sql = "select * from " + TABLE_LOGGEDIN;
            SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                User user = new User(int.Parse(reader[KEY_KODE_USER].ToString()),
                    int.Parse(reader[KEY_KODE_ROLE].ToString()), int.Parse(reader[KEY_KODE_KOTA].ToString()),
                     int.Parse(reader[KEY_KODE_AREA].ToString()), reader[KEY_NIK].ToString(),
                     reader[KEY_NAMA_USER].ToString(), reader[KEY_ALAMAT_USER].ToString(),
                     reader[KEY_TELEPON].ToString(), reader[KEY_FOTO].ToString(),
                     reader[KEY_USERNAME].ToString(), reader[KEY_PASSWORD].ToString(),
                     reader[KEY_EMAIL].ToString(), int.Parse(reader[KEY_STATUS].ToString()),
                     reader[KEY_GCMID].ToString(), int.Parse(reader[KEY_TOLERANSI].ToString()));
                reader.Close();
                return user;
            }
            reader.Close();
            return null;
        }
        #endregion
        #endregion
    }
}