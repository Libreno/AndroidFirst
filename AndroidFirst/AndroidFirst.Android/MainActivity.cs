using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Views;
using Orientation = Android.Content.Res.Orientation;
using Android.Runtime;
using System;
using Java.Lang;

namespace AndroidFirst.Droid
{
	[Activity (Label = "AndroidFirst.Android", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            
            #region
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button> (Resource.Id.myButton1);
		    Button button2 = FindViewById<Button>(Resource.Id.myButton2);
		    Button button3 = FindViewById<Button>(Resource.Id.myButton3);

            button.Click += (sender, args) =>
		    {
		        var intent = new Intent(this, typeof(Activity1));
		        StartActivity(intent);
		    };

            button2.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("http://xamarin.com");
                var intent = new Intent(Intent.ActionView, uri);
		        StartActivity(intent);
            };

		    button3.Click += (sender, args) =>
		    {
		        var intent = new Intent(this, typeof(Activity1));
		        intent.PutExtra("hello", "xamarin");
		        StartActivity(intent);
            };
            
            #endregion
            
            var buttonOpenList = FindViewById<Button>(Resource.Id.openListButton);
		    buttonOpenList.Click += (sender, args) =>
		    {
		        var intent = new Intent(this, typeof(MyListActivity));
		        StartActivity(intent);
            };

		    var buttonFragment = FindViewById<Button>(Resource.Id.fragmentButton);
		    buttonFragment.Click += (sender, args) =>
		    {
		        var intent = new Intent(this, typeof(ActivityWithFragment));
		        StartActivity(intent);
		    };

            var buttonTabs = FindViewById<Button>(Resource.Id.tabsButton);
            buttonTabs.Click += (sender, args) =>
            {
                var intent = new Intent(this, typeof(TabsActivity));
                StartActivity(intent);
            };

		    var buttonRelative = FindViewById<Button>(Resource.Id.relativeButton);
		    buttonRelative.Click += (sender, args) =>
		    {
		        var intent = new Intent(this, typeof(RelativeLayoutActivity));
		        StartActivity(intent);
		    };

		    var buttonNotify = FindViewById<Button>(Resource.Id.notifyButton);
		    buttonNotify.Click += (sender, args) =>
		    {
		        var builder = new Notification.Builder(this)
		            .SetContentTitle("New message received").SetPriority((int)NotificationPriority.Default)
		            .SetContentText("Production services runs ok")
		            .SetSmallIcon(Resource.Drawable.Icon);

		        // Build the notification:
		        var notification = builder.Build();

		        // Get the notification manager:
		        var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

		        // Publish the notification:
		        const int notificationId = 0;
		        notificationManager.Notify(notificationId, notification);
		    };
		    var buttonLock = FindViewById<Button>(Resource.Id.lockScreenButton);
		    buttonLock.Click += (sender, args) =>
		    {
		        var policyManager = GetSystemService(Context.DevicePolicyService) as DevicePolicyManager;
                var componentName = new ComponentName(BaseContext, Class);
		        Mylock(policyManager, componentName);
            };
		}

	    const string logTag = "MainActivity";
	    private void Mylock(DevicePolicyManager policyManager, ComponentName componentName)
	    {
	        if (Build.VERSION.SdkInt > BuildVersionCodes.Froyo)
	        {
	            var policy = new StrictMode.ThreadPolicy.Builder().PermitAll().Build();
	            StrictMode.SetThreadPolicy(policy);
	        }
	        var active = policyManager.IsAdminActive(componentName);
	        if (!active)
	        { // Without permission
	            Log.Error(logTag, "No authority~");
	            ActiveManage(componentName); // To get access
	        }
	        else
	        {
	            Log.Error(logTag, "Has authority");
	        }
	        policyManager.LockNow(); // lock screen directly
	        Finish();
	    }

	    private void ActiveManage(ComponentName componentName)
	    {
	        Log.Info(logTag, "activeManage");
	        var intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
	        intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin, componentName);
	        intent.PutExtra(DevicePolicyManager.ExtraAddExplanation, "developers：liushuaikobe");
	        StartActivityForResult(intent, 1);
	    }

        public override void OnConfigurationChanged(Configuration newConfig)
	    {
	        base.OnConfigurationChanged(newConfig);

	        if (newConfig.Orientation == Orientation.Landscape)
	            Toast.MakeText(this, "landscape", ToastLength.Short).Show();
	        else if (newConfig.Orientation == Orientation.Portrait)
	            Toast.MakeText(this, "portrait", ToastLength.Short).Show();
        }

	    protected override void OnRestart()
	    {
	        base.OnRestart();
	    }

	    protected override void OnStart()
	    {
	        base.OnStart();
        }

	    protected override void OnResume()
	    {
	        base.OnResume();
	    }

	    protected override void OnPause()
	    {
	        base.OnPause();
	    }

	    protected override void OnStop()
	    {
	        base.OnStop();
	    }

	    protected override void OnDestroy()
	    {
	        base.OnDestroy();
	    }
	}

    public class MyDeviceAdminReceiver : DeviceAdminReceiver
    {
        public MyDeviceAdminReceiver()
        {
        }

        protected MyDeviceAdminReceiver(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnDisabled(Context context, Intent intent)
        {
            base.OnDisabled(context, intent);
        }

        public override ICharSequence OnDisableRequestedFormatted(Context context, Intent intent)
        {
            return base.OnDisableRequestedFormatted(context, intent);
        }

        public override void OnEnabled(Context context, Intent intent)
        {
            base.OnEnabled(context, intent);
        }

        public override void OnPasswordChanged(Context context, Intent intent)
        {
            base.OnPasswordChanged(context, intent);
        }

        private void ShowToast()
        {
            
        }
    }
}


