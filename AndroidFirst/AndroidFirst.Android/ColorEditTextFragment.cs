using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace AndroidFirst.Droid
{
    public class ColorEditTextFragment : Fragment
    {
        private View colorDisplay;
        private EditText textRed;
        private EditText textGreen;
        private EditText textBlue;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ColorEditText, null);

            colorDisplay = view.FindViewById<View>(Resource.Id.colorDisplay);

            textRed = view.FindViewById<EditText>(Resource.Id.editTextRed);
            textGreen = view.FindViewById<EditText>(Resource.Id.editTextGreen);
            textBlue = view.FindViewById<EditText>(Resource.Id.editTextBlue);

            textRed.TextChanged += ColorTextChanged;
            textGreen.TextChanged += ColorTextChanged;
            textBlue.TextChanged += ColorTextChanged;
            
            return view;
        }

        private void ColorTextChanged(object sender, TextChangedEventArgs e)
        {
            int r, g, b;
            int.TryParse(textRed.Text, out r);
            int.TryParse(textGreen.Text, out g);
            int.TryParse(textBlue.Text, out b);

            colorDisplay.SetBackgroundColor(new Color(r, g, b));
        }
    }
}