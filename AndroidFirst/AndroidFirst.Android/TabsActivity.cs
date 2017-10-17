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
using Android.Support.V4.App;

namespace AndroidFirst.Droid
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Resource.Style.SupportFix);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TabsLayout);

            var tabLayout = FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tabLayout);
            tabLayout.TabSelected += OnTabSelected;

            Navigate(new TimeFragment());
            // Create your application here
        }

        private void OnTabSelected(object sender, Android.Support.Design.Widget.TabLayout.TabSelectedEventArgs args)
        {
            switch (args.Tab.Position)
            {
                case 0: Navigate(new TimeFragment()); break;
                case 1: Navigate(new StopWatchFragment()); break;
                case 2: Navigate(new AboutFragment()); break;
            }
        }

        public void Navigate(Android.Support.V4.App.Fragment fragment)
        {
            var transaction = base.SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.tabsContentFrame, fragment);
            transaction.Commit();
        }
    }
}