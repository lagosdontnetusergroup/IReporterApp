using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IReporterApp.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IReporterApp.Droid
{
	[Activity (Label = "IReporter", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        //int count = 1;
        IReporterService ireporterService = new IReporterService();
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            //BindReportToListView();

            ListView lvReport = FindViewById<ListView>(Resource.Id.lvReport);
            lvReport.Adapter = new IReporterAdapter(this, MyClass.ReportList);
            ImageView imgAddReport = FindViewById<ImageView>(Resource.Id.imgAddReport);
            imgAddReport.Click += ImgAddReport_Click;
        }

        

        private void ImgAddReport_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddReport));
        }

        private async void BindReportToListView()
        {
            ListView lvReport = FindViewById<ListView>(Resource.Id.lvReport);
            string serializeReportFromAPI = await ireporterService.GetReport();
            List<ReporterContent> serializeReportContent = JsonConvert.DeserializeObject<List<ReporterContent>>(serializeReportFromAPI);
            if (serializeReportContent != null)
                lvReport.Adapter = new IReporterAdapter(this, serializeReportContent);
        }


    }
}


