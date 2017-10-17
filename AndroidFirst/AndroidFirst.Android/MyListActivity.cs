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
    [Activity(Label = "MyListActivity")]
    public class MyListActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var items = new[] { "Rafael", "Leonardo", "Donatello", "Mickelangelo"};
            var personItems = new List<Person>();
            for (var i = 0; i < 200; i++)
            {
                personItems.Add(new Person
                {
                    FirstName = "FirstName " + i,
                    LastName = "LastName " + i
                });
            }
            ListAdapter = new PersonAdapter(this, personItems);
            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            // Create your application here
        }
    }

    public class PersonAdapter : BaseAdapter<Person>
    {
        private readonly Activity _context;
        private readonly List<Person> _items;

        public PersonAdapter(Activity context, List<Person> items)
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.PersonListItem, null);
            var personIcon = _context.Resources.GetDrawable(Resource.Drawable.Icon);

            view.FindViewById<TextView>(Resource.Id.FirstName).Text = this[position].FirstName;
            view.FindViewById<TextView>(Resource.Id.LastName).Text = this[position].LastName;

            view.FindViewById<ImageView>(Resource.Id.Thumbnail).SetImageDrawable(personIcon);

            return view;
        }

        public override int Count => _items.Count;

        public override Person this[int position] => _items[position];
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}