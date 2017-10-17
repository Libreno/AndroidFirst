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

namespace AndroidFirst.Droid
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout1);

            var extras = Intent.Extras;
            if (extras != null)
            {
                var helloString = extras.GetString("hello");
                var label = FindViewById<TextView>(Resource.Id.text_view_id);
                label.Text = helloString;
            }
            // Create your application here
        }
    }
}