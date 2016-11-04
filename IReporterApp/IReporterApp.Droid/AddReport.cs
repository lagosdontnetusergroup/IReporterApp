using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IReporterApp.Model;
using Newtonsoft.Json;

namespace IReporterApp.Droid
{
    [Activity(Label = "AddReport")]
    public class AddReport : Activity
    {
        IReporterService ireporterService = new IReporterService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.createreporter);
            Button btnAddReport = FindViewById<Button>(Resource.Id.btnAdd);
            btnAddReport.Click += btnAddReport_Click;

            Button btnViewReport = FindViewById<Button>(Resource.Id.btnHome);
            btnViewReport.Click += btnViewReport_Click;
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {
            EditText strTitle = FindViewById<EditText>(Resource.Id.edtTitle);
            EditText strMessage = FindViewById<EditText>(Resource.Id.edtMessage);
            EditText strLoc = FindViewById<EditText>(Resource.Id.edtLocation);
            ReporterContent reporterContent = new ReporterContent()
            {
                ImageBase64 = "",
                Message = strMessage.Text,
                Title = strTitle.Text,
                Location = strLoc.Text
            };
            //string serializeReportContent = JsonConvert.SerializeObject(reporterContent);
            //ireporterService.PostReport(serializeReportContent);
            MyClass.ReportList.Add(reporterContent);
        }

        
    }
}