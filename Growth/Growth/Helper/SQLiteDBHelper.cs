using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Growth.Helper
{
    class SQLiteDBHelper
    {
        static SQLiteConnection sqlite_conn;
        #region property db
        static string DB_NAME = "growth.sqlite",
            KEY_KODE_AREA = "kd_area",
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
                sqlite_conn = new SQLiteConnection("Data Source=growth.sqlite;Version=1;");
            }
            else
            {
                SQLiteConnection.CreateFile("growth.sqlite");
                sqlite_conn = new SQLiteConnection("Data Source=growth.sqlite;Version=3;");
                sqlite_conn.Open();
                List<string> sqlList = new List<string>();
                sqlList.Add("CREATE TABLE " + TABLE_OUTLET +
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
                sqlList.Add("CREATE TABLE " + TABLE_USER +
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
                sqlList.Add("CREATE TABLE " + TABLE_PHOTO +
                            "(" + KEY_KODE_PHOTO + " INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"
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
                sqlList.Add("CREATE TABLE " + TABLE_CITY +
                            "(" + KEY_KODE_KOTA + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_AREA + " INTEGER NOT NULL,"
                            + KEY_NAMA_KOTA + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_LOGGING +
                            "(" + KEY_KODE_LOGGING + " INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"
                            + KEY_DESCRIPTION + " INTEGER NOT NULL,"
                            + KEY_LOG_TIME + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_DISTRIBUTOR +
                            "(" + KEY_ID_DISTRIBUTOR + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_DISTRIBUTOR + " TEXT NOT NULL,"
                            + KEY_KODE_TIPE + " TEXT NOT NULL,"
                            + KEY_KODE_KOTA + " INTEGER NOT NULL,"
                            + KEY_NAMA_DISTRIBUTOR + " TEXT NOT NULL,"
                            + KEY_ALAMAT_DISTRIBUTOR + " TEXT NOT NULL,"
                            + KEY_TELEPON_DISTRIBUTOR + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_COMPETITOR +
                            "(" + KEY_KODE_COMPETITOR + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_KOTA + " INTEGER NOT NULL,"
                            + KEY_NAMA_COMPETITOR + " TEXT NOT NULL,"
                            + KEY_ALAMAT_COMPETITOR + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_TIPE +
                            "(" + KEY_KODE_TIPE + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_NAMA_TIPE + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_TIPE_PHOTO +
                            "(" + KEY_ID_TIPE + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_NM_TIPE + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_PRODUK +
                            "(" + KEY_ID_PRODUK + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_PRODUK + " TEXT NOT NULL,"
                            + KEY_NAMA_PRODUK + " TEXT NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_VISITPLAN +
                            "(" + KEY_KODE_VISITPLAN + " INTEGER PRIMARY KEY NOT NULL,"
                            + KEY_KODE_OUTLET + " INTEGER NOT NULL,"
                            + KEY_DATE_VISIT + " TEXT NOT NULL,"
                            + KEY_DATE_CREATE_VISIT + " TEXT NOT NULL,"
                            + KEY_APPROVE_VISIT + " INTEGER NOT NULL,"
                            + KEY_STATUS_VISIT + " INTEGER NOT NULL,"
                            + KEY_DATE_VISITING + " TEXT NOT NULL,"
                            + KEY_SKIP_ORDER_REASON + " TEXT NOT NULL,"
                            + KEY_SKIP_REASON + " REAL NOT NULL)");
                sqlList.Add("CREATE TABLE " + TABLE_KONFIGURASI +
                            "(" + KEY_STATUS_APP + " INTEGER DEFAULT 0)");
                foreach (var sql in sqlList)
                {
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite_conn);
                    command.ExecuteNonQuery();
                }
            }
        }
        #region DB CRUD
        public static void InsertOutlet()
        {

        }
        public static void DeleteOutlet()
        {

        }
        public static void ReadOutlet(int id)
        {

        }
        public static void ReadAllOutlet()
        {

        }
        public static void UpdateOutlet()
        {

        }
        #endregion
    }
}
