using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace AndroidFirst.Droid
{
    internal class StopWatchFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ColorEditText, null);
            return view;
        }
    }
}