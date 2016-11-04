using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReporterApp.Model
{
    public class ReporterContent
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ImageBase64 { get; set; }
        public string Location { get; set; }
        public string StrDateTime
    {
            get
            {
                return GetCurrentDate();
            }

        }
        private string GetCurrentDate()
        {
            DateTime dt = DateTime.Now;
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second);

        }
    }
}
