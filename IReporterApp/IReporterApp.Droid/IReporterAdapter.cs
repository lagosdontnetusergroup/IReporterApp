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

namespace IReporterApp.Droid
{
    public class IReporterAdapter : BaseAdapter<ReporterContent>
    {
        List<ReporterContent> items;
        Activity context;
        public IReporterAdapter(Activity context, List<ReporterContent> items)
       : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override ReporterContent this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.ireporter_item_cell, null);
            view.FindViewById<TextView>(Resource.Id.txtTitle).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.txtMessage).Text = item.Message;
            view.FindViewById<TextView>(Resource.Id.txtLocation).Text = item.Location;
            view.FindViewById<TextView>(Resource.Id.txtDate).Text = item.StrDateTime;
            return view;
        }
    }
}