using IReporterApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IReporterApp
{
   public class IReporterService
    {
        string postUri = "";
        string getUri = "";



        public async void PostReport(string item)
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri(postUri);
            HttpResponseMessage respon = await client.PostAsync(uri, new StringContent(item, Encoding.UTF8, "application/json"));
            string respond = await respon.Content.ReadAsStringAsync();
        }

        public async Task<string> GetReport()
        {
            string reporterList = string.Empty;
            try
            {
                Uri geturi = new Uri(getUri);
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                responseGet.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                reporterList = await responseGet.Content.ReadAsStringAsync();
                return reporterList;
            }
            catch (Exception ex)
            {
                return reporterList;
            }
        }

    }
}
