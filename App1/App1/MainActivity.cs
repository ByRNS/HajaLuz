using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView txv;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

			txv = (TextView)FindViewById(Resource.Id.textView1);
            var txtColor = txv.TextColors;
            txv.Text = "";
			Button bt = (Button)FindViewById(Resource.Id.btn2);


            Button btnDestroi = FindViewById<Button>(Resource.Id.btnDestroi);
            Button btnPerList = FindViewById<Button>(Resource.Id.button1);            
            Button btnLimpaList = FindViewById<Button>(Resource.Id.btn2);
			Button btn2 = (Button)FindViewById (Resource.Id.button2);

            btnDestroi.Click += delegate { OnDestroy();
                Toast.MakeText(this, "Teste", ToastLength.Long).Show();
            };

            btnPerList.Click += delegate
            {
                List<string> list = new List<string> { "teste1", "teste2", "teste3", "teste4" };
                txv.Gravity = GravityFlags.CenterHorizontal;

                var tst = new Android.Graphics.Color(new Random().Next(200), 200, new Random().Next(200));
                //var draw = new Android.Graphics.Drawables.ColorDrawable(tst);
                txv.SetTextColor(tst);

                foreach (var item in list)
                {
                    txv.Text += item + "\n";
                }
                txv.Text += "-------\n";
            };

            btnLimpaList.Click += delegate
            {
                txv.Text = "";
                txv.SetTextColor(txtColor);
            };

            btn2.Click += delegate
            {
                Intent i = new Intent(this, typeof(teste));
                StartActivity(i);
            };
        }

        protected override void OnDestroy()
        {
            OnDestroy();
        }

        public override void OnBackPressed()
        {
            Toast.MakeText(this, "Back Pressionado", ToastLength.Short).Show();

			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.SetTitle("Error");
			builder.SetMessage("Can't connect to the database.");
			builder.SetCancelable(false);
			builder.SetPositiveButton("OK", delegate { Finish(); });
			builder.Show();
        }

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater mi = new MenuInflater (this);
			mi.Inflate (Resource.Menu.menu1, menu);
			return true;
		}

		public override bool OnMenuItemSelected (int featureId, IMenuItem item)
		{
			switch (item.ItemId) 
			{
			case Resource.Id.item1:
				Toast.MakeText (this, "Item 1", ToastLength.Long).Show ();
				break;
			case Resource.Id.item2:
				Toast.MakeText (this, "Item 2", ToastLength.Long).Show ();
				break;
			default:
				break;
			}
			return true;
		}
    }
}

