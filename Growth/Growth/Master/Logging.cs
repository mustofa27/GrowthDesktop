using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class Logging
    {
        private int kd_logging;
        private string description, log_time;

        public Logging(int kd_logging, string description, string log_time)
        {
            this.kd_logging = kd_logging;
            this.description = description;
            this.log_time = log_time;
        }

        public int getKd_logging()
        {
            return kd_logging;
        }

        public void setKd_logging(int kd_logging)
        {
            this.kd_logging = kd_logging;
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
    }
}
