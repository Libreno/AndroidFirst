using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidFirst.Droid
{
    public class ColorSliderFragment : Fragment, SeekBar.IOnSeekBarChangeListener
    {
        private LinearLayout layout;
        private TextView textRed;
        private TextView textGreen;
        private TextView textBlue;
        private SeekBar seekBarRed;
        private SeekBar seekBarGreen;
        private SeekBar seekBarBlue;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ColorSliders, null);

            layout = view.FindViewById<LinearLayout>(Resource.Id.layoutSliders);

            textRed = view.FindViewById<TextView>(Resource.Id.textRed);
            textGreen = view.FindViewById<TextView>(Resource.Id.textGreen);
            textBlue = view.FindViewById<TextView>(Resource.Id.textBlue);

            seekBarRed = view.FindViewById<SeekBar>(Resource.Id.seekBarRed);
            seekBarGreen = view.FindViewById<SeekBar>(Resource.Id.seekBarGreen);
            seekBarBlue = view.FindViewById<SeekBar>(Resource.Id.seekBarBlue);

            seekBarRed.SetOnSeekBarChangeListener(this);
            seekBarGreen.SetOnSeekBarChangeListener(this);
            seekBarBlue.SetOnSeekBarChangeListener(this);

            return view;
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            layout.SetBackgroundColor(new Color(seekBarRed.Progress, seekBarGreen.Progress, seekBarBlue.Progress));
            textRed.Text = seekBarRed.Progress.ToString();
            textGreen.Text = seekBarGreen.Progress.ToString();
            textBlue.Text = seekBarBlue.Progress.ToString();
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }
    }
}