using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Logging
    {
        private int kd_logging, kd_user;
        private string description, log_time, detail_akses;

        public int Kd_logging
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

        public int Kd_user
        {
            get
            {
                return kd_user;
            }

            set
            {
                kd_user = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Log_time
        {
            get
            {
                return log_time;
            }

            set
            {
                log_time = value;
            }
        }

        public string Detail_akses
        {
            get
            {
                return detail_akses;
            }

            set
            {
                detail_akses = value;
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
            return kd_user;
        }

        public void setKd_user(int kd_user)
        {
            this.kd_user = kd_user;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public string getLog_time()
        {
            return log_time;
        }

        public void setLog_time(string log_time)
        {
            this.log_time = log_time;
        }
        public string getDetail_akses()
        {
            return detail_akses;
        }

        public void setDetail_akses(string detail_akses)
        {
            this.detail_akses = detail_akses;
        }
    }
}
