using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Logging
    {
        private int kd_logging, id_user;
        private string Description, Log_time, Detail_akses;

        public int id
        {
            get
            {
                return kd_logging;
            }

            set
            {
                kd_logging = value;
            }
        }

        public int kd_user
        {
            get
            {
                return id_user;
            }

            set
            {
                id_user = value;
            }
        }

        public string description
        {
            get
            {
                return Description;
            }

            set
            {
                Description = value;
            }
        }

        public string log_time
        {
            get
            {
                return Log_time;
            }

            set
            {
                Log_time = value;
            }
        }

        public string detail_akses
        {
            get
            {
                return Detail_akses;
            }

            set
            {
                Detail_akses = value;
            }
        }

        public Logging(int kd_logging, int kd_user, string description, string log_time, string detail_akses)
        {
            this.kd_logging = kd_logging;
            setKd_user(kd_user);
            this.description = description;
            this.log_time = log_time;
            setDetail_akses(detail_akses);
        }

        public int getKd_logging()
        {
            return kd_logging;
        }

        public void setKd_logging(int kd_logging)
        {
            this.kd_logging = kd_logging;
        }
        public int getKd_user()
        {
            return id_user;
        }

        public void setKd_user(int kd_user)
        {
            this.id_user = kd_user;
        }

        public string getDescription()
        {
            return Description;
        }

        public void setDescription(string description)
        {
            this.Description = description;
        }

        public string getLog_time()
        {
            return Log_time;
        }

        public void setLog_time(string log_time)
        {
            this.Log_time = log_time;
        }
        public string getDetail_akses()
        {
            return Detail_akses;
        }

        public void setDetail_akses(string detail_akses)
        {
            this.Detail_akses = detail_akses;
        }
    }
}
