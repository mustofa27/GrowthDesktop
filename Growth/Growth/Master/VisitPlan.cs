using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Master
{
    class VisitPlan
    {
        int kd_visit, approve_visit, status_visit, kd_outlet;
        string skip_reason, skip_order_reason, date_visit, date_visiting, date_created;
        public VisitPlan(int kd_visit, int kd_outlet, string date_visit)
        {
            setKd_visit(kd_visit);
            setKd_outlet(kd_outlet);
            setDate_visit(date_visit);
            setApprove_visit(2);
            setStatus_visit(0);
            DateTime calendar = DateTime.Now;
            setDate_created(calendar.Year + "-" + calendar.Month + "-" + calendar.Day +
            " " + calendar.Hour + ":" + calendar.Minute + ":" + calendar.Second);
        }
        public VisitPlan(int kd_visit, int kd_outlet, string date_visit, string date_created, int approve_visit, int status_visit, string date_visiting, string skip_order_reason, string skip_reason)
        {
            setKd_visit(kd_visit);
            setKd_outlet(kd_outlet);
            setDate_visit(date_visit);
            setDate_created(date_created);
            setApprove_visit(approve_visit);
            setStatus_visit(status_visit);
            setDate_visiting(date_visiting);
            setSkip_order_reason(skip_order_reason);
            setSkip_reason(skip_reason);
        }

        public int getKd_visit()
        {
            return kd_visit;
        }

        public void setKd_visit(int kd_visit)
        {
            this.kd_visit = kd_visit;
        }

        public int getApprove_visit()
        {
            return approve_visit;
        }

        public void setApprove_visit(int approve_visit)
        {
            this.approve_visit = approve_visit;
        }

        public int getStatus_visit()
        {
            return status_visit;
        }

        public void setStatus_visit(int status_visit)
        {
            this.status_visit = status_visit;
        }

        public int getKd_outlet()
        {
            return kd_outlet;
        }

        public void setKd_outlet(int kd_outlet)
        {
            this.kd_outlet = kd_outlet;
        }

        public string getDate_visit()
        {
            return date_visit;
        }

        public void setDate_visit(string date_visit)
        {
            this.date_visit = date_visit;
        }

        public string getDate_created()
        {
            return date_created;
        }

        public void setDate_created(string date_created)
        {
            this.date_created = date_created;
        }

        public string getDate_visiting()
        {
            return date_visiting;
        }

        public void setDate_visiting(string date_visiting)
        {
            this.date_visiting = date_visiting;
        }

        public string getSkip_order_reason()
        {
            return skip_order_reason;
        }

        public void setSkip_order_reason(string skip_order_reason)
        {
            this.skip_order_reason = skip_order_reason;
        }

        public string getSkip_reason()
        {
            return skip_reason;
        }

        public void setSkip_reason(string skip_reason)
        {
            this.skip_reason = skip_reason;
        }

    }
}
