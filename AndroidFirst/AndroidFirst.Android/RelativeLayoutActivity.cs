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
    [Activity(Label = "RelativeLayoutActivity")]
    public class RelativeLayoutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //var rl = new RelativeLayout(this);
            //rl.AddChildrenForAccessibility(new );
            /*
            Children.Add(box, Constraint.RelativeToParent((parent) =>
                {
                    return (.5 * parent.Width) - 100;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return (.5 * parent.Height) - 100;
                }),
                Constraint.Constant(50), Constraint.Constant(50));
            */
            SetContentView(Resource.Layout.MyRelativeLayout);

            // Create your application here
        }
    }
}