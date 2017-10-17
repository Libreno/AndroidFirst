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
    [Activity(Label = "ActivityWithFragment")]
    public class ActivityWithFragment : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ActivityWithFragment);

            FindViewById<Button>(Resource.Id.buttonSlider).Click += ButtonSlidersClick;
            FindViewById<Button>(Resource.Id.buttonEditText).Click += ButtonEditTextClick;
        }

        private void ButtonEditTextClick(object sender, EventArgs e)
        {
            Replace(new ColorEditTextFragment());
        }

        private void ButtonSlidersClick(object sender, EventArgs e)
        {
            Replace(new ColorSliderFragment());
        }

        private void Replace(Fragment fragment)
        {
            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.frameLayout, fragment)
                .Commit();
        }
    }
}